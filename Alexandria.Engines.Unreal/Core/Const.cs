﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alexandria.Engines.Unreal.Core {
	/// <summary>
	/// A constant value.
	/// </summary>
	public class Const : Object {
		[PackageProperty(0, typeof(DataProcessors.AsciizByteLength))]
		public string Value { get; protected set; }
	}
}
