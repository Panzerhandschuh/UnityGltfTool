using glTFLoader;
using glTFLoader.Schema;
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
using UnityGltfTool.UserControls;
using UnityGltfTool.Utils;

namespace UnityGltfTool
{
	public partial class Form1 : Form
	{
		private Gltf gltf;
		private ColliderManager colliderManager;

		public Form1()
		{
			InitializeComponent();

			colliderTypeProperty.DataSource = Enum.GetValues(typeof(ColliderType));
			colliderTypeProperty.PropertyChanged += ColliderType_SelectedIndexChanged;
		}

		private void ColliderType_SelectedIndexChanged(object sender, EventArgs e)
		{
			ResetColliderOptions();

			var nodeIndex = nodeListBox.SelectedIndex;
			var type = (ColliderType)colliderTypeProperty.PropertyValue;
			if (type == ColliderType.None)
				colliderManager.RemoveCollider(nodeIndex);
			else
			{
				var collider = colliderManager.GetOrAddCollider(nodeIndex);
				if (collider.GetColliderType() != type)
					collider.SetColliderType(type);

				var displayer = new ColliderOptionsDisplayer(colliderTypeOptionsPanel, collider);

				switch (type)
				{
					case ColliderType.Box:
						displayer.DisplayBoxOptions();
						break;
					case ColliderType.Sphere:
						displayer.DisplaySphereOptions();
						break;
					case ColliderType.Capsule:
						displayer.DisplayCapsuleOptions();
						break;
					case ColliderType.Mesh:
						{
							var meshes = new string[gltf.Meshes.Length];
							for (int i = 0; i < gltf.Meshes.Length; i++)
								meshes[i] = GetMeshName(gltf.Meshes[i], i);
							displayer.DisplayMeshOptions(meshes);
							break;
						}
				}
			}
		}

		private string GetMeshName(Mesh mesh, int index)
		{
			return mesh.Name ?? $"Mesh{index}";
		}

		private void ResetColliderOptions()
		{
			colliderTypeOptionsPanel.Controls.Clear();
		}

		private void GltfFileBrowse_Click(object sender, EventArgs e)
		{
			var result = gltfFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				var file = gltfFileDialog.FileName;

				// Ignore text change event
				gltfFileTextBox.TextChanged -= GltfFileTextBox_TextChanged;
				gltfFileTextBox.Text = file;
				gltfFileTextBox.TextChanged += GltfFileTextBox_TextChanged;

				ReloadGltfFile();
			}
		}

		private void GltfFileTextBox_TextChanged(object sender, EventArgs e)
		{
			ReloadGltfFile();
		}

		private void ReloadGltfFile()
		{
			var file = gltfFileTextBox.Text;
			if (File.Exists(file) && HasGltfExtension(file))
				LoadGltfFile(file);
			else
				ResetForm(false);
		}

		private bool HasGltfExtension(string file)
		{
			var extension = Path.GetExtension(file);
			return extension == ".gltf" || extension == ".glb";
		}

		private void LoadGltfFile(string file)
		{
			ResetForm(true);

			gltf = Interface.LoadModel(file);
			colliderManager = new ColliderManager();
			for (int i = 0; i < gltf.Nodes.Length; i++)
			{
				var node = gltf.Nodes[i];
				var name = GetNodeName(node, i);
				nodeListBox.Items.Add(name);

				var collider = ColliderUtil.GetNodeCollider(gltf, i);
				if (collider != null)
					colliderManager.AddCollider(i, collider);
			}
		}

		private string GetNodeName(Node node, int index)
		{
			return node.Name ?? $"Node{index}";
		}

		private void ResetForm(bool setControlsEnabled)
		{
			nodeListBox.Items.Clear();
			colliderOptionsPanel.Enabled = false;
			SetControlsEnabled(setControlsEnabled);
		}

		private void SetControlsEnabled(bool enabled)
		{
			colliderGroupBox.Enabled = enabled;
			outputGroupBox.Enabled = enabled;
			updateGltfButton.Enabled = enabled;
		}

		private void NodeListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			colliderOptionsPanel.Enabled = true;

			var nodeIndex = nodeListBox.SelectedIndex;
			colliderTypeProperty.PropertyValue = (int)colliderManager.GetColliderType(nodeIndex);
		}

		private void UpdateGltfButton_Click(object sender, EventArgs e)
		{
			var gltfPath = gltfFileTextBox.Text;
			var colliders = colliderManager.Colliders;
			var updater = new GltfUpdater(gltfPath, gltf, colliders);

			var convertImagesToDds = convertImagesToDdsProperty.PropertyValue;
			updater.Update(convertImagesToDds);

			MessageBox.Show("Updated glTF file", "Success", MessageBoxButtons.OK);

			ReloadGltfFile();
		}
	}
}
