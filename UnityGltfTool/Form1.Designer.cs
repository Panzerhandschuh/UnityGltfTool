namespace UnityGltfTool
{
	partial class Form1
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.inputGroupBox = new System.Windows.Forms.GroupBox();
			this.gltfFileBrowse = new System.Windows.Forms.Button();
			this.gltfFileTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.colliderGroupBox = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.colliderType = new UnityGltfTool.UserControls.ComboBoxProperty();
			this.colliderOptionsPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.meshListBox = new System.Windows.Forms.ListBox();
			this.outputGroupBox = new System.Windows.Forms.GroupBox();
			this.checkBoxProperty1 = new UnityGltfTool.UserControls.CheckBoxProperty();
			this.updateGltfButton = new System.Windows.Forms.Button();
			this.inputGroupBox.SuspendLayout();
			this.colliderGroupBox.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.outputGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// inputGroupBox
			// 
			this.inputGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.inputGroupBox.Controls.Add(this.gltfFileBrowse);
			this.inputGroupBox.Controls.Add(this.gltfFileTextBox);
			this.inputGroupBox.Controls.Add(this.label1);
			this.inputGroupBox.Location = new System.Drawing.Point(13, 13);
			this.inputGroupBox.Name = "inputGroupBox";
			this.inputGroupBox.Size = new System.Drawing.Size(366, 50);
			this.inputGroupBox.TabIndex = 0;
			this.inputGroupBox.TabStop = false;
			this.inputGroupBox.Text = "Input";
			// 
			// gltfFileBrowse
			// 
			this.gltfFileBrowse.Location = new System.Drawing.Point(269, 16);
			this.gltfFileBrowse.Name = "gltfFileBrowse";
			this.gltfFileBrowse.Size = new System.Drawing.Size(75, 23);
			this.gltfFileBrowse.TabIndex = 2;
			this.gltfFileBrowse.Text = "Browse";
			this.gltfFileBrowse.UseVisualStyleBackColor = true;
			// 
			// gltfFileTextBox
			// 
			this.gltfFileTextBox.Location = new System.Drawing.Point(63, 17);
			this.gltfFileTextBox.Name = "gltfFileTextBox";
			this.gltfFileTextBox.Size = new System.Drawing.Size(200, 20);
			this.gltfFileTextBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "glTF File:";
			// 
			// colliderGroupBox
			// 
			this.colliderGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.colliderGroupBox.Controls.Add(this.panel2);
			this.colliderGroupBox.Controls.Add(this.panel1);
			this.colliderGroupBox.Location = new System.Drawing.Point(13, 70);
			this.colliderGroupBox.Name = "colliderGroupBox";
			this.colliderGroupBox.Size = new System.Drawing.Size(366, 183);
			this.colliderGroupBox.TabIndex = 1;
			this.colliderGroupBox.TabStop = false;
			this.colliderGroupBox.Text = "Collider Configuration";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.colliderType);
			this.panel2.Controls.Add(this.colliderOptionsPanel);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Location = new System.Drawing.Point(133, 19);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(225, 150);
			this.panel2.TabIndex = 3;
			// 
			// colliderType
			// 
			this.colliderType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.colliderType.DataSource = null;
			this.colliderType.Location = new System.Drawing.Point(0, 16);
			this.colliderType.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.colliderType.Name = "colliderType";
			this.colliderType.PropertyName = "Collider Type";
			this.colliderType.PropertyValue.AddRange(new object[] {
            "None",
            "Box",
            "Sphere",
            "Capsule",
            "Mesh"});
			this.colliderType.PropertyValueLocation = 80;
			this.colliderType.SelectedItem = "None";
			this.colliderType.Size = new System.Drawing.Size(225, 21);
			this.colliderType.TabIndex = 2;
			// 
			// colliderOptionsPanel
			// 
			this.colliderOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.colliderOptionsPanel.Location = new System.Drawing.Point(0, 37);
			this.colliderOptionsPanel.Name = "colliderOptionsPanel";
			this.colliderOptionsPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.colliderOptionsPanel.Size = new System.Drawing.Size(225, 113);
			this.colliderOptionsPanel.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Collider Options:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.meshListBox);
			this.panel1.Location = new System.Drawing.Point(7, 19);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(120, 150);
			this.panel1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Meshes:";
			// 
			// meshListBox
			// 
			this.meshListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.meshListBox.FormattingEnabled = true;
			this.meshListBox.Location = new System.Drawing.Point(0, 16);
			this.meshListBox.Name = "meshListBox";
			this.meshListBox.Size = new System.Drawing.Size(120, 134);
			this.meshListBox.TabIndex = 0;
			// 
			// outputGroupBox
			// 
			this.outputGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.outputGroupBox.Controls.Add(this.checkBoxProperty1);
			this.outputGroupBox.Location = new System.Drawing.Point(13, 260);
			this.outputGroupBox.Name = "outputGroupBox";
			this.outputGroupBox.Size = new System.Drawing.Size(366, 49);
			this.outputGroupBox.TabIndex = 2;
			this.outputGroupBox.TabStop = false;
			this.outputGroupBox.Text = "Output";
			// 
			// checkBoxProperty1
			// 
			this.checkBoxProperty1.Location = new System.Drawing.Point(7, 20);
			this.checkBoxProperty1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.checkBoxProperty1.Name = "checkBoxProperty1";
			this.checkBoxProperty1.PropertyName = "Convert Images to DDS";
			this.checkBoxProperty1.PropertyValue = true;
			this.checkBoxProperty1.PropertyValueLocation = 125;
			this.checkBoxProperty1.Size = new System.Drawing.Size(200, 20);
			this.checkBoxProperty1.TabIndex = 0;
			// 
			// updateGltfButton
			// 
			this.updateGltfButton.Location = new System.Drawing.Point(13, 316);
			this.updateGltfButton.Name = "updateGltfButton";
			this.updateGltfButton.Size = new System.Drawing.Size(75, 23);
			this.updateGltfButton.TabIndex = 3;
			this.updateGltfButton.Text = "Update glTF";
			this.updateGltfButton.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(391, 347);
			this.Controls.Add(this.updateGltfButton);
			this.Controls.Add(this.outputGroupBox);
			this.Controls.Add(this.colliderGroupBox);
			this.Controls.Add(this.inputGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Unity glTF Tool";
			this.inputGroupBox.ResumeLayout(false);
			this.inputGroupBox.PerformLayout();
			this.colliderGroupBox.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.outputGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox inputGroupBox;
		private System.Windows.Forms.Button gltfFileBrowse;
		private System.Windows.Forms.TextBox gltfFileTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox colliderGroupBox;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.FlowLayoutPanel colliderOptionsPanel;
		private UserControls.ComboBoxProperty colliderType;
		private System.Windows.Forms.GroupBox outputGroupBox;
		private System.Windows.Forms.Button updateGltfButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox meshListBox;
		private UserControls.CheckBoxProperty checkBoxProperty1;
	}
}

