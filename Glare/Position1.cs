﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glare
{
/*
	/// <summary>
	/// A three-dimensional <see cref="Length"/> Vector3.
	/// </summary>
	public partial struct Vector3
	{
		/// <summary>
		/// Length along the X coordinate from the origin.
		/// </summary>
		public Length X;

		/// <summary>
		/// Length along the Y coordinate from the origin.
		/// </summary>
		public Length Y;

		/// <summary>
		/// Length along the Z coordinate from the origin.
		/// </summary>
		public Length Z;

		public Length Magnitude { get { return Length.Metres(Math.Sqrt(X.InMetres * X.InMetres + Y.InMetres * Y.InMetres + Z.InMetres * Z.InMetres)); } }

		public Vector3(Length x, Length y, Length z) { X = x; Y = y; Z = z; }

		public Vector3(Length value) { X = Y = Z = value; }

		public static readonly Vector3 Zero = Metres(0, 0, 0);


		public static Vector3 Universal(double x, double y, double z) { return new Vector3(Length.Universal(x), Length.Universal(y), Length.Universal(z)); }
		public static Vector3 Universal(double value) { return new Vector3(Length.Universal(value)); }
		public static Vector3 Universal(Vector3d value) { return new Vector3(Length.Universal(value.X), Length.Universal(value.Y), Length.Universal(value.Z)); }
		public static Vector3 Universal(ref Vector3d value) { return new Vector3(Length.Universal(value.X), Length.Universal(value.Y), Length.Universal(value.Z)); }

		public Vector3d InUniversal { get { return new Vector3d(X.InUniversal, Y.InUniversal, Z.InUniversal); } }

		public static Vector3 operator +(Vector3 Vector3) { return new Vector3(+Vector3.X, +Vector3.Y, +Vector3.Z); }
		public static Vector3 operator -(Vector3 Vector3) { return new Vector3(-Vector3.X, -Vector3.Y, -Vector3.Z); }

		public static Vector3 operator +(Vector3 a, Vector3 b) { return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z); }
		public static Vector3 operator +(Vector3 a, Length b) { return new Vector3(a.X + b, a.Y + b, a.Z + b); }
		public static Vector3 operator +(Length a, Vector3 b) { return new Vector3(a + b.X, a + b.Y, a + b.Z); }

		public static Vector3 operator -(Vector3 a, Vector3 b) { return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z); }
		public static Vector3 operator -(Vector3 a, Length b) { return new Vector3(a.X - b, a.Y - b, a.Z - b); }
		public static Vector3 operator -(Length a, Vector3 b) { return new Vector3(a - b.X, a - b.Y, a - b.Z); }

		public static Vector3 operator *(Vector3 a, Vector3d b) { return new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z); }
		public static Vector3 operator *(Vector3d a, Vector3 b) { return new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z); }
		public static Vector3 operator *(Vector3 a, double b) { return new Vector3(a.X * b, a.Y * b, a.Z * b); }
		public static Vector3 operator *(double a, Vector3 b) { return new Vector3(a * b.X, a * b.Y, a * b.Z); }

		public static Vector3 operator /(Vector3 a, Vector3d b) { return new Vector3(a.X / b.X, a.Y / b.Y, a.Z / b.Z); }
		public static Vector3 operator /(Vector3 a, double b) { return new Vector3(a.X / b, a.Y / b, a.Z / b); }

		public static Vector3d operator %(Vector3 a, Vector3 b) { return new Vector3d(a.X % b.X, a.Y % b.Y, a.Z % b.Z); }
		public static Vector3d operator %(Vector3 a, Length b) { return new Vector3d(a.X % b, a.Y % b, a.Z % b); }
	}
	*/
}


