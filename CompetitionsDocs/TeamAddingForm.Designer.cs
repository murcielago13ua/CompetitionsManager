namespace CompetitionsManager
{
    partial class TeamAddingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamAddingForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.teamsPage = new System.Windows.Forms.TabPage();
            this.closeBtn = new System.Windows.Forms.Button();
            this.choseBtn = new System.Windows.Forms.Button();
            this.teamsListBox = new System.Windows.Forms.ListBox();
            this.sportsmansPage = new System.Windows.Forms.TabPage();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addParticipBtn = new System.Windows.Forms.Button();
            this.turistoCLBox = new System.Windows.Forms.CheckedListBox();
            this.tabControl.SuspendLayout();
            this.teamsPage.SuspendLayout();
            this.sportsmansPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.teamsPage);
            this.tabControl.Location = new System.Drawing.Point(1, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(326, 284);
            this.tabControl.TabIndex = 0;
            // 
            // teamsPage
            // 
            this.teamsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.teamsPage.Controls.Add(this.closeBtn);
            this.teamsPage.Controls.Add(this.choseBtn);
            this.teamsPage.Controls.Add(this.teamsListBox);
            this.teamsPage.Location = new System.Drawing.Point(4, 22);
            this.teamsPage.Name = "teamsPage";
            this.teamsPage.Padding = new System.Windows.Forms.Padding(3);
            this.teamsPage.Size = new System.Drawing.Size(318, 258);
            this.teamsPage.TabIndex = 0;
            this.teamsPage.Text = "Команди";
            // 
            // closeBtn
            // 
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeBtn.Location = new System.Drawing.Point(192, 212);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(120, 40);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Text = "    Закрити";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // choseBtn
            // 
            this.choseBtn.FlatAppearance.BorderSize = 0;
            this.choseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choseBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.choseBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.choseBtn.Image = ((System.Drawing.Image)(resources.GetObject("choseBtn.Image")));
            this.choseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.choseBtn.Location = new System.Drawing.Point(8, 213);
            this.choseBtn.Name = "choseBtn";
            this.choseBtn.Size = new System.Drawing.Size(131, 40);
            this.choseBtn.TabIndex = 1;
            this.choseBtn.Text = "   Заявити";
            this.choseBtn.UseVisualStyleBackColor = true;
            this.choseBtn.Click += new System.EventHandler(this.choseBtn_Click);
            // 
            // teamsListBox
            // 
            this.teamsListBox.BackColor = System.Drawing.Color.ForestGreen;
            this.teamsListBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teamsListBox.ForeColor = System.Drawing.Color.White;
            this.teamsListBox.FormattingEnabled = true;
            this.teamsListBox.ItemHeight = 16;
            this.teamsListBox.Location = new System.Drawing.Point(7, 7);
            this.teamsListBox.Name = "teamsListBox";
            this.teamsListBox.Size = new System.Drawing.Size(306, 196);
            this.teamsListBox.TabIndex = 0;
            // 
            // sportsmansPage
            // 
            this.sportsmansPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.sportsmansPage.Controls.Add(this.cancelBtn);
            this.sportsmansPage.Controls.Add(this.addParticipBtn);
            this.sportsmansPage.Controls.Add(this.turistoCLBox);
            this.sportsmansPage.Location = new System.Drawing.Point(4, 22);
            this.sportsmansPage.Name = "sportsmansPage";
            this.sportsmansPage.Padding = new System.Windows.Forms.Padding(3);
            this.sportsmansPage.Size = new System.Drawing.Size(318, 258);
            this.sportsmansPage.TabIndex = 1;
            this.sportsmansPage.Text = "tabPage2";
            // 
            // cancelBtn
            // 
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.cancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.Image")));
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.Location = new System.Drawing.Point(179, 209);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(130, 41);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "    Відмінити";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addParticipBtn
            // 
            this.addParticipBtn.FlatAppearance.BorderSize = 0;
            this.addParticipBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addParticipBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addParticipBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.addParticipBtn.Image = ((System.Drawing.Image)(resources.GetObject("addParticipBtn.Image")));
            this.addParticipBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addParticipBtn.Location = new System.Drawing.Point(7, 212);
            this.addParticipBtn.Name = "addParticipBtn";
            this.addParticipBtn.Size = new System.Drawing.Size(129, 40);
            this.addParticipBtn.TabIndex = 3;
            this.addParticipBtn.Text = "      Заявити \r\n     учасників";
            this.addParticipBtn.UseVisualStyleBackColor = true;
            this.addParticipBtn.Click += new System.EventHandler(this.addParticipBtn_Click);
            // 
            // turistoCLBox
            // 
            this.turistoCLBox.BackColor = System.Drawing.Color.ForestGreen;
            this.turistoCLBox.ForeColor = System.Drawing.Color.White;
            this.turistoCLBox.FormattingEnabled = true;
            this.turistoCLBox.Location = new System.Drawing.Point(7, 6);
            this.turistoCLBox.Name = "turistoCLBox";
            this.turistoCLBox.Size = new System.Drawing.Size(302, 199);
            this.turistoCLBox.TabIndex = 2;
            // 
            // TeamAddingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 286);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(342, 325);
            this.MinimumSize = new System.Drawing.Size(342, 325);
            this.Name = "TeamAddingForm";
            this.Text = "Незаявлені команди";
            this.tabControl.ResumeLayout(false);
            this.teamsPage.ResumeLayout(false);
            this.sportsmansPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage teamsPage;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button choseBtn;
        private System.Windows.Forms.ListBox teamsListBox;
        private System.Windows.Forms.TabPage sportsmansPage;
        private System.Windows.Forms.Button addParticipBtn;
        private System.Windows.Forms.CheckedListBox turistoCLBox;
        private System.Windows.Forms.Button cancelBtn;
    }
}