using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

		[Category("Design")]
		[Description("Property Value X")]
		public string PropertyValueX
		{
			get { return propertyValueX.Text; }
			set { propertyValueX.Text = value; }
		}

		[Category("Design")]
		[Description("Property Value Y")]
		public string PropertyValueY
		{
			get { return propertyValueY.Text; }
			set { propertyValueY.Text = value; }
		}

		[Category("Design")]
		[Description("Property Value Z")]
		public string PropertyValueZ
		{
			get { return propertyValueZ.Text; }
			set { propertyValueZ.Text = value; }
		}

		[Category("Design")]
		[Description("Property Value Location")]
		public int PropertyValueLocation
		{
			get { return propertyValuePanel.Location.X; }
			set { propertyValuePanel.Location = new Point(value, propertyValuePanel.Location.Y); }
		}

		public VectorProperty()
		{
			InitializeComponent();
		}
	}
}
