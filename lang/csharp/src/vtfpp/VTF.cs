using System;
using System.Runtime.InteropServices;

namespace vtfpp
{
	public enum CompressionMethod
	{
		DEFLATE = 8,
		ZSTD = 93,
		CONSOLE_LZMA = 0x360,
	}

	public enum ResourceType
	{
		UNKNOWN,
		THUMBNAIL_DATA,
		IMAGE_DATA,
		PARTICLE_SHEET_DATA,
		CRC,
		LOD_CONTROL_INFO,
		EXTENDED_FLAGS,
		KEYVALUES_DATA,
		AUX_COMPRESSION,
	}

	[Flags]
	public enum ResourceFlags
	{
		NONE = 0,
		LOCAL_DATA = 1 << 1,
	}

	[Flags]
	public enum VTFFlags
	{
		NONE = 0,
		POINT_SAMPLE = 1 << 0,
		TRILINEAR = 1 << 1,
		CLAMP_S = 1 << 2,
		CLAMP_T = 1 << 3,
		ANISOTROPIC = 1 << 4,
		HINT_DXT5 = 1 << 5,
		PWL_CORRECTED = 1 << 6,
		NORMAL = 1 << 7,
		NO_MIP = 1 << 8,
		NO_LOD = 1 << 9,
		LOAD_ALL_MIPS = 1 << 10,
		PROCEDURAL = 1 << 11,
		ONE_BIT_ALPHA = 1 << 12,
		MULTI_BIT_ALPHA = 1 << 13,
		ENVMAP = 1 << 14,
		RENDERTARGET = 1 << 15,
		DEPTH_RENDERTARGET = 1 << 16,
		NO_DEBUG_OVERRIDE = 1 << 17,
		SINGLE_COPY = 1 << 18,
		SRGB = 1 << 19,
		DEFAULT_POOL = 1 << 20,
		COMBINED = 1 << 21,
		ASYNC_DOWNLOAD = 1 << 22,
		NO_DEPTH_BUFFER = 1 << 23,
		SKIP_INITIAL_DOWNLOAD = 1 << 24,
		CLAMP_U = 1 << 25,
		VERTEX_TEXTURE = 1 << 26,
		XBOX_PRESWIZZLED = 1 << 26,
		SSBUMP = 1 << 27,
		XBOX_CACHEABLE = 1 << 27,
		LOAD_MOST_MIPS = 1 << 28,
		BORDER = 1 << 29,
		YCOCG = 1 << 30,
		ASYNC_SKIP_INITIAL_LOW_RES = 1 << 31,
	}

	public enum VTFPlatform
	{
		UNKNOWN = 0x000,
		PC = 0x001,
		PS3_PORTAL2 = 0x003,
		PS3_ORANGEBOX = 0x333,
		X360 = 0x360,
	}

	internal static unsafe partial class Extern
	{
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_open_from_mem")]
		public static partial void* VTFOpenFromMemory(byte* buffer, ulong bufferLen, int parseHeaderOnly);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_open_from_file")]
		public static partial void* VTFOpenFromFile([MarshalAs(UnmanagedType.LPStr)] string vtfPath);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_image_data_as_rgba8888")]
		public static partial sourcepp.Buffer VTFGetImageDataAsRGBA8888(void* handle, byte mip, ushort frame, byte face, ushort slice);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_width")]
		public static partial ushort VTFGetWidth(void* handle, byte mip);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_height")]
		public static partial ushort VTFGetHeight(void* handle, byte mip);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_close")]
		public static partial void VTFClose(void** handle);

		// Version and platform
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_version")]
		public static partial uint VTFGetVersion(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_version")]
		public static partial void VTFSetVersion(void* handle, uint version);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_platform")]
		public static partial VTFPlatform VTFGetPlatform(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_platform")]
		public static partial void VTFSetPlatform(void* handle, VTFPlatform platform);

		// Flags
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_flags")]
		public static partial uint VTFGetFlags(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_flags")]
		public static partial void VTFSetFlags(void* handle, uint flags);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_add_flags")]
		public static partial void VTFAddFlags(void* handle, uint flags);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_remove_flags")]
		public static partial void VTFRemoveFlags(void* handle, uint flags);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_is_srgb")]
		public static partial int VTFIsSRGB(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_srgb")]
		public static partial void VTFSetSRGB(void* handle, int srgb);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_compute_transparency_flags")]
		public static partial void VTFComputeTransparencyFlags(void* handle);

		// Format
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_format")]
		public static partial ImageFormat VTFGetFormat(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_format")]
		public static partial void VTFSetFormat(void* handle, ImageFormat format, byte filter, float quality);

		// Mip count
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_mip_count")]
		public static partial byte VTFGetMipCount(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_mip_count")]
		public static partial int VTFSetMipCount(void* handle, byte mipCount);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_recommended_mip_count")]
		public static partial int VTFSetRecommendedMipCount(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_compute_mips")]
		public static partial void VTFComputeMips(void* handle, byte filter);

		// Frame count
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_frame_count")]
		public static partial ushort VTFGetFrameCount(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_frame_count")]
		public static partial int VTFSetFrameCount(void* handle, ushort frameCount);

		// Face count
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_face_count")]
		public static partial byte VTFGetFaceCount(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_face_count")]
		public static partial int VTFSetFaceCount(void* handle, int isCubeMap);

		// Depth
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_depth")]
		public static partial ushort VTFGetDepth(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_depth")]
		public static partial int VTFSetDepth(void* handle, ushort depth);

		// Start frame
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_start_frame")]
		public static partial ushort VTFGetStartFrame(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_start_frame")]
		public static partial void VTFSetStartFrame(void* handle, ushort startFrame);

		// Reflectivity
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_reflectivity")]
		public static partial void VTFGetReflectivity(void* handle, float* r, float* g, float* b);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_reflectivity")]
		public static partial void VTFSetReflectivity(void* handle, float r, float g, float b);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_compute_reflectivity")]
		public static partial void VTFComputeReflectivity(void* handle);

		// Bumpmap scale
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_bumpmap_scale")]
		public static partial float VTFGetBumpmapScale(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_bumpmap_scale")]
		public static partial void VTFSetBumpmapScale(void* handle, float bumpMapScale);

		// Thumbnail
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_thumbnail_format")]
		public static partial ImageFormat VTFGetThumbnailFormat(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_thumbnail_width")]
		public static partial byte VTFGetThumbnailWidth(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_thumbnail_height")]
		public static partial byte VTFGetThumbnailHeight(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_has_thumbnail_data")]
		public static partial int VTFHasThumbnailData(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_thumbnail_data_as_rgba8888")]
		public static partial sourcepp.Buffer VTFGetThumbnailDataAsRGBA8888(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_thumbnail")]
		public static partial void VTFSetThumbnail(void* handle, byte* imageData, ulong imageLen, ImageFormat format, ushort width, ushort height, float quality);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_compute_thumbnail")]
		public static partial void VTFComputeThumbnail(void* handle, byte filter, float quality);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_remove_thumbnail")]
		public static partial void VTFRemoveThumbnail(void* handle);

		// Resources
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_resources_count")]
		public static partial uint VTFGetResourcesCount(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_resource_at_index")]
		public static partial void* VTFGetResourceAtIndex(void* handle, uint index);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_resource_with_type")]
		public static partial void* VTFGetResourceWithType(void* handle, ResourceType type);

		// Compression
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_compression_level")]
		public static partial short VTFGetCompressionLevel(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_compression_level")]
		public static partial void VTFSetCompressionLevel(void* handle, short compressionLevel);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_compression_method")]
		public static partial CompressionMethod VTFGetCompressionMethod(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_set_compression_method")]
		public static partial void VTFSetCompressionMethod(void* handle, CompressionMethod compressionMethod);

		// Image data
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_has_image_data")]
		public static partial int VTFHasImageData(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_padded_width")]
		public static partial ushort VTFGetPaddedWidth(void* handle, byte mip);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_get_padded_height")]
		public static partial ushort VTFGetPaddedHeight(void* handle, byte mip);

		// Save/Bake
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_bake")]
		public static partial sourcepp.Buffer VTFBake(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_vtf_bake_to_file")]
		public static partial int VTFBakeToFile(void* handle, [MarshalAs(UnmanagedType.LPStr)] string vtfPath);

		// Resource functions
		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_resource_get_type")]
		public static partial ResourceType ResourceGetType(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_resource_get_flags")]
		public static partial ResourceFlags ResourceGetFlags(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_resource_get_data")]
		public static partial byte* ResourceGetData(void* handle, ulong* dataLen);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_resource_get_data_as_crc")]
		public static partial uint ResourceGetDataAsCRC(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_resource_get_data_as_extended_flags")]
		public static partial uint ResourceGetDataAsExtendedFlags(void* handle);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_resource_get_data_as_lod")]
		public static partial void ResourceGetDataAsLOD(void* handle, byte* u, byte* v, byte* u360, byte* v360);

		[LibraryImport("sourcepp_vtfppc", EntryPoint = "vtfpp_resource_get_data_as_keyvalues_data")]
		public static partial sourcepp.String ResourceGetDataAsKeyvaluesData(void* handle);

	}

	public class VTF
	{
		private protected unsafe VTF(void* handle)
		{
			Handle = handle;
		}

		~VTF()
		{
			unsafe
			{
				fixed (void** handlePtr = &Handle)
				{
					Extern.VTFClose(handlePtr);
				}
			}
		}

		public static VTF? OpenFromMemory(byte[] buffer, int parseHeaderOnly)
		{
			unsafe
			{
				fixed (byte* bufferPtr = buffer)
				{
					var handle = Extern.VTFOpenFromMemory(bufferPtr, (ulong)buffer.LongLength, parseHeaderOnly);
					return handle == null ? null : new VTF(handle);
				}
			}
		}

		public static VTF? OpenFromFile(string path)
		{
			unsafe
			{
				var handle = Extern.VTFOpenFromFile(path);
				return handle == null ? null : new VTF(handle);
			}
		}

		public byte[]? GetImageDataAsRGBA8888(byte mip, ushort frame, byte face, ushort slice)
		{
			unsafe
			{
				var buffer = Extern.VTFGetImageDataAsRGBA8888(Handle, mip, frame, face, slice);
				return buffer.size < 0 ? null : sourcepp.BufferUtils.ConvertToArrayAndDelete(ref buffer);
			}
		}

		public ushort GetWidth(byte mip = 0)
		{
			unsafe
			{
				return Extern.VTFGetWidth(Handle, mip);
			}
		}

		public ushort GetHeight(byte mip = 0)
		{
			unsafe
			{
				return Extern.VTFGetHeight(Handle, mip);
			}
		}

		public uint Version
		{
			get
			{
				unsafe { return Extern.VTFGetVersion(Handle); }
			}
			set
			{
				unsafe { Extern.VTFSetVersion(Handle, value); }
			}
		}

		public VTFPlatform Platform
		{
			get
			{
				unsafe { return Extern.VTFGetPlatform(Handle); }
			}
			set
			{
				unsafe { Extern.VTFSetPlatform(Handle, value); }
			}
		}

		public VTFFlags Flags
		{
			get
			{
				unsafe { return (VTFFlags)Extern.VTFGetFlags(Handle); }
			}
			set
			{
				unsafe { Extern.VTFSetFlags(Handle, (uint)value); }
			}
		}

		public void AddFlags(VTFFlags flags)
		{
			unsafe { Extern.VTFAddFlags(Handle, (uint)flags); }
		}

		public void RemoveFlags(VTFFlags flags)
		{
			unsafe { Extern.VTFRemoveFlags(Handle, (uint)flags); }
		}

		public bool IsSRGB
		{
			get
			{
				unsafe { return Extern.VTFIsSRGB(Handle) != 0; }
			}
			set
			{
				unsafe { Extern.VTFSetSRGB(Handle, value ? 1 : 0); }
			}
		}

		public void ComputeTransparencyFlags()
		{
			unsafe { Extern.VTFComputeTransparencyFlags(Handle); }
		}

		public ImageFormat Format
		{
			get
			{
				unsafe { return Extern.VTFGetFormat(Handle); }
			}
		}

		public void SetFormat(ImageFormat format, byte filter = 0, float quality = 0.105f)
		{
			unsafe { Extern.VTFSetFormat(Handle, format, filter, quality); }
		}

		public byte MipCount
		{
			get
			{
				unsafe { return Extern.VTFGetMipCount(Handle); }
			}
			set
			{
				unsafe { Extern.VTFSetMipCount(Handle, value); }
			}
		}

		public bool SetRecommendedMipCount()
		{
			unsafe { return Extern.VTFSetRecommendedMipCount(Handle) != 0; }
		}

		public void ComputeMips(byte filter = 0)
		{
			unsafe { Extern.VTFComputeMips(Handle, filter); }
		}

		public ushort FrameCount
		{
			get
			{
				unsafe { return Extern.VTFGetFrameCount(Handle); }
			}
			set
			{
				unsafe { Extern.VTFSetFrameCount(Handle, value); }
			}
		}

		public byte FaceCount
		{
			get
			{
				unsafe { return Extern.VTFGetFaceCount(Handle); }
			}
		}

		public void SetFaceCount(bool isCubeMap)
		{
			unsafe { Extern.VTFSetFaceCount(Handle, isCubeMap ? 1 : 0); }
		}

		public ushort Depth
		{
			get
			{
				unsafe { return Extern.VTFGetDepth(Handle); }
			}
			set
			{
				unsafe { Extern.VTFSetDepth(Handle, value); }
			}
		}

		public ushort StartFrame
		{
			get
			{
				unsafe { return Extern.VTFGetStartFrame(Handle); }
			}
			set
			{
				unsafe { Extern.VTFSetStartFrame(Handle, value); }
			}
		}

		public (float r, float g, float b) GetReflectivity()
		{
			unsafe
			{
				float r, g, b;
				Extern.VTFGetReflectivity(Handle, &r, &g, &b);
				return (r, g, b);
			}
		}

		public void SetReflectivity(float r, float g, float b)
		{
			unsafe { Extern.VTFSetReflectivity(Handle, r, g, b); }
		}

		public void ComputeReflectivity()
		{
			unsafe { Extern.VTFComputeReflectivity(Handle); }
		}

		public float BumpmapScale
		{
			get
			{
				unsafe { return Extern.VTFGetBumpmapScale(Handle); }
			}
			set
			{
				unsafe { Extern.VTFSetBumpmapScale(Handle, value); }
			}
		}

		public ImageFormat ThumbnailFormat
		{
			get
			{
				unsafe { return Extern.VTFGetThumbnailFormat(Handle); }
			}
		}

		public byte ThumbnailWidth
		{
			get
			{
				unsafe { return Extern.VTFGetThumbnailWidth(Handle); }
			}
		}

		public byte ThumbnailHeight
		{
			get
			{
				unsafe { return Extern.VTFGetThumbnailHeight(Handle); }
			}
		}

		public bool HasThumbnailData
		{
			get
			{
				unsafe { return Extern.VTFHasThumbnailData(Handle) != 0; }
			}
		}

		public byte[]? GetThumbnailDataAsRGBA8888()
		{
			unsafe
			{
				var buffer = Extern.VTFGetThumbnailDataAsRGBA8888(Handle);
				return buffer.size < 0 ? null : sourcepp.BufferUtils.ConvertToArrayAndDelete(ref buffer);
			}
		}

		public void SetThumbnail(byte[] imageData, ImageFormat format, ushort width, ushort height, float quality = 0.105f)
		{
			unsafe
			{
				fixed (byte* imageDataPtr = imageData)
				{
					Extern.VTFSetThumbnail(Handle, imageDataPtr, (ulong)imageData.LongLength, format, width, height, quality);
				}
			}
		}

		public void ComputeThumbnail(byte filter = 0, float quality = 0.105f)
		{
			unsafe { Extern.VTFComputeThumbnail(Handle, filter, quality); }
		}

		public void RemoveThumbnail()
		{
			unsafe { Extern.VTFRemoveThumbnail(Handle); }
		}

		public uint ResourcesCount
		{
			get
			{
				unsafe { return Extern.VTFGetResourcesCount(Handle); }
			}
		}

		public Resource? GetResourceAtIndex(uint index)
		{
			unsafe
			{
				var handle = Extern.VTFGetResourceAtIndex(Handle, index);
				return handle == null ? null : new Resource(handle);
			}
		}

		public Resource? GetResourceWithType(ResourceType type)
		{
			unsafe
			{
				var handle = Extern.VTFGetResourceWithType(Handle, type);
				return handle == null ? null : new Resource(handle);
			}
		}

		public short CompressionLevel
		{
			get
			{
				unsafe { return Extern.VTFGetCompressionLevel(Handle); }
			}
			set
			{
				unsafe { Extern.VTFSetCompressionLevel(Handle, value); }
			}
		}

		public CompressionMethod CompressionMethod
		{
			get
			{
				unsafe { return Extern.VTFGetCompressionMethod(Handle); }
			}
			set
			{
				unsafe { Extern.VTFSetCompressionMethod(Handle, value); }
			}
		}

		public bool HasImageData
		{
			get
			{
				unsafe { return Extern.VTFHasImageData(Handle) != 0; }
			}
		}

		public ushort GetPaddedWidth(byte mip = 0)
		{
			unsafe { return Extern.VTFGetPaddedWidth(Handle, mip); }
		}

		public ushort GetPaddedHeight(byte mip = 0)
		{
			unsafe { return Extern.VTFGetPaddedHeight(Handle, mip); }
		}

		public byte[]? Bake()
		{
			unsafe
			{
				var buffer = Extern.VTFBake(Handle);
				return buffer.size < 0 ? null : sourcepp.BufferUtils.ConvertToArrayAndDelete(ref buffer);
			}
		}

		public bool BakeToFile(string vtfPath)
		{
			unsafe { return Extern.VTFBakeToFile(Handle, vtfPath) != 0; }
		}

		private protected readonly unsafe void* Handle;
	}

	public class Resource
	{
		private readonly unsafe void* Handle;

		internal unsafe Resource(void* handle)
		{
			Handle = handle;
		}

		public ResourceType Type
		{
			get
			{
				unsafe { return Extern.ResourceGetType(Handle); }
			}
		}

		public ResourceFlags Flags
		{
			get
			{
				unsafe { return Extern.ResourceGetFlags(Handle); }
			}
		}

		public byte[]? GetData()
		{
			unsafe
			{
				ulong dataLen;
				byte* data = Extern.ResourceGetData(Handle, &dataLen);
				if (data == null || dataLen == 0)
					return null;
				
				byte[] result = new byte[dataLen];
				for (ulong i = 0; i < dataLen; i++)
				{
					result[i] = data[i];
				}
				return result;
			}
		}

		public uint? GetDataAsCRC()
		{
			if (Type != ResourceType.CRC)
				return null;
			unsafe { return Extern.ResourceGetDataAsCRC(Handle); }
		}

		public uint? GetDataAsExtendedFlags()
		{
			if (Type != ResourceType.EXTENDED_FLAGS)
				return null;
			unsafe { return Extern.ResourceGetDataAsExtendedFlags(Handle); }
		}

		public (byte u, byte v, byte u360, byte v360)? GetDataAsLOD()
		{
			if (Type != ResourceType.LOD_CONTROL_INFO)
				return null;
			unsafe
			{
				byte u, v, u360, v360;
				Extern.ResourceGetDataAsLOD(Handle, &u, &v, &u360, &v360);
				return (u, v, u360, v360);
			}
		}

		public string? GetDataAsKeyvaluesData()
		{
			if (Type != ResourceType.KEYVALUES_DATA)
				return null;
			unsafe
			{
				var str = Extern.ResourceGetDataAsKeyvaluesData(Handle);
				return sourcepp.StringUtils.ConvertToStringAndDelete(ref str);
			}
		}
	}
}
