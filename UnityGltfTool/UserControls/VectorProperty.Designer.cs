namespace UnityGltfTool.UserControls
{
	partial class VectorProperty
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
			this.label2 = new System.Windows.Forms.Label();
			this.propertyValueX = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.propertyValueY = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.propertyValueZ = new System.Windows.Forms.TextBox();
			this.propertyValuePanel = new System.Windows.Forms.Panel();
			this.propertyValuePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// propertyLabel
			// 
			this.propertyLabel.AutoSize = true;
			this.propertyLabel.Location = new System.Drawing.Point(0, 3);
			this.propertyLabel.Name = "propertyLabel";
			this.propertyLabel.Size = new System.Drawing.Size(35, 13);
			this.propertyLabel.TabIndex = 0;
			this.propertyLabel.Text = "label1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(0, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(15, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "x:";
			// 
			// propertyValueX
			// 
			this.propertyValueX.Location = new System.Drawing.Point(15, 0);
			this.propertyValueX.Name = "propertyValueX";
			this.propertyValueX.Size = new System.Drawing.Size(30, 20);
			this.propertyValueX.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(50, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(15, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "y:";
			// 
			// propertyValueY
			// 
			this.propertyValueY.Location = new System.Drawing.Point(65, 0);
			this.propertyValueY.Name = "propertyValueY";
			this.propertyValueY.Size = new System.Drawing.Size(30, 20);
			this.propertyValueY.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(100, 4);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(15, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "z:";
			// 
			// propertyValueZ
			// 
			this.propertyValueZ.Location = new System.Drawing.Point(115, 0);
			this.propertyValueZ.Name = "propertyValueZ";
			this.propertyValueZ.Size = new System.Drawing.Size(30, 20);
			this.propertyValueZ.TabIndex = 6;
			// 
			// propertyValuePanel
			// 
			this.propertyValuePanel.Controls.Add(this.label2);
			this.propertyValuePanel.Controls.Add(this.propertyValueZ);
			this.propertyValuePanel.Controls.Add(this.propertyValueX);
			this.propertyValuePanel.Controls.Add(this.label4);
			this.propertyValuePanel.Controls.Add(this.label3);
			this.propertyValuePanel.Controls.Add(this.propertyValueY);
			this.propertyValuePanel.Location = new System.Drawing.Point(80, 0);
			this.propertyValuePanel.Name = "propertyValuePanel";
			this.propertyValuePanel.Size = new System.Drawing.Size(145, 20);
			this.propertyValuePanel.TabIndex = 7;
			// 
			// VectorProperty
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.propertyValuePanel);
			this.Controls.Add(this.propertyLabel);
			this.Name = "VectorProperty";
			this.Size = new System.Drawing.Size(225, 20);
			this.propertyValuePanel.ResumeLayout(false);
			this.propertyValuePanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label propertyLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox propertyValueX;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox propertyValueY;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox propertyValueZ;
		private System.Windows.Forms.Panel propertyValuePanel;
	}
}
