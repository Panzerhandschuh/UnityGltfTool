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
			this.colliderOptionsPanel = new System.Windows.Forms.Panel();
			this.colliderTypeProperty = new UnityGltfTool.UserControls.ComboBoxProperty();
			this.colliderTypeOptionsPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.nodesPanel = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.nodeListBox = new System.Windows.Forms.ListBox();
			this.outputGroupBox = new System.Windows.Forms.GroupBox();
			this.convertImagesToDdsProperty = new UnityGltfTool.UserControls.CheckBoxProperty();
			this.updateGltfButton = new System.Windows.Forms.Button();
			this.gltfFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.inputGroupBox.SuspendLayout();
			this.colliderGroupBox.SuspendLayout();
			this.colliderOptionsPanel.SuspendLayout();
			this.nodesPanel.SuspendLayout();
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
			this.gltfFileBrowse.Location = new System.Drawing.Point(283, 16);
			this.gltfFileBrowse.Name = "gltfFileBrowse";
			this.gltfFileBrowse.Size = new System.Drawing.Size(75, 23);
			this.gltfFileBrowse.TabIndex = 2;
			this.gltfFileBrowse.Text = "Browse";
			this.gltfFileBrowse.UseVisualStyleBackColor = true;
			this.gltfFileBrowse.Click += new System.EventHandler(this.GltfFileBrowse_Click);
			// 
			// gltfFileTextBox
			// 
			this.gltfFileTextBox.Location = new System.Drawing.Point(63, 17);
			this.gltfFileTextBox.Name = "gltfFileTextBox";
			this.gltfFileTextBox.Size = new System.Drawing.Size(214, 20);
			this.gltfFileTextBox.TabIndex = 1;
			this.gltfFileTextBox.TextChanged += new System.EventHandler(this.GltfFileTextBox_TextChanged);
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
			this.colliderGroupBox.Controls.Add(this.colliderOptionsPanel);
			this.colliderGroupBox.Controls.Add(this.nodesPanel);
			this.colliderGroupBox.Enabled = false;
			this.colliderGroupBox.Location = new System.Drawing.Point(13, 70);
			this.colliderGroupBox.Name = "colliderGroupBox";
			this.colliderGroupBox.Size = new System.Drawing.Size(366, 183);
			this.colliderGroupBox.TabIndex = 1;
			this.colliderGroupBox.TabStop = false;
			this.colliderGroupBox.Text = "Collider Configuration";
			// 
			// colliderOptionsPanel
			// 
			this.colliderOptionsPanel.Controls.Add(this.colliderTypeProperty);
			this.colliderOptionsPanel.Controls.Add(this.colliderTypeOptionsPanel);
			this.colliderOptionsPanel.Controls.Add(this.label3);
			this.colliderOptionsPanel.Enabled = false;
			this.colliderOptionsPanel.Location = new System.Drawing.Point(133, 19);
			this.colliderOptionsPanel.Name = "colliderOptionsPanel";
			this.colliderOptionsPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.colliderOptionsPanel.Size = new System.Drawing.Size(225, 150);
			this.colliderOptionsPanel.TabIndex = 3;
			// 
			// colliderTypeProperty
			// 
			this.colliderTypeProperty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.colliderTypeProperty.DataSource = null;
			this.colliderTypeProperty.Location = new System.Drawing.Point(0, 19);
			this.colliderTypeProperty.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.colliderTypeProperty.Name = "colliderTypeProperty";
			this.colliderTypeProperty.PropertyName = "Collider Type";
			this.colliderTypeProperty.PropertyValue = -1;
			this.colliderTypeProperty.PropertyValueLocation = 80;
			this.colliderTypeProperty.Size = new System.Drawing.Size(225, 21);
			this.colliderTypeProperty.TabIndex = 2;
			// 
			// colliderTypeOptionsPanel
			// 
			this.colliderTypeOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.colliderTypeOptionsPanel.Location = new System.Drawing.Point(0, 40);
			this.colliderTypeOptionsPanel.Name = "colliderTypeOptionsPanel";
			this.colliderTypeOptionsPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.colliderTypeOptionsPanel.Size = new System.Drawing.Size(225, 110);
			this.colliderTypeOptionsPanel.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(0, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Collider Options:";
			// 
			// nodesPanel
			// 
			this.nodesPanel.Controls.Add(this.label2);
			this.nodesPanel.Controls.Add(this.nodeListBox);
			this.nodesPanel.Location = new System.Drawing.Point(7, 19);
			this.nodesPanel.Name = "nodesPanel";
			this.nodesPanel.Size = new System.Drawing.Size(120, 150);
			this.nodesPanel.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Nodes:";
			// 
			// nodeListBox
			// 
			this.nodeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nodeListBox.FormattingEnabled = true;
			this.nodeListBox.Location = new System.Drawing.Point(0, 16);
			this.nodeListBox.Name = "nodeListBox";
			this.nodeListBox.Size = new System.Drawing.Size(120, 134);
			this.nodeListBox.TabIndex = 0;
			this.nodeListBox.SelectedIndexChanged += new System.EventHandler(this.NodeListBox_SelectedIndexChanged);
			// 
			// outputGroupBox
			// 
			this.outputGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.outputGroupBox.Controls.Add(this.convertImagesToDdsProperty);
			this.outputGroupBox.Enabled = false;
			this.outputGroupBox.Location = new System.Drawing.Point(13, 260);
			this.outputGroupBox.Name = "outputGroupBox";
			this.outputGroupBox.Size = new System.Drawing.Size(366, 49);
			this.outputGroupBox.TabIndex = 2;
			this.outputGroupBox.TabStop = false;
			this.outputGroupBox.Text = "Output";
			// 
			// convertImagesToDdsProperty
			// 
			this.convertImagesToDdsProperty.Location = new System.Drawing.Point(7, 20);
			this.convertImagesToDdsProperty.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.convertImagesToDdsProperty.Name = "convertImagesToDdsProperty";
			this.convertImagesToDdsProperty.PropertyName = "Convert Images to DDS";
			this.convertImagesToDdsProperty.PropertyValue = true;
			this.convertImagesToDdsProperty.PropertyValueLocation = 125;
			this.convertImagesToDdsProperty.Size = new System.Drawing.Size(200, 20);
			this.convertImagesToDdsProperty.TabIndex = 0;
			// 
			// updateGltfButton
			// 
			this.updateGltfButton.Enabled = false;
			this.updateGltfButton.Location = new System.Drawing.Point(13, 316);
			this.updateGltfButton.Name = "updateGltfButton";
			this.updateGltfButton.Size = new System.Drawing.Size(75, 23);
			this.updateGltfButton.TabIndex = 3;
			this.updateGltfButton.Text = "Update glTF";
			this.updateGltfButton.UseVisualStyleBackColor = true;
			this.updateGltfButton.Click += new System.EventHandler(this.UpdateGltfButton_Click);
			// 
			// gltfFileDialog
			// 
			this.gltfFileDialog.Filter = "glTF|*.gltf;*.glb";
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
			this.colliderOptionsPanel.ResumeLayout(false);
			this.colliderOptionsPanel.PerformLayout();
			this.nodesPanel.ResumeLayout(false);
			this.nodesPanel.PerformLayout();
			this.outputGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox inputGroupBox;
		private System.Windows.Forms.Button gltfFileBrowse;
		private System.Windows.Forms.TextBox gltfFileTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox colliderGroupBox;
		private System.Windows.Forms.Panel colliderOptionsPanel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.FlowLayoutPanel colliderTypeOptionsPanel;
		private UserControls.ComboBoxProperty colliderTypeProperty;
		private System.Windows.Forms.GroupBox outputGroupBox;
		private System.Windows.Forms.Button updateGltfButton;
		private System.Windows.Forms.Panel nodesPanel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox nodeListBox;
		private UserControls.CheckBoxProperty convertImagesToDdsProperty;
		private System.Windows.Forms.OpenFileDialog gltfFileDialog;
	}
}

