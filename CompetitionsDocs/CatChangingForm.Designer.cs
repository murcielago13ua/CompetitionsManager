namespace CompetitionsManager
{
    partial class CatChangingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatChangingForm));
            this.currCatTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.catsComboBox = new System.Windows.Forms.ComboBox();
            this.turistoLabel = new System.Windows.Forms.Label();
            this.transferBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currCatTBox
            // 
            this.currCatTBox.BackColor = System.Drawing.Color.White;
            this.currCatTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currCatTBox.ForeColor = System.Drawing.Color.Black;
            this.currCatTBox.Location = new System.Drawing.Point(13, 87);
            this.currCatTBox.Name = "currCatTBox";
            this.currCatTBox.Size = new System.Drawing.Size(183, 26);
            this.currCatTBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Із категорії";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(195, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "<=>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label3.Location = new System.Drawing.Point(240, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "В категорію";
            // 
            // catsComboBox
            // 
            this.catsComboBox.BackColor = System.Drawing.Color.ForestGreen;
            this.catsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.catsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.catsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.catsComboBox.ForeColor = System.Drawing.Color.White;
            this.catsComboBox.FormattingEnabled = true;
            this.catsComboBox.Location = new System.Drawing.Point(244, 87);
            this.catsComboBox.Name = "catsComboBox";
            this.catsComboBox.Size = new System.Drawing.Size(193, 26);
            this.catsComboBox.TabIndex = 5;
            // 
            // turistoLabel
            // 
            this.turistoLabel.AutoSize = true;
            this.turistoLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.turistoLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.turistoLabel.Location = new System.Drawing.Point(12, 29);
            this.turistoLabel.Name = "turistoLabel";
            this.turistoLabel.Size = new System.Drawing.Size(65, 20);
            this.turistoLabel.TabIndex = 6;
            this.turistoLabel.Text = "label4";
            // 
            // transferBtn
            // 
            this.transferBtn.FlatAppearance.BorderSize = 0;
            this.transferBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transferBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.transferBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.transferBtn.Image = ((System.Drawing.Image)(resources.GetObject("transferBtn.Image")));
            this.transferBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.transferBtn.Location = new System.Drawing.Point(12, 137);
            this.transferBtn.Name = "transferBtn";
            this.transferBtn.Size = new System.Drawing.Size(151, 35);
            this.transferBtn.TabIndex = 7;
            this.transferBtn.Text = "    Перенести";
            this.transferBtn.UseVisualStyleBackColor = true;
            this.transferBtn.Click += new System.EventHandler(this.transferBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.cancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.Image")));
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.Location = new System.Drawing.Point(286, 137);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(151, 35);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "    Відмінити";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // CatChangingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(449, 184);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.transferBtn);
            this.Controls.Add(this.turistoLabel);
            this.Controls.Add(this.catsComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currCatTBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(465, 223);
            this.MinimumSize = new System.Drawing.Size(465, 223);
            this.Name = "CatChangingForm";
            this.Text = "Перенесення";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox currCatTBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox catsComboBox;
        private System.Windows.Forms.Label turistoLabel;
        private System.Windows.Forms.Button transferBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}