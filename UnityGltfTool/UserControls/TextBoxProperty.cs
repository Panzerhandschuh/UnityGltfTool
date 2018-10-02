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
	public partial class TextBoxProperty : UserControl
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
		[Description("Property Value")]
		public string PropertyValue
		{
			get { return propertyValue.Text; }
			set { propertyValue.Text = value; }
		}

		[Category("Design")]
		[Description("Property Value Location")]
		public int PropertyValueLocation
		{
			get { return propertyValue.Location.X; }
			set { propertyValue.Location = new Point(value, propertyValue.Location.Y); }
		}

		public TextBoxProperty()
		{
			InitializeComponent();
		}
	}
}
