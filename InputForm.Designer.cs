namespace To_Do_List_Project
{
    partial class AddTaskForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTaskForm));
            this.txtAddTask = new System.Windows.Forms.TextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnSaveTask = new System.Windows.Forms.Button();
            this.cbTaskPriorities = new System.Windows.Forms.ComboBox();
            this.errorProviderInAddTaskForm = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInAddTaskForm)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAddTask
            // 
            this.txtAddTask.AutoCompleteCustomSource.AddRange(new string[] {
            "Input"});
            this.txtAddTask.BackColor = System.Drawing.Color.LightGray;
            this.txtAddTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddTask.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddTask.Location = new System.Drawing.Point(12, 101);
            this.txtAddTask.Multiline = true;
            this.txtAddTask.Name = "txtAddTask";
            this.txtAddTask.Size = new System.Drawing.Size(402, 51);
            this.txtAddTask.TabIndex = 1;
            this.txtAddTask.Text = "Input new task here";
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::To_Do_List_Project.Properties.Resources._return;
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Location = new System.Drawing.Point(0, 3);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(73, 51);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnSaveTask
            // 
            this.btnSaveTask.BackgroundImage = global::To_Do_List_Project.Properties.Resources.task_list_add_svgrepo_com;
            this.btnSaveTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveTask.FlatAppearance.BorderSize = 0;
            this.btnSaveTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveTask.Location = new System.Drawing.Point(442, 165);
            this.btnSaveTask.Name = "btnSaveTask";
            this.btnSaveTask.Size = new System.Drawing.Size(95, 83);
            this.btnSaveTask.TabIndex = 3;
            this.btnSaveTask.TabStop = false;
            this.btnSaveTask.UseVisualStyleBackColor = true;
            this.btnSaveTask.Click += new System.EventHandler(this.btnSaveTask_Click);
            // 
            // cbTaskPriorities
            // 
            this.cbTaskPriorities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTaskPriorities.BackColor = System.Drawing.Color.Silver;
            this.cbTaskPriorities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTaskPriorities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTaskPriorities.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTaskPriorities.ForeColor = System.Drawing.Color.Black;
            this.cbTaskPriorities.FormattingEnabled = true;
            this.cbTaskPriorities.Items.AddRange(new object[] {
            "Low.",
            "Medium.",
            "High."});
            this.cbTaskPriorities.Location = new System.Drawing.Point(107, 188);
            this.cbTaskPriorities.Name = "cbTaskPriorities";
            this.cbTaskPriorities.Size = new System.Drawing.Size(211, 33);
            this.cbTaskPriorities.TabIndex = 2;
            this.cbTaskPriorities.Text = "Choose Priority.";
            this.cbTaskPriorities.SelectedIndexChanged += new System.EventHandler(this.cbTaskPriorities_SelectedIndexChanged);
            // 
            // errorProviderInAddTaskForm
            // 
            this.errorProviderInAddTaskForm.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderInAddTaskForm.ContainerControl = this;
            // 
            // AddTaskForm
            // 
            this.AcceptButton = this.btnSaveTask;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(549, 260);
            this.Controls.Add(this.cbTaskPriorities);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnSaveTask);
            this.Controls.Add(this.txtAddTask);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTaskForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adding Task";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddTaskForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInAddTaskForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddTask;
        private System.Windows.Forms.Button btnSaveTask;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.ComboBox cbTaskPriorities;
        private System.Windows.Forms.ErrorProvider errorProviderInAddTaskForm;
    }
}