﻿using System;
using System.IO;
using Nikki.Utils;
using Nikki.Reflection.Abstract;
using Nikki.Reflection.Interface;
using Nikki.Reflection.Attributes;



namespace Nikki.Support.Underground1.Parts.PresetParts
{
	/// <summary>
	/// A unit <see cref="DecalArray"/> used in preset rides.
	/// </summary>
	public class DecalArray : ASubPart, ICopyable<DecalArray>
	{
		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DecalSlot0 { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DecalSlot1 { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DecalSlot2 { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DecalSlot3 { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DecalSlot4 { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DecalSlot5 { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DecalSlot6 { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DecalSlot7 { get; set; } = String.Empty;

		/// <summary>
		/// Creates a plain copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public DecalArray PlainCopy()
		{
			var result = new DecalArray();
			var ThisType = this.GetType();
			var ResultType = result.GetType();
			foreach (var ThisField in ThisType.GetProperties())
			{
				var ResultField = ResultType.GetProperty(ThisField.Name);
				ResultField.SetValue(result, ThisField.GetValue(this));
			}
			return result;
		}

		/// <summary>
		/// Reads data using <see cref="BinaryReader"/> provided.
		/// </summary>
		/// <param name="br"><see cref="BinaryReader"/> to read data with.</param>
		public void Read(BinaryReader br)
		{
			br.BaseStream.Position += 4;
			this.DecalSlot0 = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			br.BaseStream.Position += 4;
			this.DecalSlot1 = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			br.BaseStream.Position += 4;
			this.DecalSlot2 = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			br.BaseStream.Position += 4;
			this.DecalSlot3 = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			br.BaseStream.Position += 4;
			this.DecalSlot4 = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			br.BaseStream.Position += 4;
			this.DecalSlot5 = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			br.BaseStream.Position += 4;
			this.DecalSlot6 = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			br.BaseStream.Position += 4;
			this.DecalSlot7 = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
		}

		/// <summary>
		/// Writes data using <see cref="BinaryWriter"/> provided.
		/// </summary>
		/// <param name="bw"><see cref="BinaryWriter"/> to write data with.</param>
		/// <param name="start">Start car slot index.</param>
		public void Write(BinaryWriter bw, int start)
		{
			bw.Write(start + 0);
			bw.Write(this.DecalSlot0.BinHash());
			bw.Write(start + 1);
			bw.Write(this.DecalSlot1.BinHash());
			bw.Write(start + 2);
			bw.Write(this.DecalSlot2.BinHash());
			bw.Write(start + 3);
			bw.Write(this.DecalSlot3.BinHash());
			bw.Write(start + 4);
			bw.Write(this.DecalSlot4.BinHash());
			bw.Write(start + 5);
			bw.Write(this.DecalSlot5.BinHash());
			bw.Write(start + 6);
			bw.Write(this.DecalSlot6.BinHash());
			bw.Write(start + 7);
			bw.Write(this.DecalSlot7.BinHash());
		}
	}
}