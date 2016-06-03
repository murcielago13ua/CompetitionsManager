namespace CompetitionsManager
{
    partial class TeamResultForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamResultForm));
            this.stageResTable = new System.Windows.Forms.DataGridView();
            this.stage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.penalties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.distPenNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stageResTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distPenNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // stageResTable
            // 
            this.stageResTable.AllowDrop = true;
            this.stageResTable.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stageResTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.stageResTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.stageResTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stageResTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stageResTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stage,
            this.time,
            this.penalties,
            this.comment});
            this.stageResTable.Location = new System.Drawing.Point(12, 12);
            this.stageResTable.MultiSelect = false;
            this.stageResTable.Name = "stageResTable";
            this.stageResTable.RowHeadersVisible = false;
            this.stageResTable.RowTemplate.DividerHeight = 1;
            this.stageResTable.RowTemplate.Height = 25;
            this.stageResTable.Size = new System.Drawing.Size(763, 150);
            this.stageResTable.TabIndex = 0;
            this.stageResTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stageResTable_CellDoubleClick);
            this.stageResTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.stageResTable_CellEndEdit);
            // 
            // stage
            // 
            this.stage.HeaderText = "Етап";
            this.stage.Name = "stage";
            this.stage.ReadOnly = true;
            this.stage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.stage.Width = 300;
            // 
            // time
            // 
            this.time.HeaderText = "Час проходження";
            this.time.Name = "time";
            this.time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // penalties
            // 
            this.penalties.HeaderText = "Штрафні бали";
            this.penalties.Name = "penalties";
            this.penalties.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // comment
            // 
            this.comment.HeaderText = "Коментар";
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            this.comment.Width = 200;
            // 
            // saveBtn
            // 
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveBtn.Location = new System.Drawing.Point(12, 221);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(231, 33);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "    Зберегти результат";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(471, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Штрафи дистанції ";
            // 
            // distPenNumUpDown
            // 
            this.distPenNumUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distPenNumUpDown.Location = new System.Drawing.Point(628, 221);
            this.distPenNumUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.distPenNumUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.distPenNumUpDown.Name = "distPenNumUpDown";
            this.distPenNumUpDown.Size = new System.Drawing.Size(147, 23);
            this.distPenNumUpDown.TabIndex = 11;
            // 
            // cancelBtn
            // 
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.cancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.Image")));
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.Location = new System.Drawing.Point(306, 221);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(159, 33);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "   Відмінити";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // TeamResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(788, 261);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.distPenNumUpDown);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.stageResTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(804, 300);
            this.Name = "TeamResultForm";
            this.Text = "TeamResultFormDatagridcs";
            ((System.ComponentModel.ISupportInitialize)(this.stageResTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distPenNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView stageResTable;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown distPenNumUpDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn stage;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn penalties;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
        private System.Windows.Forms.Button cancelBtn;
    }
}