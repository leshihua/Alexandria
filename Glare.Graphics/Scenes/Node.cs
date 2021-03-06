﻿using Glare.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glare.Graphics.Scenes {
	/// <summary>
	/// A scene node.
	/// </summary>
	public class Node : SceneObject {
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		readonly Codex<Node> children = new Codex<Node>();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Node parent;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Vector3d translation;

		/// <summary>Get the children of the <see cref="Node"/>.</summary>
		public ReadOnlyCodex<Node> Children { get { return children; } }

		/// <summary>Get the components of the <see cref="Node"/>.</summary>
		public NodeComponentCollection Components { get; private set; }

		/// <summary>Get or set the name of the <see cref="Node"/>.</summary>
		public string Name { get; set; }

		public Node Parent {
			get { return parent; }

			set {
				parent = value;
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Get or set the <see cref="Node"/>'s translation.
		/// </summary>
		public Vector3d Translation {
			get { return translation; }
			set { SetProperty(TranslationChangingArgs, TranslationChangedArgs, ref translation, ref value); }
		}

		const string
			TranslationName = "Translation";

		static readonly PropertyChangingEventArgs
			TranslationChangingArgs = new PropertyChangingEventArgs(TranslationName);

		static readonly PropertyChangedEventArgs
			TranslationChangedArgs = new PropertyChangedEventArgs(TranslationName);

		/// <summary>
		/// Initialize the node.
		/// </summary>
		public Node() {
			Components = new NodeComponentCollection(this);
		}
	}

	/// <summary>
	/// A collection of <see cref="Component"/>s in a <see cref="Node"/>.
	/// </summary>
	public class NodeComponentCollection : Codex<Component> {
		readonly Node Node;

		internal NodeComponentCollection(Node node) {
			Node = node;
		}

		/// <summary>Add a <see cref="Component"/> to the collection.</summary>
		/// <param name="item"></param>
		public override void Add(Component item) {
			Insert(Count, item);
		}

		/// <summary>Remove all components from the <see cref="Node"/>.</summary>
		public override void Clear() {
			while (Count > 0)
				RemoveAt(Count - 1);
		}

		/// <summary>Remove all components from the <see cref="Node"/>.</summary>
		public override void ClearFast() {
			Clear();
		}

		/// <summary>Insert a <see cref="Component"/> into the <see cref="Node"/></summary>
		/// <param name="index">The index to insert at.</param>
		/// <param name="item">The <see cref="Component"/> to add.</param>
		public override void Insert(int index, Component item) {
			if (item == null)
				throw new ArgumentNullException("item");
			if (item.Node != null)
				throw new ArgumentException(string.Format("The {0} has already been added to a {1}.", typeof(Component).Name, typeof(Node).Name));

			base.Insert(index, item);
			item.Node = Node;
		}

		/// <summary>Remove a <see cref="Component"/> from the <see cref="Node"/>.</summary>
		/// <param name="index"></param>
		public override void RemoveAt(int index) {
			base.RemoveAt(index);
		}
	}
}
