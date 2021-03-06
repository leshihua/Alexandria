﻿using Glare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alexandria.Engines.Unreal.Core {
	/// <summary>
	/// 
	/// </summary>
	public class Model : RootObject {
		/// <summary>
		/// 
		/// </summary>
		public class Node : RootObject {
			/// <summary></summary>
			[PackageProperty(0)]
			public Plane3f Plane { get; protected set; }

			/// <summary></summary>
			[PackageProperty(1)]
			public ulong ZoneMask { get; protected set; }

			/// <summary></summary>
			[PackageProperty(2)]
			public byte Flags { get; protected set; }

			/// <summary></summary>
			[PackageProperty(3, typeof(DataProcessors.IndexInt))]
			public int VertexPoolIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(4, typeof(DataProcessors.IndexInt))]
			public int SurfaceIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(5, typeof(DataProcessors.IndexInt))]
			public int FrontIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(6, typeof(DataProcessors.IndexInt))]
			public int BackIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(7, typeof(DataProcessors.IndexInt))]
			public int PlaneIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(8, typeof(DataProcessors.IndexInt))]
			public int CollisionBoundIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(9, typeof(DataProcessors.IndexInt))]
			public int RenderBoundIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(10)]
			public byte ZoneA { get; protected set; }

			/// <summary></summary>
			[PackageProperty(11)]
			public byte ZoneB { get; protected set; }

			/// <summary></summary>
			[PackageProperty(12)]
			public byte VertexCount { get; protected set; }

			/// <summary></summary>
			[PackageProperty(13)]
			public int LeafA { get; protected set; }

			/// <summary></summary>
			[PackageProperty(14)]
			public int LeafB { get; protected set; }
		}

		/// <summary></summary>
		public class Surface : RootObject {
			/// <summary></summary>
			[PackageProperty(0)]
			public Reference TextureReference { get; protected set; }

			/// <summary></summary>
			[PackageProperty(1)]
			public int Flags { get; protected set; }

			/// <summary></summary>
			[PackageProperty(2, typeof(DataProcessors.IndexInt))]
			public int BaseIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(3, typeof(DataProcessors.IndexInt))]
			public int NormalIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(4, typeof(DataProcessors.IndexInt))]
			public int TextureUIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(5, typeof(DataProcessors.IndexInt))]
			public int TextureVIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(6)]
			public Reference LightMapReference { get; protected set; }

			/// <summary></summary>
			[PackageProperty(7)]
			public Reference BrushPolygonReference { get; protected set; }

			/// <summary></summary>
			[PackageProperty(8)]
			public ushort PanU { get; protected set; }

			/// <summary></summary>
			[PackageProperty(9)]
			public ushort PanV { get; protected set; }

			/// <summary></summary>
			[PackageProperty(10)]
			public Reference ActorReference { get; protected set; }
		}

		/// <summary></summary>
		public struct Vertex {
			/// <summary></summary>
			public int VertexIndex;

			/// <summary></summary>
			public int SideIndex;

			/// <summary></summary>
			public override string ToString() {
				return "Vertex(Vertex: " + VertexIndex + ", Side: " + SideIndex + ")";
			}
		}

		/// <summary></summary>
		public class Zone : RootObject {
			/// <summary></summary>
			[PackageProperty(0)]
			public Reference ActorReference { get; protected set; }

			/// <summary></summary>
			[PackageProperty(1)]
			public ulong Connectivity { get; protected set; }

			/// <summary></summary>
			[PackageProperty(2)]
			public ulong Visibility { get; protected set; }
		}

		/// <summary></summary>
		public class LightMap : RootObject {
			/// <summary></summary>
			[PackageProperty(0)]
			public int DataOffset { get; protected set; }

			/// <summary></summary>
			[PackageProperty(1)]
			public Vector3f Pan { get; protected set; }

			/// <summary></summary>
			[PackageProperty(2, typeof(DataProcessors.IndexInt))]
			public int UClamp { get; protected set; }

			/// <summary></summary>
			[PackageProperty(3, typeof(DataProcessors.IndexInt))]
			public int VClamp { get; protected set; }

			/// <summary></summary>
			[PackageProperty(4)]
			public Vector2f Scale { get; protected set; }

			/// <summary></summary>
			[PackageProperty(5)]
			public int LightActorsIndex { get; protected set; }
		}

		/// <summary></summary>
		public class Leaf : RootObject {
			/// <summary></summary>
			[PackageProperty(0, typeof(DataProcessors.IndexInt))]
			public int ZoneIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(1, typeof(DataProcessors.IndexInt))]
			public int PermeatingIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(2, typeof(DataProcessors.IndexInt))]
			public int VolumetricIndex { get; protected set; }

			/// <summary></summary>
			[PackageProperty(3)]
			public ulong VisibleZones { get; protected set; }
		}

		/// <summary></summary>
		[PackageProperty(0)]
		public AttributeDictionary Attributes { get; protected set; }

		/// <summary></summary>
		[PackageProperty(1)]
		public Bounds BoundingBox { get; protected set; }

		/// <summary></summary>
		[PackageProperty(2)]
		public Sphere3f BoundingSphere { get; protected set; }

		/// <summary></summary>
		[PackageProperty(3)]
		public Vector3f[] Vectors { get; protected set; }

		/// <summary></summary>
		[PackageProperty(4)]
		public Vector3f[] Points { get; protected set; }

		/// <summary></summary>
		[PackageProperty(5, typeof(DataProcessors.List<Node>))]
		public List<Node> Nodes { get; protected set; }

		/// <summary></summary>
		[PackageProperty(6, typeof(DataProcessors.List<Surface>))]
		public List<Surface> Surfaces { get; protected set; }

		/// <summary></summary>
		[PackageProperty(7, typeof(VertexReader))]
		public Vertex[] Vertices { get; protected set; }

		/// <summary></summary>
		[PackageProperty(8)]
		public int SharedSideCount { get; protected set; }

		/// <summary></summary>
		[PackageProperty(9, typeof(DataProcessors.ListInt32Count<Zone>))]
		public List<Zone> Zones { get; protected set; }

		/// <summary></summary>
		[PackageProperty(10)]
		public Reference PolygonsReference { get; protected set; }

		/// <summary></summary>
		[PackageProperty(11, typeof(DataProcessors.List<LightMap>))]
		public List<LightMap> LightMaps { get; protected set; }

		/// <summary></summary>
		[PackageProperty(12)]
		public byte[] LightBits { get; protected set; }

		/// <summary></summary>
		[PackageProperty(13, typeof(BoundsListReader))]
		public List<Bounds> Bounds { get; protected set; }

		/// <summary></summary>
		[PackageProperty(14)]
		public int[] LeafHulls { get; protected set; }

		/// <summary></summary>
		[PackageProperty(15, typeof(DataProcessors.List<Leaf>))]
		public List<Leaf> Leaves { get; protected set; }

		/// <summary></summary>
		[PackageProperty(16)]
		public List<Reference> Lights { get; protected set; }

		/// <summary></summary>
		[PackageProperty(17)]
		public int RootOutside { get; protected set; }

		/// <summary></summary>
		[PackageProperty(18)]
		public int Linked { get; protected set; }

		class BoundsListReader : DataProcessor {
			public override object Read(object target, Package package, System.IO.BinaryReader reader, long end) {
				var count = UIndex.Read(reader);
				var list = new List<Bounds>(count);

				while (count-- > 0)
					list.Add(Alexandria.Engines.Unreal.Bounds.Read(reader));
				return list;
			}
		}

		class VertexReader : DataProcessor {
			public override object Read(object target, Package package, System.IO.BinaryReader reader, long end) {
				int count = UIndex.Read(reader);

				if (count == 0)
					return null;
				var list = new Vertex[count];

				for (var index = 0; index < count; index++)
					list[index] = new Vertex() {
						VertexIndex = UIndex.Read(reader),
						SideIndex = UIndex.Read(reader)
					};
				return list;
			}
		}
	}
}
