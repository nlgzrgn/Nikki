﻿using System.IO;
using Nikki.Reflection.Enum;
using Nikki.Reflection.Abstract;
using Nikki.Reflection.Attributes;
using CoreExtensions.IO;



namespace Nikki.Support.Underground2.Parts.InfoParts
{
	/// <summary>
	/// A unit <see cref="Camera"/> used in car performance.
	/// </summary>
	public class Camera : SubPart
	{
		/// <summary>
		/// 
		/// </summary>
		internal eCameraType CameraType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public float CameraAngle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public float CameraLag { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public float CameraHeight { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		public float CameraLatOffset { get; set; }

		/// <summary>
		/// Initializes new instance of <see cref="Camera"/>.
		/// </summary>
		public Camera() { }

		/// <summary>
		/// Creates a plain copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public override SubPart PlainCopy()
		{
			var result = new Camera();

			foreach (var property in this.GetType().GetProperties())
			{

				property.SetValue(result, property.GetValue(this));

			}

			return result;
		}

		/// <summary>
		/// Reads data using <see cref="BinaryReader"/> provided.
		/// </summary>
		/// <param name="br"><see cref="BinaryReader"/> to read data with.</param>
		public void Read(BinaryReader br)
		{
			this.CameraType = br.ReadEnum<eCameraType>();
			this.CameraAngle = ((float)br.ReadInt16()) * 180 / 32768;
			this.CameraLag = br.ReadSingle();
			this.CameraHeight = br.ReadSingle();
			this.CameraLatOffset = br.ReadSingle();
		}

		/// <summary>
		/// Writes data using <see cref="BinaryWriter"/> provided.
		/// </summary>
		/// <param name="bw"><see cref="BinaryWriter"/> to write data with.</param>
		public void Write(BinaryWriter bw)
		{
			bw.WriteEnum(this.CameraType);
			bw.Write((short)(this.CameraAngle / 180 * 32768));
			bw.Write(this.CameraLag);
			bw.Write(this.CameraHeight);
			bw.Write(this.CameraLatOffset);
		}
	}
}