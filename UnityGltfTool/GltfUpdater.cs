using glTFLoader;
using glTFLoader.Schema;
using System.Collections.Generic;
using System.IO;
using UnityGltfTool.TextureUtils;

namespace UnityGltfTool
{
	public class GltfUpdater
	{
		private string gltfPath;
		private Gltf gltf;
		private IDictionary<int, Unity_collidersCollider> colliders;

		public GltfUpdater(string gltfPath, Gltf gltf, IDictionary<int, Unity_collidersCollider> colliders)
		{
			this.gltfPath = gltfPath;
			this.gltf = gltf;
			this.colliders = colliders;
		}

		public void Update(bool convertImagesToDds)
		{
			var colliderUpdater = new ColliderUpdater(gltf, colliders);
			colliderUpdater.UpdateColliders();

			if (convertImagesToDds)
			{
				var texConverter = new TextureConverter(gltfPath, gltf);
				texConverter.ConvertImagesToDds();
			}

			gltf.SaveModel(gltfPath);
		}
	}
}
