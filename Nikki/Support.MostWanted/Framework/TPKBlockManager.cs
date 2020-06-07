﻿using System;
using System.IO;
using Nikki.Core;
using Nikki.Utils;
using Nikki.Reflection.Enum;
using Nikki.Reflection.Exception;
using Nikki.Support.MostWanted.Class;
using CoreExtensions.IO;



namespace Nikki.Support.MostWanted.Framework
{
	/// <summary>
	/// A <see cref="Manager{T}"/> for <see cref="TPKBlock"/> collections.
	/// </summary>
	public class TPKBlockManager : Manager<TPKBlock>
	{
		/// <summary>
		/// Name of this <see cref="TPKBlockManager"/>.
		/// </summary>
		public override string Name => "TPKBlocks";

		/// <summary>
		/// True if this <see cref="Manager{T}"/> is read-only; otherwise, false.
		/// </summary>
		public override bool IsReadOnly => false;

		/// <summary>
		/// Indicates required alighment when this <see cref="TPKBlockManager"/> is being serialized.
		/// </summary>
		public override Alignment Alignment { get; }

		/// <summary>
		/// Initializes new instance of <see cref="TPKBlockManager"/>.
		/// </summary>
		/// <param name="db"><see cref="Datamap"/> to which this manager belongs to.</param>
		public TPKBlockManager(Datamap db)
		{
			this.Database = db;
			this.Extender = 1;
			this.Alignment = new Alignment(0x80, Alignment.eAlignType.Modular);
		}

		/// <summary>
		/// Assembles collection data into byte buffers.
		/// </summary>
		/// <param name="bw"><see cref="BinaryWriter"/> to write data with.</param>
		/// <param name="mark">Watermark to put in the padding blocks.</param>
		internal override void Assemble(BinaryWriter bw, string mark)
		{
			if (this.Count == 0) return;

			foreach (var collection in this)
			{
				bw.GeneratePadding(mark, this.Alignment);

				if (collection.SettingData != null)
				{

					bw.WriteEnum(eBlockID.TPKSettings);
					bw.Write(collection.SettingData.Length);
					bw.Write(collection.SettingData);
					bw.GeneratePadding(mark, this.Alignment);

				}

				collection.Assemble(bw);

			}
		}

		/// <summary>
		/// Disassembles data into separate collections in this <see cref="PresetRideManager"/>.
		/// </summary>
		/// <param name="br"><see cref="BinaryReader"/> to read data with.</param>
		/// <param name="block"><see cref="Block"/> with offsets.</param>
		internal override void Disassemble(BinaryReader br, Block block)
		{
			if (Block.IsNullOrEmpty(block)) return;
			if (block.BlockID != eBlockID.TPKBlocks) return;

			this.Capacity = block.Offsets.Count;
			byte[] settings = null;

			for (int loop = 0; loop < block.Offsets.Count; ++loop)
			{

				br.BaseStream.Position = block.Offsets[loop];
				var id = br.ReadEnum<eBlockID>();
				var size = br.ReadInt32();

				if (id == eBlockID.TPKSettings)
				{

					settings = br.ReadBytes(size);
					continue;

				}
				else if (id == eBlockID.TPKBlocks)
				{

					br.BaseStream.Position -= 8;

					var collection = new TPKBlock(br, this)
					{
						SettingData = settings
					};
					
					this.Add(collection);

				}

			}
		}

		/// <summary>
		/// Checks whether CollectionName provided allows creation of a new collection.
		/// </summary>
		/// <param name="cname">CollectionName to check.</param>
		internal override void CreationCheck(string cname)
		{
			if (String.IsNullOrWhiteSpace(cname))
			{

				throw new ArgumentNullException("CollectionName cannot be null, empty or whitespace");

			}

			if (cname.Contains(" "))
			{

				throw new ArgumentException("CollectionName cannot contain whitespace");

			}

			if (cname.Length > 0x40)
			{

				throw new ArgumentLengthException(0x40);

			}

			if (this.Find(cname) != null)
			{

				throw new CollectionExistenceException(cname);

			}
		}
	}
}