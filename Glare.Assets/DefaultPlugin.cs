﻿using Glare.Assets.Formats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glare.Assets {
	class DefaultPlugin : AssetPlugin {
		public DefaultPlugin(AssetManager manager)
			: base(manager, Properties.Resources.ResourceManager) {
			AddFormat(new BinaryFormat(this));

			AddFormat(new DdsFormat(this));
			AddFormat(new PcxFormat(this));
			AddFormat(new ZipFormat(this));
			//AddFormat(new Autodesk3dsFormat(this));
		}

		class BinaryFormat : AssetFormat {
			public BinaryFormat(DefaultPlugin plugin) : base(plugin, typeof(BinaryAsset), canLoad: true) { }

			public override LoadMatchStrength LoadMatch(AssetLoader context) {
				return LoadMatchStrength.Fallback - 2;
			}

			public override Asset Load(AssetLoader context) {
				return new BinaryAsset(Manager, context.Name, context.Reader.ReadBytes(checked((int)Math.Min(context.Length, 10 * 1024 * 1024))), 0);
			}
		}
	}
}
