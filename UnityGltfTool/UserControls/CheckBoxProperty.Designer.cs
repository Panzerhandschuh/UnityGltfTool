namespace UnityGltfTool.UserControls
{
	partial class CheckBoxProperty
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
			this.propertyValue = new System.Windows.Forms.CheckBox();
			this.propertyLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// propertyValue
			// 
			this.propertyValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.propertyValue.AutoSize = true;
			this.propertyValue.Location = new System.Drawing.Point(80, 3);
			this.propertyValue.Margin = new System.Windows.Forms.Padding(0);
			this.propertyValue.Name = "propertyValue";
			this.propertyValue.Size = new System.Drawing.Size(15, 14);
			this.propertyValue.TabIndex = 0;
			this.propertyValue.UseVisualStyleBackColor = true;
			// 
			// propertyLabel
			// 
			this.propertyLabel.AutoSize = true;
			this.propertyLabel.Location = new System.Drawing.Point(0, 3);
			this.propertyLabel.Name = "propertyLabel";
			this.propertyLabel.Size = new System.Drawing.Size(35, 13);
			this.propertyLabel.TabIndex = 1;
			this.propertyLabel.Text = "label1";
			// 
			// CheckBoxProperty
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.propertyLabel);
			this.Controls.Add(this.propertyValue);
			this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.Name = "CheckBoxProperty";
			this.Size = new System.Drawing.Size(94, 20);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox propertyValue;
		private System.Windows.Forms.Label propertyLabel;
	}
}
