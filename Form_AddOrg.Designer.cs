namespace ARM
{
    partial class Form_AddOrg
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
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.l_Name = new System.Windows.Forms.Label();
            this.l_FullName = new System.Windows.Forms.Label();
            this.tb_FullName = new System.Windows.Forms.TextBox();
            this.l_AbbrName = new System.Windows.Forms.Label();
            this.tb_AbbrName = new System.Windows.Forms.TextBox();
            this.l_Address = new System.Windows.Forms.Label();
            this.tb_Address = new System.Windows.Forms.TextBox();
            this.l_Tel = new System.Windows.Forms.Label();
            this.tb_Tel = new System.Windows.Forms.TextBox();
            this.but_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(47, 9);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(100, 20);
            this.tb_Name.TabIndex = 0;
            // 
            // l_Name
            // 
            this.l_Name.AutoSize = true;
            this.l_Name.Location = new System.Drawing.Point(12, 9);
            this.l_Name.Name = "l_Name";
            this.l_Name.Size = new System.Drawing.Size(29, 13);
            this.l_Name.TabIndex = 1;
            this.l_Name.Text = "Имя";
            // 
            // l_FullName
            // 
            this.l_FullName.AutoSize = true;
            this.l_FullName.Location = new System.Drawing.Point(12, 35);
            this.l_FullName.Name = "l_FullName";
            this.l_FullName.Size = new System.Drawing.Size(68, 13);
            this.l_FullName.TabIndex = 3;
            this.l_FullName.Text = "Полное имя";
            // 
            // tb_FullName
            // 
            this.tb_FullName.Location = new System.Drawing.Point(86, 35);
            this.tb_FullName.Name = "tb_FullName";
            this.tb_FullName.Size = new System.Drawing.Size(161, 20);
            this.tb_FullName.TabIndex = 2;
            // 
            // l_AbbrName
            // 
            this.l_AbbrName.AutoSize = true;
            this.l_AbbrName.Location = new System.Drawing.Point(12, 65);
            this.l_AbbrName.Name = "l_AbbrName";
            this.l_AbbrName.Size = new System.Drawing.Size(78, 13);
            this.l_AbbrName.TabIndex = 5;
            this.l_AbbrName.Text = "Аббревиатура";
            // 
            // tb_AbbrName
            // 
            this.tb_AbbrName.Location = new System.Drawing.Point(96, 61);
            this.tb_AbbrName.Name = "tb_AbbrName";
            this.tb_AbbrName.Size = new System.Drawing.Size(151, 20);
            this.tb_AbbrName.TabIndex = 4;
            this.tb_AbbrName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // l_Address
            // 
            this.l_Address.AutoSize = true;
            this.l_Address.Location = new System.Drawing.Point(12, 90);
            this.l_Address.Name = "l_Address";
            this.l_Address.Size = new System.Drawing.Size(38, 13);
            this.l_Address.TabIndex = 6;
            this.l_Address.Text = "Адрес";
            // 
            // tb_Address
            // 
            this.tb_Address.Location = new System.Drawing.Point(86, 87);
            this.tb_Address.Name = "tb_Address";
            this.tb_Address.Size = new System.Drawing.Size(100, 20);
            this.tb_Address.TabIndex = 7;
            // 
            // l_Tel
            // 
            this.l_Tel.AutoSize = true;
            this.l_Tel.Location = new System.Drawing.Point(15, 120);
            this.l_Tel.Name = "l_Tel";
            this.l_Tel.Size = new System.Drawing.Size(52, 13);
            this.l_Tel.TabIndex = 8;
            this.l_Tel.Text = "Телефон";
            // 
            // tb_Tel
            // 
            this.tb_Tel.Location = new System.Drawing.Point(86, 120);
            this.tb_Tel.Name = "tb_Tel";
            this.tb_Tel.Size = new System.Drawing.Size(100, 20);
            this.tb_Tel.TabIndex = 9;
            // 
            // but_Save
            // 
            this.but_Save.Location = new System.Drawing.Point(18, 160);
            this.but_Save.Name = "but_Save";
            this.but_Save.Size = new System.Drawing.Size(75, 23);
            this.but_Save.TabIndex = 10;
            this.but_Save.Text = "Записать";
            this.but_Save.UseVisualStyleBackColor = true;
            this.but_Save.Click += new System.EventHandler(this.but_Save_Click);
            // 
            // Form_AddOrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 197);
            this.Controls.Add(this.but_Save);
            this.Controls.Add(this.tb_Tel);
            this.Controls.Add(this.l_Tel);
            this.Controls.Add(this.tb_Address);
            this.Controls.Add(this.l_Address);
            this.Controls.Add(this.l_AbbrName);
            this.Controls.Add(this.tb_AbbrName);
            this.Controls.Add(this.l_FullName);
            this.Controls.Add(this.tb_FullName);
            this.Controls.Add(this.l_Name);
            this.Controls.Add(this.tb_Name);
            this.Name = "Form_AddOrg";
            this.Text = "Form_AddOrg";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Label l_Name;
        private System.Windows.Forms.Label l_FullName;
        private System.Windows.Forms.TextBox tb_FullName;
        private System.Windows.Forms.Label l_AbbrName;
        private System.Windows.Forms.TextBox tb_AbbrName;
        private System.Windows.Forms.Label l_Address;
        private System.Windows.Forms.TextBox tb_Address;
        private System.Windows.Forms.Label l_Tel;
        private System.Windows.Forms.TextBox tb_Tel;
        private System.Windows.Forms.Button but_Save;
    }
}