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
		public Form1()
		{
			InitializeComponent();

			colliderType.DataSource = Enum.GetValues(typeof(ColliderType));
			colliderType.SelectedIndexChanged += ColliderType_SelectedIndexChanged;
		}

		private void ColliderType_SelectedIndexChanged(object sender, EventArgs e)
		{
			colliderOptionsPanel.Controls.Clear();

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
			colliderOptionsPanel.Controls.Add(sizeControl);
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
			colliderOptionsPanel.Controls.Add(heightControl);

			var directionControl = new ComboBoxProperty();
			directionControl.PropertyName = "Direction";
			directionControl.DataSource = Enum.GetValues(typeof(CapsuleDirection));
			colliderOptionsPanel.Controls.Add(directionControl);
		}

		private void AddCenterControl()
		{
			var centerControl = new VectorProperty();
			centerControl.PropertyName = "Center";
			colliderOptionsPanel.Controls.Add(centerControl);
		}

		private void AddRadiusControl()
		{
			var radiusControl = new TextBoxProperty();
			radiusControl.PropertyName = "Radius";
			colliderOptionsPanel.Controls.Add(radiusControl);
		}

		private void DisplayMeshOptions()
		{
			var convexControl = new CheckBoxProperty();
			convexControl.PropertyName = "Convex";
			colliderOptionsPanel.Controls.Add(convexControl);

			var meshControl = new ComboBoxProperty();
			meshControl.PropertyName = "Mesh";
			// TODO: Get mesh list from gltf file
			colliderOptionsPanel.Controls.Add(meshControl);
		}

		private void GltfFileBrowse_Click(object sender, EventArgs e)
		{
			var result = gltfFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				var file = gltfFileDialog.FileName;
				gltfFileTextBox.Text = file;
				LoadGltfFile(file);
			}
		}

		private void GltfFileTextBox_TextChanged(object sender, EventArgs e)
		{
			var file = gltfFileTextBox.Text;
			if (HasGltfExtension(file) && File.Exists(file))
				LoadGltfFile(file);
		}

		private bool HasGltfExtension(string file)
		{
			var extension = Path.GetExtension(file);
			return extension == ".gltf" || extension == ".glb";
		}

		private void LoadGltfFile(string file)
		{
			throw new NotImplementedException();
		}
	}
}
