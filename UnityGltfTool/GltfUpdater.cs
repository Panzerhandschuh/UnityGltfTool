using glTFLoader;
using glTFLoader.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityGltfTool.Utils;

namespace UnityGltfTool
{
	public class GltfUpdater
	{
		private const string extensionName = "Unity_colliders";

		private Gltf gltf;
		private IDictionary<int, Unity_collidersCollider> colliders;

		public GltfUpdater(Gltf gltf, IDictionary<int, Unity_collidersCollider> colliders)
		{
			this.gltf = gltf;
			this.colliders = colliders;
		}

		public void Update(string path, bool convertImagesToDds)
		{
			UpdateColliders();
			if (convertImagesToDds)
				ConvertImagesToDds();

			gltf.SaveModel(path);
		}

		private void UpdateColliders()
		{
			UpdateExtensionsUsedAndRequired();
			UpdateNodeExtensions();
		}

		private void UpdateExtensionsUsedAndRequired()
		{
			var extensionsUsed = gltf.ExtensionsUsed?.ToList() ?? new List<string>();
			var extensionsRequired = gltf.ExtensionsRequired?.ToList() ?? new List<string>();
			var extensions = gltf.Extensions ?? new Dictionary<string, object>();
			if (colliders.Any())
			{
				if (!extensionsUsed.Contains(extensionName))
					extensionsUsed.Add(extensionName);
				if (!extensionsRequired.Contains(extensionName))
					extensionsRequired.Add(extensionName);

				var gltfExtension = new Unity_collidersGltfExtension();
				gltfExtension.Colliders = new Unity_collidersCollider[colliders.Count];
				extensions[extensionName] = gltfExtension;
			}
			else
			{
				if (extensionsUsed.Contains(extensionName))
					extensionsUsed.Remove(extensionName);
				if (extensionsRequired.Contains(extensionName))
					extensionsRequired.Remove(extensionName);
				if (extensions.ContainsKey(extensionName))
					extensions.Remove(extensionName);
			}

			gltf.ExtensionsUsed = extensionsUsed.Any() ? extensionsUsed.ToArray() : null;
			gltf.ExtensionsRequired = extensionsRequired.Any() ? extensionsRequired.ToArray() : null;
			gltf.Extensions = extensions.Any() ? extensions : null;
		}

		private void UpdateNodeExtensions()
		{
			int colliderIndex = 0;
			for (int i = 0; i < gltf.Nodes.Length; i++)
			{
				var node = gltf.Nodes[i];
				if (colliders.TryGetValue(i, out var collider))
				{
					AddNodeExtension(node, collider, colliderIndex);
					colliderIndex++;
				}
				else
					RemoveNodeExtension(node);
			}
		}

		private void AddNodeExtension(Node node, Unity_collidersCollider collider, int colliderIndex)
		{
			if (node.Extensions == null)
				node.Extensions = new Dictionary<string, object>();

			var nodeExtension = new Unity_collidersNodeExtension();
			node.Extensions[extensionName] = nodeExtension;

			AddCollider(collider, colliderIndex);
			nodeExtension.Collider = colliderIndex;
		}

		private void AddCollider(Unity_collidersCollider collider, int colliderIndex)
		{
			var gltfExtension = (Unity_collidersGltfExtension)gltf.Extensions[extensionName];
			gltfExtension.Colliders[colliderIndex] = collider;
		}

		private void RemoveNodeExtension(Node node)
		{
			if (node.Extensions == null)
				return;

			if (node.Extensions.ContainsKey(extensionName))
				node.Extensions.Remove(extensionName);

			if (!node.Extensions.Any())
				node.Extensions = null;
		}

		private void ConvertImagesToDds()
		{
			
		}
	}
}
