namespace CompetitionsManager
{
    partial class OpenCompDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenCompDialog));
            this.compComboBox = new System.Windows.Forms.ComboBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // compComboBox
            // 
            this.compComboBox.BackColor = System.Drawing.Color.ForestGreen;
            this.compComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.compComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.compComboBox.ForeColor = System.Drawing.Color.White;
            this.compComboBox.FormattingEnabled = true;
            this.compComboBox.Location = new System.Drawing.Point(13, 13);
            this.compComboBox.MaxDropDownItems = 20;
            this.compComboBox.Name = "compComboBox";
            this.compComboBox.Size = new System.Drawing.Size(259, 28);
            this.compComboBox.Sorted = true;
            this.compComboBox.TabIndex = 0;
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.okBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.okBtn.FlatAppearance.BorderSize = 0;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.okBtn.Location = new System.Drawing.Point(13, 47);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(106, 29);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "ОК";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.cancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.cancelBtn.Location = new System.Drawing.Point(166, 47);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(106, 29);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Відміна";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // OpenCompDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(284, 88);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.compComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 127);
            this.MinimumSize = new System.Drawing.Size(300, 127);
            this.Name = "OpenCompDialog";
            this.Text = "Вибір змагань";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox compComboBox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}