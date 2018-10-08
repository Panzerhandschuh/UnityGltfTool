using glTFLoader.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityGltfTool.Math;
using UnityGltfTool.UserControls;

namespace UnityGltfTool
{
	public class ColliderOptionsDisplayer
	{
		private FlowLayoutPanel panel;
		private Unity_collidersCollider collider;

		public ColliderOptionsDisplayer(FlowLayoutPanel panel, Unity_collidersCollider collider)
		{
			this.panel = panel;
			this.collider = collider;
		}

		public void DisplayBoxOptions()
		{
			var boxCollider = collider.BoxCollider;

			var centerControl = AddCenterControl(boxCollider.Center);
			centerControl.PropertyChanged += (x, y) => UpdateBoxCenter(boxCollider, GetFloatArray(centerControl.PropertyValue));

			var sizeControl = AddSizeControl(boxCollider.Size);
			sizeControl.PropertyChanged += (x, y) => UpdateBoxSize(boxCollider, GetFloatArray(sizeControl.PropertyValue));
		}

		private void UpdateBoxCenter(Unity_collidersBoxCollider boxCollider, float[] center)
		{
			if (center != null)
				boxCollider.Center = center;
		}

		private void UpdateBoxSize(Unity_collidersBoxCollider boxCollider, float[] size)
		{
			if (size != null)
				boxCollider.Size = size;
		}

		private VectorProperty AddSizeControl(float[] size)
		{
			var sizeControl = new VectorProperty();
			sizeControl.PropertyName = "Size";
			panel.Controls.Add(sizeControl);

			if (size != null)
				sizeControl.PropertyValue = GetVector3(size);

			return sizeControl;
		}

		public void DisplaySphereOptions()
		{
			var sphereCollider = collider.SphereCollider;

			var centerControl = AddCenterControl(sphereCollider.Center);
			centerControl.PropertyChanged += (x, y) => UpdateSphereCenter(sphereCollider, GetFloatArray(centerControl.PropertyValue));

			var radiusControl = AddRadiusControl(sphereCollider.Radius);
			radiusControl.PropertyChanged += (x, y) => sphereCollider.Radius = GetFloat(radiusControl.PropertyValue);
		}

		private void UpdateSphereCenter(Unity_collidersSphereCollider sphereCollider, float[] center)
		{
			if (center != null)
				sphereCollider.Center = center;
		}

		public void DisplayCapsuleOptions()
		{
			var capsuleCollider = collider.CapsuleCollider;

			var centerControl = AddCenterControl(capsuleCollider.Center);
			centerControl.PropertyChanged += (x, y) => UpdateCapsuleCenter(capsuleCollider, GetFloatArray(centerControl.PropertyValue));

			var radiusControl = AddRadiusControl(capsuleCollider.Radius);
			radiusControl.PropertyChanged += (x, y) => capsuleCollider.Radius = GetFloat(radiusControl.PropertyValue);

			var heightControl = AddHeightControl(capsuleCollider.Height);
			heightControl.PropertyChanged += (x, y) => capsuleCollider.Height = GetFloat(heightControl.PropertyValue);

			var directionControl = AddDirectionControl(capsuleCollider.Direction);
			directionControl.PropertyChanged += (x, y) => capsuleCollider.Direction = GetDirection((CapsuleDirection)directionControl.PropertyValue);
		}

		private void UpdateCapsuleCenter(Unity_collidersCapsuleCollider capsuleCollider, float[] center)
		{
			if (center != null)
				capsuleCollider.Center = center;
		}

		private Unity_collidersCapsuleCollider.DirectionEnum? GetDirection(CapsuleDirection direction)
		{
			switch (direction)
			{
				case CapsuleDirection.X:
					return Unity_collidersCapsuleCollider.DirectionEnum.x;
				case CapsuleDirection.Y:
					return Unity_collidersCapsuleCollider.DirectionEnum.y;
				case CapsuleDirection.Z:
					return Unity_collidersCapsuleCollider.DirectionEnum.z;
				case CapsuleDirection.Default:
				default:
					return null;
			}
		}

		private VectorProperty AddCenterControl(float[] center)
		{
			var centerControl = new VectorProperty();
			centerControl.PropertyName = "Center";
			panel.Controls.Add(centerControl);

			if (center != null)
				centerControl.PropertyValue = GetVector3(center);

			return centerControl;
		}

		private NumericTextBoxProperty AddRadiusControl(float? radius)
		{
			var radiusControl = new NumericTextBoxProperty();
			radiusControl.PropertyName = "Radius";
			panel.Controls.Add(radiusControl);

			if (radius.HasValue)
				radiusControl.PropertyValue = radius.Value.ToString();

			return radiusControl;
		}

		private NumericTextBoxProperty AddHeightControl(float? height)
		{
			var heightControl = new NumericTextBoxProperty();
			heightControl.PropertyName = "Height";
			panel.Controls.Add(heightControl);

			if (height.HasValue)
				heightControl.PropertyValue = height.Value.ToString();

			return heightControl;
		}

		private ComboBoxProperty AddDirectionControl(Unity_collidersCapsuleCollider.DirectionEnum? direction)
		{
			var directionControl = new ComboBoxProperty();
			directionControl.PropertyName = "Direction";
			directionControl.DataSource = Enum.GetValues(typeof(CapsuleDirection));
			panel.Controls.Add(directionControl);

			if (direction.HasValue)
				directionControl.PropertyValue = GetDirection(direction);

			return directionControl;
		}

		private int GetDirection(Unity_collidersCapsuleCollider.DirectionEnum? direction)
		{
			switch (direction)
			{
				case Unity_collidersCapsuleCollider.DirectionEnum.x:
					return (int)CapsuleDirection.X;
				case Unity_collidersCapsuleCollider.DirectionEnum.y:
					return (int)CapsuleDirection.Y;
				case Unity_collidersCapsuleCollider.DirectionEnum.z:
					return (int)CapsuleDirection.Z;
				default:
					return (int)CapsuleDirection.Default;
			}
		}

		public void DisplayMeshOptions(IEnumerable<string> meshes)
		{
			var meshCollider = collider.MeshCollider;

			var convexControl = AddConvexControl(meshCollider.Convex);
			convexControl.PropertyChanged += (x, y) => meshCollider.Convex = convexControl.PropertyValue;

			var meshControl = AddMeshControl(meshes, meshCollider.Mesh);
			meshControl.PropertyChanged += (x, y) => meshCollider.Mesh = GetMesh(meshControl.PropertyValue);
		}

		private CheckBoxProperty AddConvexControl(bool? convex)
		{
			var convexControl = new CheckBoxProperty();
			convexControl.PropertyName = "Convex";
			panel.Controls.Add(convexControl);

			if (convex.HasValue)
				convexControl.PropertyValue = convex.Value;

			return convexControl;
		}

		private ComboBoxProperty AddMeshControl(IEnumerable<string> meshes, int? mesh)
		{
			var meshControl = new ComboBoxProperty();
			meshControl.PropertyName = "Mesh";
			meshControl.DataSource = GetMeshDataSource(meshes);
			panel.Controls.Add(meshControl);

			if (mesh.HasValue)
				meshControl.PropertyValue = mesh.Value;

			return meshControl;
		}

		private List<string> GetMeshDataSource(IEnumerable<string> meshes)
		{
			var dataSource = new List<string>() { string.Empty };
			dataSource.AddRange(meshes);

			return dataSource;
		}

		private int? GetMesh(int meshIndex)
		{
			if (meshIndex == 0)
				return null;

			return meshIndex - 1;
		}

		private Vector3 GetVector3(float[] arr)
		{
			var vec = new Vector3();

			for (int i = 0; i < 3; i++)
				vec[i] = arr[i];

			return vec;
		}

		private int? GetInt(string str)
		{
			if (int.TryParse(str, out var result))
				return result;

			return null;
		}

		private float? GetFloat(string str)
		{
			if (float.TryParse(str, out var result))
				return result;

			return null;
		}

		private float[] GetFloatArray(Vector3 vec)
		{
			if (vec == null)
				return null;

			return new float[] { vec.x, vec.y, vec.z };
		}
	}
}
