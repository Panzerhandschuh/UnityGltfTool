namespace UnityGltfTool.TextureUtils
{
	// Additional info: https://docs.microsoft.com/en-us/windows/win32/direct3d11/texture-block-compression-in-direct3d-11
	public enum TextureFormat
	{
		BC1, // 5:6:5:1 bit RGBA
		BC3, // 5:6:5:8 bit RGBA
		BC4, // 8 bit R
		BC5, // 8:8 bit RG
		BC7 // 4-7 bit RGB, 0-8 bit alpha
	}
}
