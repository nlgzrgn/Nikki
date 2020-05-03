﻿using System;
using System.IO;
using Nikki.Core;
using Nikki.Utils;
using Nikki.Reflection.Abstract;
using Nikki.Reflection.Exception;
using Nikki.Reflection.Attributes;



namespace Nikki.Support.Underground2.Gameplay
{
	/// <summary>
	/// <see cref="GCarUnlock"/> is a collection of settings related to car unlock requirements.
	/// </summary>
	public class GCarUnlock : ACollectable
	{
		#region Fields

		private string _collection_name;

		#endregion

		#region Properties

		/// <summary>
		/// Game to which the class belongs to.
		/// </summary>
		public override GameINT GameINT => GameINT.Underground2;

		/// <summary>
		/// Game string to which the class belongs to.
		/// </summary>
		public override string GameSTR => GameINT.Underground2.ToString();

		/// <summary>
		/// Database to which the class belongs to.
		/// </summary>
		public Database.Underground2 Database { get; set; }

		/// <summary>
		/// Collection name of the variable.
		/// </summary>
		[AccessModifiable()]
		public override string CollectionName
		{
			get => this._collection_name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left left empty.");
				if (value.Contains(" "))
					throw new Exception("CollectionName cannot contain whitespace.");
				if (this.Database.GCarUnlocks.FindCollection(value) != null)
					throw new CollectionExistenceException();
				this._collection_name = value;
			}
		}

		/// <summary>
		/// Binary memory hash of the collection name.
		/// </summary>
		public uint BinKey => this._collection_name.BinHash();

		/// <summary>
		/// Vault memory hash of the collection name.
		/// </summary>
		public uint VltKey => this._collection_name.VltHash();

		/// <summary>
		/// One of the two required events completed to unlock the car.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public string ReqEventCompleted1 { get; set; }

		/// <summary>
		/// One of the two required events completed to unlock the car.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public string ReqEventCompleted2 { get; set; }

		#endregion

		#region Main

		/// <summary>
		/// Initializes new instance of <see cref="GCarUnlock"/>.
		/// </summary>
		public GCarUnlock() { }

		/// <summary>
		/// Initializes new instance of <see cref="GCarUnlock"/>.
		/// </summary>
		/// <param name="CName">CollectionName of the new instance.</param>
		/// <param name="db"><see cref="Database.Underground2"/> to which this instance belongs to.</param>
		public GCarUnlock(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this.CollectionName = CName;
			CName.BinHash();
		}

		/// <summary>
		/// Initializes new instance of <see cref="GCarUnlock"/>.
		/// </summary>
		/// <param name="br"><see cref="BinaryReader"/> to read data with.</param>
		/// <param name="db"><see cref="Database.Underground2"/> to which this instance belongs to.</param>
		public unsafe GCarUnlock(BinaryReader br, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(br);
		}

		/// <summary>
		/// Destroys current instance.
		/// </summary>
		~GCarUnlock() { }

		#endregion

		#region Methods

		/// <summary>
		/// Assembles <see cref="GCarUnlock"/> into a byte array.
		/// </summary>
		/// <param name="bw"><see cref="BinaryWriter"/> to write <see cref="GCarUnlock"/> with.</param>
		public void Assemble(BinaryWriter bw)
		{
			bw.Write(this.BinKey);
			bw.Write(this.ReqEventCompleted1.BinHash());
			bw.Write(this.ReqEventCompleted2.BinHash());
		}

		/// <summary>
		/// Disassembles array into <see cref="GCarUnlock"/> properties.
		/// </summary>
		/// <param name="br"><see cref="BinaryReader"/> to read <see cref="GCarUnlock"/> with.</param>
		public void Disassemble(BinaryReader br)
		{
			this._collection_name = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.ReqEventCompleted1 = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.ReqEventCompleted2 = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
		}

		/// <summary>
		/// Casts all attributes from this object to another one.
		/// </summary>
		/// <param name="CName">CollectionName of the new created object.</param>
		/// <returns>Memory casted copy of the object.</returns>
		public override ACollectable MemoryCast(string CName)
		{
			var result = new GCarUnlock(CName, this.Database)
			{
				ReqEventCompleted1 = this.ReqEventCompleted1,
				ReqEventCompleted2 = this.ReqEventCompleted2
			};

			return result;
		}

		/// <summary>
		/// Returns CollectionName, BinKey and GameSTR of this <see cref="BankTrigger"/> 
		/// as a string value.
		/// </summary>
		/// <returns>String value.</returns>
		public override string ToString()
		{
			return $"Collection Name: {this.CollectionName} | " +
				   $"BinKey: {this.BinKey.ToString("X8")} | Game: {this.GameSTR}";
		}

		#endregion
	}
}