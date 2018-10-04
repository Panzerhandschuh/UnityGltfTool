using glTFLoader.Schema;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityGltfTool.Utils;

namespace UnityGltfTool
{
	public class ColliderManager
	{
		private Dictionary<int, Unity_collidersCollider> colliders;

		public ReadOnlyDictionary<int, Unity_collidersCollider> Colliders
		{
			get
			{
				return new ReadOnlyDictionary<int, Unity_collidersCollider>(colliders);
			}
		}

		public ColliderManager()
		{
			colliders = new Dictionary<int, Unity_collidersCollider>();
		}

		public void SetBoxCollider(int nodeIndex)
		{
			var collider = GetOrAddCollider(nodeIndex);
			collider.BoxCollider = new Unity_collidersBoxCollider();
		}

		public void SetSphereCollider(int nodeIndex)
		{
			var collider = GetOrAddCollider(nodeIndex);
			collider.SphereCollider = new Unity_collidersSphereCollider();
		}

		public void SetCapsuleCollider(int nodeIndex)
		{
			var collider = GetOrAddCollider(nodeIndex);
			collider.CapsuleCollider = new Unity_collidersCapsuleCollider();
		}

		public void SetMeshCollider(int nodeIndex)
		{
			var collider = GetOrAddCollider(nodeIndex);
			collider.MeshCollider = new Unity_collidersMeshCollider();
		}

		public Unity_collidersCollider GetOrAddCollider(int nodeIndex)
		{
			Unity_collidersCollider collider;
			if (!colliders.TryGetValue(nodeIndex, out collider))
			{
				collider = new Unity_collidersCollider();
				colliders.Add(nodeIndex, collider);
			}

			return collider;
		}

		public void AddCollider(int nodeIndex, Unity_collidersCollider collider)
		{
			colliders.Add(nodeIndex, collider);
		}

		public void RemoveCollider(int nodeIndex)
		{
			colliders.Remove(nodeIndex);
		}

		public ColliderType GetColliderType(int nodeIndex)
		{
			var collider = GetCollider(nodeIndex);
			if (collider != null)
				return collider.GetColliderType();

			return ColliderType.None;
		}

		public Unity_collidersCollider GetCollider(int nodeIndex)
		{
			if (colliders.TryGetValue(nodeIndex, out Unity_collidersCollider collider))
				return collider;

			return null;
		}
	}
}
