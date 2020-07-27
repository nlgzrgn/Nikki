﻿using System.IO;
using Nikki.Reflection.Abstract;
using Nikki.Reflection.Attributes;



namespace Nikki.Support.Carbon.Parts.VinylParts
{
	/// <summary>
	/// A unit <see cref="InnerShadowEffect"/> that is used in <see cref="PathSet"/>.
	/// </summary>
	public class InnerShadowEffect : SubPart
	{
		/// <summary>
		/// Red color of the effect.
		/// </summary>
		[AccessModifiable()]
		public byte Red { get; set; }

		/// <summary>
		/// Green color of the effect.
		/// </summary>
		[AccessModifiable()]
		public byte Green { get; set; }

		/// <summary>
		/// Blue color of the effect.
		/// </summary>
		[AccessModifiable()]
		public byte Blue { get; set; }

		/// <summary>
		/// Alpha color of the effect.
		/// </summary>
		[AccessModifiable()]
		public byte Alpha { get; set; }

		/// <summary>
		/// Disperse U coordinate of the effect.
		/// </summary>
		[AccessModifiable()]
		public float DisperseU { get; set; }

		/// <summary>
		/// Disperse V coordinate of the effect.
		/// </summary>
		[AccessModifiable()]
		public float DisperseV { get; set; }

		/// <summary>
		/// Size of the effect.
		/// </summary>
		[AccessModifiable()]
		public float Size { get; set; }

		/// <summary>
		/// Choke value of the effect.
		/// </summary>
		[AccessModifiable()]
		public float Choke { get; set; }

		/// <summary>
		/// Creates a plain copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public override SubPart PlainCopy()
		{
			var result = new InnerShadowEffect();
			result.CloneValuesFrom(this);
			return result;
		}

		/// <summary>
		/// Reads data using <see cref="BinaryReader"/> provided.
		/// </summary>
		/// <param name="br"><see cref="BinaryReader"/> to read data with.</param>
		public void Read(BinaryReader br)
		{
			this.Red = br.ReadByte();
			this.Green = br.ReadByte();
			this.Blue = br.ReadByte();
			this.Alpha = br.ReadByte();
			this.DisperseU = br.ReadSingle();
			this.DisperseV = br.ReadSingle();
			this.Size = br.ReadSingle();
			this.Choke = br.ReadSingle();
		}

		/// <summary>
		/// Writes data using <see cref="BinaryWriter"/> provided.
		/// </summary>
		/// <param name="bw"><see cref="BinaryWriter"/> to write data with.</param>
		public void Write(BinaryWriter bw)
		{
			bw.Write(this.Red);
			bw.Write(this.Green);
			bw.Write(this.Blue);
			bw.Write(this.Alpha);
			bw.Write(this.DisperseU);
			bw.Write(this.DisperseV);
			bw.Write(this.Size);
			bw.Write(this.Choke);
		}
	}
}