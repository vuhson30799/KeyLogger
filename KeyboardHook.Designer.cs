namespace HookApp
{
    partial class KeyboardHook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardHook));
            this.textBoxWindowName = new System.Windows.Forms.TextBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.textBoxHistory = new System.Windows.Forms.TextBox();
            this.textBoxKeyInfo = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxWindowName
            // 
            this.textBoxWindowName.Location = new System.Drawing.Point(15, 15);
            this.textBoxWindowName.Name = "textBoxWindowName";
            this.textBoxWindowName.ReadOnly = true;
            this.textBoxWindowName.Size = new System.Drawing.Size(279, 22);
            this.textBoxWindowName.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.textBoxHistory);
            this.panelMain.Controls.Add(this.textBoxKeyInfo);
            this.panelMain.Controls.Add(this.btnExit);
            this.panelMain.Controls.Add(this.textBoxWindowName);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(587, 374);
            this.panelMain.TabIndex = 4;
            // 
            // textBoxHistory
            // 
            this.textBoxHistory.Location = new System.Drawing.Point(15, 43);
            this.textBoxHistory.Multiline = true;
            this.textBoxHistory.Name = "textBoxHistory";
            this.textBoxHistory.ReadOnly = true;
            this.textBoxHistory.Size = new System.Drawing.Size(279, 272);
            this.textBoxHistory.TabIndex = 8;
            // 
            // textBoxKeyInfo
            // 
            this.textBoxKeyInfo.Location = new System.Drawing.Point(309, 15);
            this.textBoxKeyInfo.Multiline = true;
            this.textBoxKeyInfo.Name = "textBoxKeyInfo";
            this.textBoxKeyInfo.ReadOnly = true;
            this.textBoxKeyInfo.Size = new System.Drawing.Size(258, 329);
            this.textBoxKeyInfo.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(219, 321);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // KeyboardHook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 374);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KeyboardHook";
            this.Text = "Logger";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxWindowName;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox textBoxKeyInfo;
        private System.Windows.Forms.TextBox textBoxHistory;
    }
}

