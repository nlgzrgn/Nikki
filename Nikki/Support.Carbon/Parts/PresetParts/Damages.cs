﻿using System;
using System.IO;
using Nikki.Utils;
using Nikki.Reflection.Abstract;
using Nikki.Reflection.Interface;
using Nikki.Reflection.Attributes;



namespace Nikki.Support.Carbon.Parts.PresetParts
{
	/// <summary>
	/// A unit <see cref="Damages"/> used in preset rides.
	/// </summary>
	public class Damages : ASubPart, ICopyable<Damages>
	{
		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageFrontWindow { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageBody { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageCopLights { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageCopSpoiler { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageFrontWheel { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageLeftBrakelight { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageRightBrakelight { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageLeftHeadlight { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageRightHeadlight { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageHood { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageBushguard { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageFrontBumper { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageRightDoor { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageRightRearDoor { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageTrunk { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageRearBumper { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageRearLeftWindow { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageFrontLeftWindow { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageFrontRightWindow { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageRearRightWindow { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageLeftDoor { get; set; } = String.Empty;

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public string DamageLeftRearDoor { get; set; } = String.Empty;

		/// <summary>
		/// Creates a plain copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public Damages PlainCopy()
		{
			var result = new Damages();
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
			this.DamageFrontWindow = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageBody = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageCopLights = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageCopSpoiler = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageFrontWheel = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageLeftBrakelight = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageRightBrakelight = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageLeftHeadlight = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageRightHeadlight = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageHood = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageBushguard = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageFrontBumper = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageRightDoor = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageRightRearDoor = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageTrunk = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageRearBumper = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageRearLeftWindow = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageFrontLeftWindow = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageFrontRightWindow = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageRearRightWindow = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageLeftDoor = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.DamageLeftRearDoor = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
		}

		/// <summary>
		/// Writes data using <see cref="BinaryWriter"/> provided.
		/// </summary>
		/// <param name="bw"><see cref="BinaryWriter"/> to read data with.</param>
		public void Write(BinaryWriter bw)
		{
			bw.Write(this.DamageFrontWindow.BinHash());
			bw.Write(this.DamageBody.BinHash());
			bw.Write(this.DamageCopLights.BinHash());
			bw.Write(this.DamageCopSpoiler.BinHash());
			bw.Write(this.DamageFrontWheel.BinHash());
			bw.Write(this.DamageLeftBrakelight.BinHash());
			bw.Write(this.DamageRightBrakelight.BinHash());
			bw.Write(this.DamageLeftHeadlight.BinHash());
			bw.Write(this.DamageRightHeadlight.BinHash());
			bw.Write(this.DamageHood.BinHash());
			bw.Write(this.DamageBushguard.BinHash());
			bw.Write(this.DamageFrontBumper.BinHash());
			bw.Write(this.DamageRightDoor.BinHash());
			bw.Write(this.DamageRightRearDoor.BinHash());
			bw.Write(this.DamageTrunk.BinHash());
			bw.Write(this.DamageRearBumper.BinHash());
			bw.Write(this.DamageRearLeftWindow.BinHash());
			bw.Write(this.DamageFrontLeftWindow.BinHash());
			bw.Write(this.DamageFrontRightWindow.BinHash());
			bw.Write(this.DamageRearRightWindow.BinHash());
			bw.Write(this.DamageLeftDoor.BinHash());
			bw.Write(this.DamageLeftRearDoor.BinHash());
		}
	}
}