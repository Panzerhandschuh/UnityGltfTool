using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityGltfTool.Math;

namespace UnityGltfTool.UserControls
{
	public partial class VectorProperty : UserControl
	{
		private string propertyName;

		[Category("Design")]
		[Description("Property Name")]
		public string PropertyName
		{
			get
			{
				return propertyName;
			}
			set
			{
				propertyName = value;
				propertyLabel.Text = propertyName + ":";
			}
		}

		public Vector3 PropertyValue
		{
			get
			{
				var successX = float.TryParse(propertyValueX.Text, out var x);
				var successY = float.TryParse(propertyValueY.Text, out var y);
				var successZ = float.TryParse(propertyValueZ.Text, out var z);
				if (successX || successY || successZ) // Only one value needs to be set for this property to be valid
					return new Vector3(x, y, z);

				return null;
			}
			set
			{
				if (value != null)
				{
					propertyValueX.Text = value.x.ToString();
					propertyValueY.Text = value.y.ToString();
					propertyValueZ.Text = value.z.ToString();
				}
				else
				{
					propertyValueX.Text = string.Empty;
					propertyValueY.Text = string.Empty;
					propertyValueZ.Text = string.Empty;
				}
			}
		}

		[Category("Design")]
		[Description("Property Value Location")]
		public int PropertyValueLocation
		{
			get { return propertyValuePanel.Location.X; }
			set { propertyValuePanel.Location = new Point(value, propertyValuePanel.Location.Y); }
		}

		public event EventHandler PropertyChanged;

		public VectorProperty()
		{
			InitializeComponent();
		}

		private void PropertyValueX_TextChanged(object sender, EventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}

		private void PropertyValueY_TextChanged(object sender, EventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}

		private void PropertyValueZ_TextChanged(object sender, EventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}
	}
}
