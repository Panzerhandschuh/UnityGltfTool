using glTFLoader.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityGltfTool.Utils
{
	public static class Unity_collidersColliderExtensions
	{
		public static ColliderType GetColliderType(this Unity_collidersCollider collider)
		{
			if (collider.BoxCollider != null)
				return ColliderType.Box;
			else if (collider.SphereCollider != null)
				return ColliderType.Sphere;
			else if (collider.CapsuleCollider != null)
				return ColliderType.Capsule;
			else if (collider.MeshCollider != null)
				return ColliderType.Mesh;
			else
				return ColliderType.None;
		}

		public static void SetColliderType(this Unity_collidersCollider collider, ColliderType colliderType)
		{
			Reset(collider);

			switch (colliderType)
			{
				case ColliderType.Box:
					collider.BoxCollider = new Unity_collidersBoxCollider();
					break;
				case ColliderType.Sphere:
					collider.SphereCollider = new Unity_collidersSphereCollider();
					break;
				case ColliderType.Capsule:
					collider.CapsuleCollider = new Unity_collidersCapsuleCollider();
					break;
				case ColliderType.Mesh:
					collider.MeshCollider = new Unity_collidersMeshCollider();
					break;
			}
		}

		private static void Reset(Unity_collidersCollider collider)
		{
			collider.BoxCollider = null;
			collider.SphereCollider = null;
			collider.CapsuleCollider = null;
			collider.MeshCollider = null;
		}
	}
}
