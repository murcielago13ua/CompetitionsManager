namespace CompetitionsManager
{
    partial class UniqueStageEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UniqueStageEditForm));
            this.stNameTBox = new System.Windows.Forms.TextBox();
            this.stPointsTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.createStBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stNameTBox
            // 
            this.stNameTBox.BackColor = System.Drawing.Color.ForestGreen;
            this.stNameTBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stNameTBox.ForeColor = System.Drawing.Color.White;
            this.stNameTBox.Location = new System.Drawing.Point(15, 28);
            this.stNameTBox.Name = "stNameTBox";
            this.stNameTBox.Size = new System.Drawing.Size(283, 27);
            this.stNameTBox.TabIndex = 0;
            // 
            // stPointsTBox
            // 
            this.stPointsTBox.BackColor = System.Drawing.Color.ForestGreen;
            this.stPointsTBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stPointsTBox.ForeColor = System.Drawing.Color.White;
            this.stPointsTBox.Location = new System.Drawing.Point(160, 58);
            this.stPointsTBox.Name = "stPointsTBox";
            this.stPointsTBox.Size = new System.Drawing.Size(138, 27);
            this.stPointsTBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Назва етапу";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Бальна оцінка";
            // 
            // createStBtn
            // 
            this.createStBtn.FlatAppearance.BorderSize = 0;
            this.createStBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createStBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createStBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.createStBtn.Image = ((System.Drawing.Image)(resources.GetObject("createStBtn.Image")));
            this.createStBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createStBtn.Location = new System.Drawing.Point(12, 93);
            this.createStBtn.Name = "createStBtn";
            this.createStBtn.Size = new System.Drawing.Size(142, 33);
            this.createStBtn.TabIndex = 6;
            this.createStBtn.Text = "     Створити";
            this.createStBtn.UseVisualStyleBackColor = true;
            this.createStBtn.Click += new System.EventHandler(this.createStBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeBtn.Location = new System.Drawing.Point(163, 91);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(135, 33);
            this.closeBtn.TabIndex = 7;
            this.closeBtn.Text = "   Закрити";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // UniqueStageEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(310, 138);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.createStBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stPointsTBox);
            this.Controls.Add(this.stNameTBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(326, 177);
            this.MinimumSize = new System.Drawing.Size(326, 177);
            this.Name = "UniqueStageEditForm";
            this.Text = "Створення етапу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox stNameTBox;
        private System.Windows.Forms.TextBox stPointsTBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createStBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}