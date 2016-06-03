namespace CompetitionsManager
{
    partial class TeamPropertiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamPropertiesForm));
            this.teamNameLabel = new System.Windows.Forms.Label();
            this.teamCouchLabel = new System.Windows.Forms.Label();
            this.teammatesListBox = new System.Windows.Forms.ListBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // teamNameLabel
            // 
            this.teamNameLabel.AutoSize = true;
            this.teamNameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teamNameLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.teamNameLabel.Location = new System.Drawing.Point(12, 19);
            this.teamNameLabel.Name = "teamNameLabel";
            this.teamNameLabel.Size = new System.Drawing.Size(93, 16);
            this.teamNameLabel.TabIndex = 0;
            this.teamNameLabel.Text = "team_name";
            // 
            // teamCouchLabel
            // 
            this.teamCouchLabel.AutoSize = true;
            this.teamCouchLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teamCouchLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.teamCouchLabel.Location = new System.Drawing.Point(12, 45);
            this.teamCouchLabel.Name = "teamCouchLabel";
            this.teamCouchLabel.Size = new System.Drawing.Size(53, 16);
            this.teamCouchLabel.TabIndex = 1;
            this.teamCouchLabel.Text = "coach";
            // 
            // teammatesListBox
            // 
            this.teammatesListBox.BackColor = System.Drawing.Color.ForestGreen;
            this.teammatesListBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teammatesListBox.ForeColor = System.Drawing.Color.White;
            this.teammatesListBox.FormattingEnabled = true;
            this.teammatesListBox.ItemHeight = 16;
            this.teammatesListBox.Location = new System.Drawing.Point(12, 74);
            this.teammatesListBox.Name = "teammatesListBox";
            this.teammatesListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.teammatesListBox.Size = new System.Drawing.Size(332, 164);
            this.teammatesListBox.TabIndex = 2;
            // 
            // closeBtn
            // 
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.closeBtn.Location = new System.Drawing.Point(207, 244);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(137, 34);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Закрити";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(207, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 120);
            this.panel1.TabIndex = 4;
            // 
            // TeamPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(356, 285);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.teammatesListBox);
            this.Controls.Add(this.teamCouchLabel);
            this.Controls.Add(this.teamNameLabel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(372, 324);
            this.MinimumSize = new System.Drawing.Size(372, 324);
            this.Name = "TeamPropertiesForm";
            this.Text = "Властивості";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label teamNameLabel;
        private System.Windows.Forms.Label teamCouchLabel;
        private System.Windows.Forms.ListBox teammatesListBox;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Panel panel1;
    }
}