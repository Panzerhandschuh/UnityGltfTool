using glTFLoader.Schema;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnityGltfTool.TextureUtils
{
	public class TextureConverter
	{
		private const string ddsExtensionName = "MSFT_texture_dds";

		private string gltfPath;
		private Gltf gltf;

		public TextureConverter(string gltfPath, Gltf gltf)
		{
			this.gltfPath = gltfPath;
			this.gltf = gltf;
		}

		public void ConvertImagesToDds()
		{
			foreach (var mat in gltf.Materials)
				ConvertMaterialToDds(mat);
		}

		private void ConvertMaterialToDds(Material mat)
		{
			var pbrMat = mat.PbrMetallicRoughness;
			if (pbrMat != null)
			{
				var baseColorTexture = pbrMat.BaseColorTexture;
				if (baseColorTexture != null)
				{
					var alphaMode = mat.AlphaMode;
					var format = (alphaMode == Material.AlphaModeEnum.BLEND) ? TextureFormat.BC3 : TextureFormat.BC1;
					ConvertTextureToDds(baseColorTexture.Index, format);
				}

				var metallicRoughnessTexture = pbrMat.MetallicRoughnessTexture;
				if (metallicRoughnessTexture != null)
					ConvertTextureToDds(metallicRoughnessTexture.Index, TextureFormat.BC3);
			}

			var normalTexture = mat.NormalTexture;
			if (normalTexture != null)
				ConvertTextureToDds(normalTexture.Index, TextureFormat.BC5);

			var emissiveTexture = mat.EmissiveTexture;
			if (emissiveTexture != null)
				ConvertTextureToDds(emissiveTexture.Index, TextureFormat.BC1);

			var occlusionTexture = mat.OcclusionTexture;
			if (occlusionTexture != null)
				ConvertTextureToDds(occlusionTexture.Index, TextureFormat.BC1);
		}

		private void ConvertTextureToDds(int textureIndex, TextureFormat format)
		{
			var texture = gltf.Textures[textureIndex];
			if (texture.Extensions != null && texture.Extensions.ContainsKey(ddsExtensionName)) // Texture was already converted to dds
				return;

			if (!texture.Source.HasValue) // Texture has no image to convert
				return;

			var imageIndex = texture.Source.Value;
			if (ConvertImageToDds(imageIndex, format))
			{
				AddExtensionsUsedAndRequired();
				ReplaceTextureSourceWithDdsExtension(texture);
			}
		}

		private void AddExtensionsUsedAndRequired()
		{
			var extensionsUsed = gltf.ExtensionsUsed?.ToList() ?? new List<string>();
			if (!extensionsUsed.Contains(ddsExtensionName))
				extensionsUsed.Add(ddsExtensionName);

			gltf.ExtensionsUsed = extensionsUsed.ToArray();

			var extensionsRequired = gltf.ExtensionsRequired?.ToList() ?? new List<string>();
			if (!extensionsRequired.Contains(ddsExtensionName))
				extensionsRequired.Add(ddsExtensionName);

			gltf.ExtensionsRequired = extensionsRequired.ToArray();
		}

		private void ReplaceTextureSourceWithDdsExtension(Texture texture)
		{
			var imageIndex = texture.Source.Value;
			texture.Source = null;

			if (texture.Extensions == null)
				texture.Extensions = new Dictionary<string, object>();

			var ddsExtension = new Msft_texture_ddsExtension();
			ddsExtension.Source = imageIndex;
			texture.Extensions[ddsExtensionName] = ddsExtension;
		}

		private bool ConvertImageToDds(int imageIndex, TextureFormat format)
		{
			var image = gltf.Images[imageIndex];

			var uri = image.Uri;
			if (uri.StartsWith("data:image/"))
				return false;

			var uriExtension = Path.GetExtension(uri);
			if (uriExtension == ".dds") // Image is already dds
				return true;

			var assetPath = GetAssetPath(uri);
			var formatStr = GetFormatString(format);
			var outputDir = GetGltfDir();

			var startInfo = new ProcessStartInfo();
			startInfo.FileName = "texconv.exe";
			startInfo.Arguments = $"-hflip -vflip -pow2 -f {formatStr} -o \"{outputDir}\" \"{assetPath}\"";

			var process = Process.Start(startInfo);
			process.EnableRaisingEvents = true;
			process.Exited += (x, y) => OnFinishedConvertingImage(assetPath);

			var ddsUri = Path.ChangeExtension(uri, ".dds");
			image.Uri = ddsUri;
			image.Name = ddsUri;

			return true;
		}

		private void OnFinishedConvertingImage(string assetPath)
		{
			File.Delete(assetPath);
		}

		private string GetAssetPath(string uri)
		{
			var gltfDir = GetGltfDir();
			return Path.Combine(gltfDir, uri);
		}

		private string GetGltfDir()
		{
			return Path.GetDirectoryName(gltfPath);
		}

		private string GetFormatString(TextureFormat format)
		{
			switch (format)
			{
				case TextureFormat.BC1:
					return "BC1_UNORM";
				case TextureFormat.BC3:
					return "BC3_UNORM";
				case TextureFormat.BC5:
					return "BC5_UNORM";
				default:
					throw new InvalidOperationException($"Invalid {nameof(TextureFormat)} ({format})");
			}
		}
	}
}
