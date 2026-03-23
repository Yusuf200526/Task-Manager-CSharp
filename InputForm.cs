using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;

namespace To_Do_List_Project
{
    public partial class AddTaskForm : Form
    {
        private bool _InEditingTaskNameMode, _InEditingTaskPriorityMode;

        public AddTaskForm()
        {
            InitializeComponent();
        }

        public AddTaskForm(bool InEditingTaskNameMode,bool InEditingTaskPriorityMode)
        {
            InitializeComponent();

            _InEditingTaskNameMode = InEditingTaskNameMode;
            _InEditingTaskPriorityMode = InEditingTaskPriorityMode;
        }

        public string GetTaskName()
        {
            return txtAddTask.Text;
        }

        public byte GetTaskPriority()
        {
            return Convert.ToByte(cbTaskPriorities.SelectedIndex);
        }

        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            if(_InEditingTaskNameMode)
            {
                if (string.IsNullOrEmpty(txtAddTask.Text))
                {
                    MessageBox.Show("Please Add Task", "Warning", MessageBoxButtons.OK);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
                return;

            }

            if (_InEditingTaskPriorityMode)
            {

                if (cbTaskPriorities.SelectedIndex == -1)
                {
                    errorProviderInAddTaskForm.SetError(cbTaskPriorities, "This Field Is Required");
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
                return;

            }



            if (string.IsNullOrEmpty(txtAddTask.Text))
            {
                MessageBox.Show("Please Add Task", "Warning", MessageBoxButtons.OK);
                return;
            }

            if(cbTaskPriorities.SelectedIndex==-1)
            {
                errorProviderInAddTaskForm.SetError(cbTaskPriorities, "This Field Is Required");
                return;
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Owner.Visible = true;
            this.Close();
        }

        private void AddTaskForm_Load(object sender, EventArgs e)
        {
            if(_InEditingTaskPriorityMode)
            {
                this.txtAddTask.Enabled = false;
                this.btnReturn.Enabled = false;
            }
            else if(_InEditingTaskNameMode)
            {
                this.cbTaskPriorities.Enabled = false;
                this.btnReturn.Enabled = false;
            }
            else
            {
                this.txtAddTask.Enabled = true;
                this.cbTaskPriorities.Enabled = true;
            }
            
        }

        

        private void cbTaskPriorities_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProviderInAddTaskForm.SetError(cbTaskPriorities, "");
        }
    }
}
