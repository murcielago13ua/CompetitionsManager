namespace CompetitionsManager
{
    partial class SportsmanCreatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SportsmanCreatorForm));
            this.bDayPicker = new System.Windows.Forms.DateTimePicker();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.qualCBox = new System.Windows.Forms.ComboBox();
            this.createBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bDayPicker
            // 
            this.bDayPicker.Location = new System.Drawing.Point(12, 82);
            this.bDayPicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.bDayPicker.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.bDayPicker.Name = "bDayPicker";
            this.bDayPicker.Size = new System.Drawing.Size(260, 20);
            this.bDayPicker.TabIndex = 0;
            this.bDayPicker.Value = new System.DateTime(1994, 6, 15, 0, 0, 0, 0);
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.ForestGreen;
            this.nameTextBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.ForeColor = System.Drawing.Color.White;
            this.nameTextBox.Location = new System.Drawing.Point(12, 29);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(260, 26);
            this.nameTextBox.TabIndex = 1;
            // 
            // qualCBox
            // 
            this.qualCBox.BackColor = System.Drawing.Color.ForestGreen;
            this.qualCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualCBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.qualCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qualCBox.ForeColor = System.Drawing.Color.White;
            this.qualCBox.FormattingEnabled = true;
            this.qualCBox.Location = new System.Drawing.Point(12, 125);
            this.qualCBox.Name = "qualCBox";
            this.qualCBox.Size = new System.Drawing.Size(121, 24);
            this.qualCBox.TabIndex = 2;
            // 
            // createBtn
            // 
            this.createBtn.FlatAppearance.BorderSize = 0;
            this.createBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.createBtn.Image = ((System.Drawing.Image)(resources.GetObject("createBtn.Image")));
            this.createBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createBtn.Location = new System.Drawing.Point(139, 111);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(133, 38);
            this.createBtn.TabIndex = 3;
            this.createBtn.Text = "   Зберегти";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "П.І.Б. спортсмена";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Дата народження";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label3.Location = new System.Drawing.Point(9, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Розряд";
            // 
            // SportsmanCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(295, 164);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.qualCBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.bDayPicker);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(311, 203);
            this.MinimumSize = new System.Drawing.Size(311, 203);
            this.Name = "SportsmanCreatorForm";
            this.Text = "Створення спортсмена";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker bDayPicker;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox qualCBox;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}