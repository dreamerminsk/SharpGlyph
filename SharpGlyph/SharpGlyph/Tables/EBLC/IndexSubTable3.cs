﻿using System;
using System.Text;

namespace SharpGlyph {
	public class IndexSubTable3 : IndexSubTable {
		/// <summary>
		/// offsetArray[glyphIndex] + imageDataOffset =
		/// glyphData sizeOfArray =
		/// (lastGlyph - firstGlyph + 1) + 1 + 1 pad if needed.
		/// </summary>
		//public ushort[] offsetArray;
		protected int count;

		public static IndexSubTable3 Read(BinaryReaderFont reader, int count) {
			IndexSubTable3 value = new IndexSubTable3();
			value.header = IndexSubHeader.Read(reader);
			value.position = reader.Position;
			value.count = count;
			//value.offsetArray = reader.ReadUInt16Array(count + 1);
			return value;
		}

		public override GlyphBitmapData ReadBitmapData(BinaryReaderFont reader, int glyphId, int index) {
			if (index < 0 || index >= count - 1) {
				return null;
			}
			long start = reader.Position;
			reader.Position = position + index;
			uint offset0 = reader.ReadUInt32();
			uint offset1 = reader.ReadUInt32();
			uint byteSize = offset1 - offset0;
			reader.Position = start + offset0;
			return GlyphBitmapData.Read(
				reader,
				header.imageFormat,
				(int)byteSize
			);
		}

		/*
		public override GlyphBitmapData[] ReadGlyphBitmapData(BinaryReaderFont reader, int count) {
			ushort imageFormat = header.imageFormat;
			int glyphCount = offsetArray.Length - 1;
			GlyphBitmapData[] array = new GlyphBitmapData[glyphCount];
			for (int i = 0; i < glyphCount; i++) {
				ushort byteSize = (ushort)(offsetArray[i + 1] - offsetArray[i]);
				array[i] = GlyphBitmapData.Read(reader, imageFormat, byteSize);
			}
			return array;
		}
		*/

		public override string ToString() {
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("{");
			builder.AppendFormat("\t\"header\": {0},\n", header.ToString().Replace("\n", "\n\t"));
			/*
			builder.AppendLine("\t\"offsetArray\": [");
			for (int i = 0; i < offsetArray.Length; i++) {
				builder.AppendFormat("\t\t{0},\n", offsetArray[i]);
			}
			if (offsetArray.Length > 0) {
				builder.Remove(builder.Length - 2, 1);
			}
			builder.AppendLine("\t]");
			*/
			builder.Append("}");
			return builder.ToString();
		}
	}
}
