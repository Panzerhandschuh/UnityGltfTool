using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnityGltfTool.UserControls
{
	public partial class NumericTextBox : TextBox
	{
		private string previousText = string.Empty;

		public NumericTextBox()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			e.Handled = IsValidNumericCharacter(e.KeyChar);
		}

		private bool IsValidNumericCharacter(char keyChar)
		{
			// Decimal
			if (keyChar == '.' && !Text.Contains('.'))
				return false;

			// Negative
			if (keyChar == '-' && !Text.Contains('-'))
				return false;

			// Digit
			return !char.IsDigit(keyChar) && !char.IsControl(keyChar);
		}

		protected override void OnLeave(EventArgs e)
		{
			if (string.IsNullOrEmpty(Text) || float.TryParse(Text, out var result))
				previousText = Text;
			else
				Text = previousText;
		}
	}
}
