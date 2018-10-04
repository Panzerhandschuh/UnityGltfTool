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
		private Gltf gltf;
		private IDictionary<int, Unity_collidersCollider> colliders;

		public GltfUpdater(Gltf gltf, IDictionary<int, Unity_collidersCollider> colliders)
		{
			this.gltf = gltf;
			this.colliders = colliders;
		}

		public void Update()
		{
			var sb = new StringBuilder();
			foreach (var kv in colliders)
			{
				var nodeIndex = kv.Key;
				var collider = kv.Value;
				var colliderType = collider.GetColliderType();
				sb.Append($"Node Index: {nodeIndex}\tCollider Type: {colliderType}\n");
			}
			MessageBox.Show(sb.ToString());
		}
	}
}
