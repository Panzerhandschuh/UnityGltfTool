namespace UnityGltfTool.UserControls
{
	partial class NumericTextBoxProperty
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.propertyLabel = new System.Windows.Forms.Label();
			this.propertyValue = new UnityGltfTool.UserControls.NumericTextBox();
			this.SuspendLayout();
			// 
			// propertyLabel
			// 
			this.propertyLabel.AutoSize = true;
			this.propertyLabel.Location = new System.Drawing.Point(0, 3);
			this.propertyLabel.Name = "propertyLabel";
			this.propertyLabel.Size = new System.Drawing.Size(35, 13);
			this.propertyLabel.TabIndex = 2;
			this.propertyLabel.Text = "label1";
			// 
			// propertyValue
			// 
			this.propertyValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyValue.Location = new System.Drawing.Point(80, 0);
			this.propertyValue.Name = "propertyValue";
			this.propertyValue.Size = new System.Drawing.Size(145, 20);
			this.propertyValue.TabIndex = 3;
			this.propertyValue.TextChanged += new System.EventHandler(this.PropertyValue_TextChanged);
			// 
			// NumericTextBoxProperty
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.propertyValue);
			this.Controls.Add(this.propertyLabel);
			this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.Name = "NumericTextBoxProperty";
			this.Size = new System.Drawing.Size(225, 20);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label propertyLabel;
		private NumericTextBox propertyValue;
	}
}
