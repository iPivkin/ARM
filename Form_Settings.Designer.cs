namespace ARM
{
    partial class Form_Settings
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
            this.link_Org = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // link_Org
            // 
            this.link_Org.AutoSize = true;
            this.link_Org.Location = new System.Drawing.Point(3, 13);
            this.link_Org.Name = "link_Org";
            this.link_Org.Size = new System.Drawing.Size(127, 13);
            this.link_Org.TabIndex = 0;
            this.link_Org.TabStop = true;
            this.link_Org.Text = "Добавить организацию";
            this.link_Org.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Org_LinkClicked);
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.link_Org);
            this.Name = "Form_Settings";
            this.Text = "Form_Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel link_Org;
    }
}