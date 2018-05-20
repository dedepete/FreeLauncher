namespace FreeLauncher.Forms
{
    partial class UpdateForm
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
            this.changelogBox = new System.Windows.Forms.RichTextBox();
            this.goButton = new Telerik.WinControls.UI.RadButton();
            this.cancelButton = new Telerik.WinControls.UI.RadButton();
            this.supportCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.autocheckCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.goButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supportCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autocheckCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // changelogBox
            // 
            this.changelogBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.changelogBox.Location = new System.Drawing.Point(0, 0);
            this.changelogBox.Name = "changelogBox";
            this.changelogBox.ReadOnly = true;
            this.changelogBox.Size = new System.Drawing.Size(636, 203);
            this.changelogBox.TabIndex = 0;
            this.changelogBox.Text = "";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(472, 232);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(152, 24);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Go to GitHub";
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(12, 232);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(120, 24);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            // 
            // supportCheckBox
            // 
            this.supportCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.supportCheckBox.Location = new System.Drawing.Point(472, 209);
            this.supportCheckBox.Name = "supportCheckBox";
            this.supportCheckBox.Size = new System.Drawing.Size(133, 18);
            this.supportCheckBox.TabIndex = 6;
            this.supportCheckBox.Text = "Support the developer";
            this.supportCheckBox.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // autocheckCheckBox
            // 
            this.autocheckCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autocheckCheckBox.Location = new System.Drawing.Point(12, 209);
            this.autocheckCheckBox.Name = "autocheckCheckBox";
            this.autocheckCheckBox.Size = new System.Drawing.Size(180, 18);
            this.autocheckCheckBox.TabIndex = 7;
            this.autocheckCheckBox.Text = "Automatically check for updates";
            this.autocheckCheckBox.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 258);
            this.Controls.Add(this.autocheckCheckBox);
            this.Controls.Add(this.supportCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.changelogBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update checker";
            ((System.ComponentModel.ISupportInitialize)(this.goButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supportCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autocheckCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox changelogBox;
        private Telerik.WinControls.UI.RadButton goButton;
        private Telerik.WinControls.UI.RadButton cancelButton;
        private Telerik.WinControls.UI.RadCheckBox supportCheckBox;
        public Telerik.WinControls.UI.RadCheckBox autocheckCheckBox;
    }
}
