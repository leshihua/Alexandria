﻿using Alexandria.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alexandria.Controls {
	public partial class MainWindow : Form {
		public readonly Manager Manager;

		public MainWindow(Manager manager) {
			Manager = manager;
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e) {
			BuildRecentFilesList();
		}

		private void fileToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			System.Windows.Forms.Application.Exit();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			var dialog = new OpenFileDialog() {
				Title = "Select file to open.",
				CheckFileExists = true,
			};

			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK) {
				Open(dialog.FileName);
			}
		}

		private void OnControlAdded(object sender, ControlEventArgs e) {
		}

		private void CloseMenuItem_Click(object sender, EventArgs e) {
			if (ActiveMdiChild != null)
				ActiveMdiChild.Close();
		}

		void BuildRecentFilesList() {
			RecentFilesMenuItem.DropDownItems.Clear();

			var list = Settings.Default.RecentFiles;
			for(int listIndex = list.Count - 1, index = 1; listIndex >= 0; listIndex--, index++) {
				string path = list[listIndex];
				string text = (index < 10 ? "&" : "") + index + " " + path;

				RecentFilesMenuItem.DropDownItems.Add(text, null, (clickSender, args) => {
					Open(path);
				});
			}
		}

		void Open(string path) {
			Resource resource = Manager.LoadFile(path);
			Control control = resource.Browse();

			if (control != null) {
				var window = new Form() {
					MdiParent = this,
					Text = Path.GetFileName(path),
				};

				control.Dock = DockStyle.Fill;
				window.Controls.Add(control);
				window.BringToFront();
				window.Show();

				if (MdiChildren.Length == 1)
					window.WindowState = FormWindowState.Maximized;

				if (Settings.Default.RecentFiles == null)
					Settings.Default.RecentFiles = new System.Collections.Specialized.StringCollection();
				Settings.Default.RecentFiles.Remove(path);
				Settings.Default.RecentFiles.Add(path);
				if (Settings.Default.RecentFiles.Count > 20)
					Settings.Default.RecentFiles.RemoveAt(0);
				Settings.Default.Save();
				BuildRecentFilesList();
			}
		}

		private void stackhorizontallyToolStripMenuItem_Click(object sender, EventArgs e) {
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void stackverticallyToolStripMenuItem_Click(object sender, EventArgs e) {
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void cascadeToolStripMenuItem_Click(object sender, EventArgs e) {
			LayoutMdi(MdiLayout.Cascade);
		}

		private void pluginsToolStripMenuItem_Click(object sender, EventArgs e) {
			var window = new PluginManager(Manager) {
				ShowInTaskbar = false,
			};

			window.Show(this);
		}
	}
}
