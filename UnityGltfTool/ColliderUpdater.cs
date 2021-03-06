﻿using glTFLoader.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityGltfTool
{
	public class ColliderUpdater
	{
		private const string extensionName = "Unity_colliders";

		private Gltf gltf;
		private IDictionary<int, Unity_collidersCollider> colliders;

		public ColliderUpdater(Gltf gltf, IDictionary<int, Unity_collidersCollider> colliders)
		{
			this.gltf = gltf;
			this.colliders = colliders;
		}

		public void UpdateColliders()
		{
			UpdateExtensionsUsedAndRequired();
			UpdateNodeExtensions();
			RemoveMeshNodesConvertedToColliders();
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

		/// <summary>
		/// Removes nodes that reference meshes that have been converted to colliders
		/// </summary>
		private void RemoveMeshNodesConvertedToColliders()
		{
			var meshColliders = colliders.Values.Where(x => x.MeshCollider?.Mesh != null).Select(x => x.MeshCollider);
			foreach (var meshCollider in meshColliders)
			{
				var nodeIndex = Array.FindIndex(gltf.Nodes, x => x.Mesh == meshCollider.Mesh);
				if (nodeIndex != -1)
					RemoveNode(nodeIndex);
			}
		}

		private void RemoveNode(int nodeIndex)
		{
			// Remove node
			var nodes = gltf.Nodes.ToList();
			nodes.RemoveAt(nodeIndex);
			gltf.Nodes = nodes.ToArray();

			// Remove scene node
			var scene = gltf.Scenes[gltf.Scene.Value];
			scene.Nodes = RemoveNode(scene.Nodes, nodeIndex);

			foreach (var node in gltf.Nodes)
			{
				if (node.Children == null)
					continue;

				// Remove child node
				node.Children = RemoveNode(node.Children, nodeIndex);
			}
		}

		private int[] RemoveNode(int[] nodes, int nodeIndex)
		{
			var nodeList = nodes.ToList();
			nodeList.Remove(nodeIndex);

			// Decrement node indices for any nodes with indices after the removed node
			for (int i = 0; i < nodeList.Count; i++)
			{
				if (nodeList[i] > nodeIndex)
					nodeList[i]--;
			}

			return nodeList.ToArray();
		}
	}
}
