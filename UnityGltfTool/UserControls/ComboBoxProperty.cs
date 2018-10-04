using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;

namespace UnityGltfTool.UserControls
{
	public partial class ComboBoxProperty : UserControl
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

		public int PropertyValue
		{
			get { return propertyValue.SelectedIndex; }
			set { propertyValue.SelectedIndex = value; }
		}

		[Category("Design")]
		[Description("Property Value Location")]
		public int PropertyValueLocation
		{
			get { return propertyValue.Location.X; }
			set { propertyValue.Location = new Point(value, propertyValue.Location.Y); }
		}

		public object DataSource
		{
			get { return propertyValue.DataSource; }
			set { propertyValue.DataSource = value; }
		}

		public event EventHandler PropertyChanged;

		public ComboBoxProperty()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (propertyValue.Items.Count > 0)
				propertyValue.SelectedIndex = 0;
		}

		private void PropertyValue_SelectedIndexChanged(object sender, EventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}
	}
}
