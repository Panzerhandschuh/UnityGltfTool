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

namespace UnityGltfTool
{
	public partial class Form1 : Form
	{
		private Gltf gltf;

		public Form1()
		{
			InitializeComponent();

			colliderType.DataSource = Enum.GetValues(typeof(ColliderType));
			colliderType.SelectedIndexChanged += ColliderType_SelectedIndexChanged;
		}

		private void ColliderType_SelectedIndexChanged(object sender, EventArgs e)
		{
			colliderTypeOptionsPanel.Controls.Clear();

			var type = (ColliderType)colliderType.SelectedItem;
			switch (type)
			{
				case ColliderType.Box:
					DisplayBoxOptions();
					break;
				case ColliderType.Sphere:
					DisplaySphereOptions();
					break;
				case ColliderType.Capsule:
					DisplayCapsuleOptions();
					break;
				case ColliderType.Mesh:
					DisplayMeshOptions();
					break;
			}
		}

		private void DisplayBoxOptions()
		{
			AddCenterControl();

			var sizeControl = new VectorProperty();
			sizeControl.PropertyName = "Size";
			colliderTypeOptionsPanel.Controls.Add(sizeControl);
		}

		private void DisplaySphereOptions()
		{
			AddCenterControl();
			AddRadiusControl();
		}

		private void DisplayCapsuleOptions()
		{
			AddCenterControl();
			AddRadiusControl();

			var heightControl = new TextBoxProperty();
			heightControl.PropertyName = "Height";
			colliderTypeOptionsPanel.Controls.Add(heightControl);

			var directionControl = new ComboBoxProperty();
			directionControl.PropertyName = "Direction";
			directionControl.DataSource = Enum.GetValues(typeof(CapsuleDirection));
			colliderTypeOptionsPanel.Controls.Add(directionControl);
		}

		private void AddCenterControl()
		{
			var centerControl = new VectorProperty();
			centerControl.PropertyName = "Center";
			colliderTypeOptionsPanel.Controls.Add(centerControl);
		}

		private void AddRadiusControl()
		{
			var radiusControl = new TextBoxProperty();
			radiusControl.PropertyName = "Radius";
			colliderTypeOptionsPanel.Controls.Add(radiusControl);
		}

		private void DisplayMeshOptions()
		{
			var convexControl = new CheckBoxProperty();
			convexControl.PropertyName = "Convex";
			colliderTypeOptionsPanel.Controls.Add(convexControl);

			var meshControl = new ComboBoxProperty();
			meshControl.PropertyName = "Mesh";
			// TODO: Get mesh list from gltf file
			colliderTypeOptionsPanel.Controls.Add(meshControl);
		}

		private void GltfFileBrowse_Click(object sender, EventArgs e)
		{
			var result = gltfFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				var file = gltfFileDialog.FileName;
				gltfFileTextBox.Text = file; // This will trigger GltfFileTextBox_TextChanged
			}
		}

		private void GltfFileTextBox_TextChanged(object sender, EventArgs e)
		{
			var file = gltfFileTextBox.Text;
			if (File.Exists(file) && HasGltfExtension(file))
				LoadGltfFile(file);
			else
				Reset(false);
		}

		private bool HasGltfExtension(string file)
		{
			var extension = Path.GetExtension(file);
			return extension == ".gltf" || extension == ".glb";
		}

		private void LoadGltfFile(string file)
		{
			Reset(true);

			gltf = Interface.LoadModel(file);
			for (int i = 0; i < gltf.Nodes.Length; i++)
			{
				var node = gltf.Nodes[i];
				var name = node.Name ?? $"Node{i}";
				nodeListBox.Items.Add(name);
			}
		}

		private void Reset(bool setControlsEnabled)
		{
			gltf = null;
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
			colliderType.SelectedItem = GetNodeColliderType(nodeIndex);
		}

		private ColliderType GetNodeColliderType(int nodeIndex)
		{
			var nodeColliderExtension = GetNodeColliderExtension(nodeIndex);
			if (nodeColliderExtension != null)
			{
				var collider = GetCollider(nodeColliderExtension.Collider.Value);
				if (collider.BoxCollider != null)
					return ColliderType.Box;
				else if (collider.SphereCollider != null)
					return ColliderType.Sphere;
				else if (collider.CapsuleCollider != null)
					return ColliderType.Capsule;
				else if (collider.MeshCollider != null)
					return ColliderType.Mesh;
			}

			return ColliderType.None;
		}

		private Unity_collidersNodeExtension GetNodeColliderExtension(int nodeIndex)
		{
			var node = gltf.Nodes[nodeIndex];
			return ExtensionUtil.LoadExtension<Unity_collidersNodeExtension>(node.Extensions, "Unity_colliders");
		}

		private Unity_collidersCollider GetCollider(int colliderIndex)
		{
			var colliderExtension = ExtensionUtil.LoadExtension<Unity_collidersGltfExtension>(gltf.Extensions, "Unity_colliders");
			return colliderExtension.Colliders[colliderIndex];
		}
	}
}
