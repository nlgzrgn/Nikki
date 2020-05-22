﻿using System;
using System.IO;
using Nikki.Core;
using Nikki.Utils;
using Nikki.Reflection.Enum;
using Nikki.Reflection.Abstract;
using Nikki.Reflection.Exception;
using Nikki.Reflection.Attributes;
using CoreExtensions.IO;
using CoreExtensions.Conversions;



namespace Nikki.Support.Underground1.Class
{
	/// <summary>
	/// <see cref="Track"/> is a collection of settings related to races and events.
	/// </summary>
	public class Track : Shared.Class.Track
	{
		#region Fields

		private string _collection_name;

		/// <summary>
		/// Maximum length of the CollectionName.
		/// </summary>
		public const int MaxCNameLength = 0x1F;

		/// <summary>
		/// Offset of the CollectionName in the data.
		/// </summary>
		public const int CNameOffsetAt = 0x20;

		/// <summary>
		/// Base size of a unit collection.
		/// </summary>
		public const int BaseClassSize = 0x128;

		#endregion

		#region Properties

		/// <summary>
		/// Game to which the class belongs to.
		/// </summary>
		public override GameINT GameINT => GameINT.Underground1;

		/// <summary>
		/// Game string to which the class belongs to.
		/// </summary>
		public override string GameSTR => GameINT.Underground1.ToString();

		/// <summary>
		/// Database to which the class belongs to.
		/// </summary>
		public Database.Underground1 Database { get; set; }

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
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value.Contains(" "))
					throw new Exception("CollectionName cannot contain whitespace.");
				if (!UInt16.TryParse(value, out ushort id))
					throw new Exception("Unable to parse TrackID from the collection name provided.");
				if (this.Database.Tracks.FindCollection(value) != null)
					throw new CollectionExistenceException();
				this._collection_name = value;
				this.TrackID = id;
			}
		}

		/// <summary>
		/// Binary memory hash of the collection name.
		/// </summary>
		public override uint BinKey => this._collection_name.BinHash();

		/// <summary>
		/// Vault memory hash of the collection name.
		/// </summary>
		public override uint VltKey => this._collection_name.VltHash();

		/// <summary>
		/// Unique ID value of the track that is used ingame.
		/// </summary>
		public ushort TrackID { get; private set; }

		/// <summary>
		/// Second race description name.
		/// </summary>
		[AccessModifiable()]
		public string RaceDescription2 { get; set; } = String.Empty;

		/// <summary>
		/// Total length of the whole track
		/// </summary>
		[AccessModifiable()]
		public uint RaceLength { get; set; }

		/// <summary>
		/// Indicates maximum time allowed to complete the race in forward direction.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public float TimeLimitToBeatForward { get; set; }

		/// <summary>
		/// Indicates maximum time allowed to complete the race in reverse direction.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public float TimeLimitToBeatReverse { get; set; }

		/// <summary>
		/// Indicates score needed to beat the drift race in forward direction.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public int ScoreToBeatDriftForward { get; set; }

		/// <summary>
		/// Indicates score needed to beat the drift race in reverse direction.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public int ScoreToBeatDriftReverse { get; set; }

		/// <summary>
		/// Indicates number of seconds that should pass before opponents can take first shortcut.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public short NumSecBeforeShorcutsAllowed { get; set; }

		/// <summary>
		/// Indicates minimum amount of seconds to drift.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public short DriftSecondsMin { get; set; }

		/// <summary>
		/// Indicates maximum amount of seconds to drift.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public short DriftSecondsMax { get; set; }

		/// <summary>
		/// Indicates configuration settings of the car at the start.
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public short CarRaceStartConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapCalibrationOffsetX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapCalibrationOffsetY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapCalibrationWidth { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapCalibrationRotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapStartgridAngle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public float TrackMapFinishlineAngle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_0_0 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_0_1 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_1_0 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_1_1 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_2_0 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_2_1 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_3_0 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public byte MaxTrafficCars_3_1 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public byte TrafAllowedNearStartgrid { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public byte TrafAllowedNearFinishline { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public float TrafMinInitDistFromStart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public float TrafMinInitDistFromFinish { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public float TrafMinInitDistInbetweenA { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[AccessModifiable()]
		[StaticModifiable()]
		public float TrafMinInitDistInbetweenB { get; set; }

		#endregion

		#region Main

		/// <summary>
		/// Initializes new instance of <see cref="Track"/>.
		/// </summary>
		public Track() { }

		/// <summary>
		/// Initializes new instance of <see cref="Track"/>.
		/// </summary>
		/// <param name="CName">CollectionName of the new instance.</param>
		/// <param name="db"><see cref="Database.Underground1"/> to which this instance belongs to.</param>
		public Track(string CName, Database.Underground1 db)
		{
			this.Database = db;
			this.CollectionName = CName;
			CName.BinHash();
		}

		/// <summary>
		/// Initializes new instance of <see cref="Track"/>.
		/// </summary>
		/// <param name="br"><see cref="BinaryReader"/> to read data with.</param>
		/// <param name="db"><see cref="Database.Underground1"/> to which this instance belongs to.</param>
		public Track(BinaryReader br, Database.Underground1 db)
		{
			this.Database = db;
			this.Disassemble(br);
		}

		/// <summary>
		/// Destroys current instance.
		/// </summary>
		~Track() { }

		#endregion

		#region Methods

		/// <summary>
		/// Assembles <see cref="Track"/> into a byte array.
		/// </summary>
		/// <param name="bw"><see cref="BinaryWriter"/> to write <see cref="Track"/> with.</param>
		public override void Assemble(BinaryWriter bw)
		{
			// Write all directories and locations
			bw.WriteNullTermUTF8(this.RaceDescription, 0x20);
			bw.WriteNullTermUTF8(this.TrackDirectory, 0x20);
			bw.WriteNullTermUTF8(this.RegionName, 0x8);
			bw.WriteNullTermUTF8(this.RegionDirectory, 0x20);

			// Write race settings
			bw.WriteEnum(this.IsValid);
			bw.Write(this.IsLoopingRace == eBoolean.True ? (byte)0 : (byte)1);
			bw.Write(this.ReverseVersionExists == eBoolean.True ? (byte)2 : (byte)0);
			bw.Write((byte)0);
			bw.Write(this.TrackID);
			bw.Write(this.TrackID);

			// Write gameplay scores
			bw.Write(this.SunInfoName.BinHash());
			bw.WriteEnum(this.RaceGameplayMode);
			bw.Write(this.RaceLength);
			bw.Write(this.TimeLimitToBeatForward);
			bw.Write(this.TimeLimitToBeatReverse);
			bw.Write(this.ScoreToBeatDriftForward);
			bw.Write(this.ScoreToBeatDriftReverse);

			// Write map calibrations
			bw.Write(this.TrackMapCalibrationOffsetX);
			bw.Write(this.TrackMapCalibrationOffsetY);
			bw.Write(this.TrackMapCalibrationWidth);
			bw.Write((ushort)(this.TrackMapCalibrationRotation / 180 * 32768));
			bw.Write((ushort)(this.TrackMapStartgridAngle / 180 * 32768));
			bw.Write((ushort)(this.TrackMapFinishlineAngle / 180 * 32768));
			bw.Write((short)0);

			// Write difficulties and padding
			bw.Write((int)this.DifficultyForward);
			bw.Write((int)this.DifficultyReverse);
			bw.Write(-1);
			bw.Write(-1);
			bw.Write(-1);
			bw.Write(-1);
			bw.Write(this.NumSecBeforeShorcutsAllowed);
			bw.Write(this.DriftSecondsMin);
			bw.Write(this.DriftSecondsMax);
			bw.Write((short)0);

			// Write traffic settings
			bw.Write(this.MaxTrafficCars_0_0);
			bw.Write(this.MaxTrafficCars_0_1);
			bw.Write(this.MaxTrafficCars_1_0);
			bw.Write(this.MaxTrafficCars_1_1);
			bw.Write(this.MaxTrafficCars_2_0);
			bw.Write(this.MaxTrafficCars_2_1);
			bw.Write(this.MaxTrafficCars_3_0);
			bw.Write(this.MaxTrafficCars_3_1);
			bw.Write(this.TrafAllowedNearStartgrid);
			bw.Write(this.TrafAllowedNearFinishline);
			bw.Write(this.CarRaceStartConfig);
			bw.Write(this.TrafMinInitDistFromStart);
			bw.Write(this.TrafMinInitDistFromFinish);
			bw.Write(this.TrafMinInitDistInbetweenA);
			bw.Write(this.TrafMinInitDistInbetweenB);

			// Write second description name
			bw.WriteNullTermUTF8(this.RaceDescription2, 0x20);
		}

		/// <summary>
		/// Disassembles array into <see cref="Track"/> properties.
		/// </summary>
		/// <param name="br"><see cref="BinaryReader"/> to read <see cref="Track"/> with.</param>
		public override void Disassemble(BinaryReader br)
		{
			// Read all directories and locations
			this.RaceDescription = br.ReadNullTermUTF8(0x20);
			this.TrackDirectory = br.ReadNullTermUTF8(0x20);
			this.RegionName = br.ReadNullTermUTF8(0x8);
			this.RegionDirectory = br.ReadNullTermUTF8(0x20);

			// Read race settings
			this.IsValid = br.ReadEnum<eBoolean>();
			this.IsLoopingRace = br.ReadByte() == 0 ? eBoolean.True : eBoolean.False;
			this.ReverseVersionExists = br.ReadByte() == 2 ? eBoolean.True : eBoolean.False;
			br.BaseStream.Position += 1;
			this._collection_name = br.ReadUInt16().ToString();
			this.TrackID = br.ReadUInt16();

			// Read gameplay scores
			this.SunInfoName = br.ReadUInt32().BinString(eLookupReturn.EMPTY);
			this.RaceGameplayMode = br.ReadEnum<eRaceGameplayMode>();
			this.RaceLength = br.ReadUInt32();
			this.TimeLimitToBeatForward = br.ReadSingle();
			this.TimeLimitToBeatReverse = br.ReadSingle();
			this.ScoreToBeatDriftForward = br.ReadInt32();
			this.ScoreToBeatDriftReverse = br.ReadInt32();

			// Read map calibrations
			this.TrackMapCalibrationOffsetX = br.ReadSingle();
			this.TrackMapCalibrationOffsetY = br.ReadSingle();
			this.TrackMapCalibrationWidth = br.ReadSingle();
			this.TrackMapCalibrationRotation = ((float)br.ReadUInt16()) * 180 / 32768;
			this.TrackMapStartgridAngle = ((float)br.ReadUInt16()) * 180 / 32768;
			this.TrackMapFinishlineAngle = ((float)br.ReadUInt16()) * 180 / 32768;
			br.BaseStream.Position += 2;

			// Read difficulties and padding
			this.DifficultyForward = (eTrackDifficulty)(br.ReadInt32());
			this.DifficultyReverse = (eTrackDifficulty)(br.ReadInt32());
			br.BaseStream.Position += 0x10;
			this.NumSecBeforeShorcutsAllowed = br.ReadInt16();
			this.DriftSecondsMin = br.ReadInt16();
			this.DriftSecondsMax = br.ReadInt16();
			br.BaseStream.Position += 2;

			// Read traffic settings
			this.MaxTrafficCars_0_0 = br.ReadByte();
			this.MaxTrafficCars_0_1 = br.ReadByte();
			this.MaxTrafficCars_1_0 = br.ReadByte();
			this.MaxTrafficCars_1_1 = br.ReadByte();
			this.MaxTrafficCars_2_0 = br.ReadByte();
			this.MaxTrafficCars_2_1 = br.ReadByte();
			this.MaxTrafficCars_3_0 = br.ReadByte();
			this.MaxTrafficCars_3_1 = br.ReadByte();
			this.TrafAllowedNearStartgrid = br.ReadByte();
			this.TrafAllowedNearFinishline = br.ReadByte();
			this.CarRaceStartConfig = br.ReadInt16();
			this.TrafMinInitDistFromStart = br.ReadSingle();
			this.TrafMinInitDistFromFinish = br.ReadSingle();
			this.TrafMinInitDistInbetweenA = br.ReadSingle();
			this.TrafMinInitDistInbetweenB = br.ReadSingle();

			// Read second race description
			this.RaceDescription2 = br.ReadNullTermUTF8(0x20);
		}

		/// <summary>
		/// Casts all attributes from this object to another one.
		/// </summary>
		/// <param name="CName">CollectionName of the new created object.</param>
		/// <returns>Memory casted copy of the object.</returns>
		public override ACollectable MemoryCast(string CName)
		{
			var result = new Track(CName, this.Database)
			{
				DifficultyForward = this.DifficultyForward,
				DifficultyReverse = this.DifficultyReverse,
				IsLoopingRace = this.IsLoopingRace,
				IsValid = this.IsValid,
				RaceDescription = this.RaceDescription,
				RaceDescription2 = this.RaceDescription2,
				RegionDirectory = this.RegionDirectory,
				RegionName = this.RegionName,
				TrackDirectory = this.TrackDirectory,
				RaceGameplayMode = this.RaceGameplayMode,
				ReverseVersionExists = this.ReverseVersionExists,
				SunInfoName = this.SunInfoName,
				CarRaceStartConfig = this.CarRaceStartConfig,
				RaceLength = this.RaceLength,
				TimeLimitToBeatForward = this.TimeLimitToBeatForward,
				TimeLimitToBeatReverse = this.TimeLimitToBeatReverse,
				ScoreToBeatDriftForward = this.ScoreToBeatDriftForward,
				ScoreToBeatDriftReverse = this.ScoreToBeatDriftReverse,
				NumSecBeforeShorcutsAllowed = this.NumSecBeforeShorcutsAllowed,
				DriftSecondsMax = this.DriftSecondsMax,
				DriftSecondsMin = this.DriftSecondsMin,
				TrackMapCalibrationOffsetX = this.TrackMapCalibrationOffsetX,
				TrackMapCalibrationOffsetY = this.TrackMapCalibrationOffsetY,
				TrackMapCalibrationRotation = this.TrackMapCalibrationRotation,
				TrackMapCalibrationWidth = this.TrackMapCalibrationWidth,
				TrackMapFinishlineAngle = this.TrackMapFinishlineAngle,
				TrackMapStartgridAngle = this.TrackMapStartgridAngle,
				MaxTrafficCars_0_0 = this.MaxTrafficCars_0_0,
				MaxTrafficCars_0_1 = this.MaxTrafficCars_0_1,
				MaxTrafficCars_1_0 = this.MaxTrafficCars_1_0,
				MaxTrafficCars_1_1 = this.MaxTrafficCars_1_1,
				MaxTrafficCars_2_0 = this.MaxTrafficCars_2_0,
				MaxTrafficCars_2_1 = this.MaxTrafficCars_2_1,
				MaxTrafficCars_3_0 = this.MaxTrafficCars_3_0,
				MaxTrafficCars_3_1 = this.MaxTrafficCars_3_1,
				TrafAllowedNearFinishline = this.TrafAllowedNearFinishline,
				TrafAllowedNearStartgrid = this.TrafAllowedNearStartgrid,
				TrafMinInitDistFromFinish = this.TrafMinInitDistFromFinish,
				TrafMinInitDistFromStart = this.TrafMinInitDistFromStart,
				TrafMinInitDistInbetweenA = this.TrafMinInitDistInbetweenA,
				TrafMinInitDistInbetweenB = this.TrafMinInitDistInbetweenB,
			};

			return result;
		}

		/// <summary>
		/// Returns CollectionName, BinKey and GameSTR of this <see cref="Track"/> 
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