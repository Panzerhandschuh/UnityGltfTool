using glTFLoader.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityGltfTool.Utils
{
	public static class ColliderUtil
	{
		public static Unity_collidersCollider GetNodeCollider(Gltf gltf, int nodeIndex)
		{
			var colliderExtension = GetNodeColliderExtension(gltf, nodeIndex);
			if (colliderExtension == null)
				return null;

			return GetCollider(gltf, colliderExtension.Collider.Value);
		}

		private static Unity_collidersNodeExtension GetNodeColliderExtension(Gltf gltf, int nodeIndex)
		{
			var node = gltf.Nodes[nodeIndex];
			return ExtensionUtil.LoadExtension<Unity_collidersNodeExtension>(node.Extensions, "Unity_colliders");
		}

		private static Unity_collidersCollider GetCollider(Gltf gltf, int colliderIndex)
		{
			var colliderExtension = GetGltfColliderExtension(gltf);
			if (colliderExtension == null)
				return null;

			return colliderExtension.Colliders[colliderIndex];
		}

		private static Unity_collidersGltfExtension GetGltfColliderExtension(Gltf gltf)
		{
			return ExtensionUtil.LoadExtension<Unity_collidersGltfExtension>(gltf.Extensions, "Unity_colliders");
		}
	}
}
