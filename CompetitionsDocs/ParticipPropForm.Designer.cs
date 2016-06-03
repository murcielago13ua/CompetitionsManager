namespace CompetitionsManager
{
    partial class ParticipPropForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParticipPropForm));
            this.participNameLabel = new System.Windows.Forms.Label();
            this.teamRancLabel = new System.Windows.Forms.Label();
            this.participantsListBox = new System.Windows.Forms.ListBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // participNameLabel
            // 
            this.participNameLabel.AutoSize = true;
            this.participNameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.participNameLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.participNameLabel.Location = new System.Drawing.Point(12, 9);
            this.participNameLabel.Name = "participNameLabel";
            this.participNameLabel.Size = new System.Drawing.Size(132, 16);
            this.participNameLabel.TabIndex = 0;
            this.participNameLabel.Text = "Заявка команди";
            // 
            // teamRancLabel
            // 
            this.teamRancLabel.AutoSize = true;
            this.teamRancLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teamRancLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.teamRancLabel.Location = new System.Drawing.Point(12, 38);
            this.teamRancLabel.Name = "teamRancLabel";
            this.teamRancLabel.Size = new System.Drawing.Size(112, 16);
            this.teamRancLabel.TabIndex = 1;
            this.teamRancLabel.Text = "Ранг команди";
            // 
            // participantsListBox
            // 
            this.participantsListBox.BackColor = System.Drawing.Color.ForestGreen;
            this.participantsListBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.participantsListBox.ForeColor = System.Drawing.Color.White;
            this.participantsListBox.FormattingEnabled = true;
            this.participantsListBox.ItemHeight = 16;
            this.participantsListBox.Location = new System.Drawing.Point(13, 67);
            this.participantsListBox.Name = "participantsListBox";
            this.participantsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.participantsListBox.Size = new System.Drawing.Size(280, 132);
            this.participantsListBox.TabIndex = 2;
            // 
            // closeBtn
            // 
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.closeBtn.Location = new System.Drawing.Point(168, 205);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(104, 32);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Закрити";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(205, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(102, 101);
            this.panel1.TabIndex = 5;
            // 
            // ParticipPropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(305, 246);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.participantsListBox);
            this.Controls.Add(this.teamRancLabel);
            this.Controls.Add(this.participNameLabel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(321, 285);
            this.MinimumSize = new System.Drawing.Size(321, 285);
            this.Name = "ParticipPropForm";
            this.Text = "Властивості";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label participNameLabel;
        private System.Windows.Forms.Label teamRancLabel;
        private System.Windows.Forms.ListBox participantsListBox;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Panel panel1;
    }
}