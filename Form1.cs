using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using To_Do_List_Project.Properties;
using static To_Do_List_Project.clsTask;

namespace To_Do_List_Project
{
    public partial class MainForm : Form
    {
        private List<clsTask> lsTasksMenue = new List<clsTask>();
        private string appDataPath;
        private string myAppFolder;
        private string FilePath;

        enum enViewMode
        {
            All=1,
            Achieved=2,
            High=3,
            Mid=4,
            Low=5
        };

        private enViewMode ViewMode = enViewMode.All;

        public MainForm()
        {
            InitializeComponent();
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            myAppFolder = Path.Combine(appDataPath, "Tasks");
            if (!Directory.Exists(myAppFolder))
            {
                Directory.CreateDirectory(myAppFolder); // أنشئ المجلد إذا لم يكن موجوداً
            }
            FilePath = Path.Combine(myAppFolder, "tasks.txt");
        }

        private bool SetTheListViewInTasksExistMode()
        {
            if (lsTasksMenue.Count == 0)
            {
                return false;
            }

            menuStrip1.Enabled = true;
            pictureBox1.BackgroundImage = Resources.task__1_;

            label1.Visible = false;
            listView1.Visible = true;
            return true;
        }

        private int GetPriorityImageIndex(string TaskPriority)
        {
            switch(TaskPriority.ToLower())
            {
                case "low":
                    return 0;
                case "medium":
                    return 1;
                case "high":
                    return 2;
                default:
                    return 0;
            }
        }

        private clsTask ConvertDataTaskLineToRecord(string[] DataLine)
        {
           
            clsTask.enTaskPriority TaskPriority;
            bool isChecked;

            string TaskName = DataLine[0];

           
            Enum.TryParse<clsTask.enTaskPriority>(DataLine[1], out TaskPriority);

            string DataTime = DataLine[2];

            Boolean.TryParse(DataLine[3], out isChecked);

            clsTask tempTask = new clsTask(TaskName, TaskPriority);
            tempTask.SetDate(DataTime);
            tempTask.SetisChecked(isChecked);

            return tempTask;
           
        }

        private void LoadTasksFromFile()
        {
            if(File.Exists(FilePath))
            {
                string[] Lines = File.ReadAllLines(FilePath);

                for (int i=Lines.Length-1;i>=0;i--)
                {
                    string[] Parts = Lines[i].Split(new string[] { "#//#" }, StringSplitOptions.None);  // done

                    if (Parts.Length == 4)
                    {
                        lsTasksMenue.Add(ConvertDataTaskLineToRecord(Parts));
                    }
                }
            }

        }
        private void LoadTasksToListView()
        {
            LoadTasksFromFile();

            if (!SetTheListViewInTasksExistMode())
            {
                if (lsTasksMenue.Count == 0)
                {
                    btnDeleteAll.Enabled = false;
                }
                return;
            }

           

            listView1.Items.Clear();
            foreach (clsTask tempTask in lsTasksMenue)
            {
                ListViewItem tempItem = new ListViewItem(tempTask.GetTaskName());
                tempItem.ImageIndex = GetPriorityImageIndex(tempTask.GetTaskPriority().ToString());
                tempItem.SubItems.Add(tempTask.GetDate());
                if(tempTask.GetisChecked())
                {
                    tempItem.Checked = true;
                }

                tempItem.Tag = tempTask;

                listView1.Items.Add(tempItem);

                
            }
        }

        private void AddTask(clsTask Task)
        {
            lsTasksMenue.Insert(0,Task); 

            AddTasksToFile(ConvertTaskToDataLine(Task));

            ListViewItem tempItem = new ListViewItem(Task.GetTaskName());
            tempItem.ImageIndex = GetPriorityImageIndex(Task.GetTaskPriority().ToString());
            tempItem.SubItems.Add(Task.GetDate().ToString());
            tempItem.Tag = Task;

            listView1.Items.Insert(0, tempItem);

            
            SetTheListViewInTasksExistMode();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lsTasksMenue.Clear();
            LoadTasksToListView();
            //DimmerPanel.SendToBack();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            btnDeleteAll.Enabled = true;

            AddTaskForm frm = new AddTaskForm();
            //DimmerPanel.BackColor = Color.FromArgb(100, 0, 0, 0); 
            //DimmerPanel.Visible = true;

            frm.Owner = this;
            if(frm.ShowDialog()==DialogResult.OK)
            {
               
                clsTask Task = new clsTask(frm.GetTaskName(),(clsTask.enTaskPriority)frm.GetTaskPriority());
                AddTask(Task);
            }
            //DimmerPanel.Visible = false;
        }

       
        private string ConvertTaskToDataLine(clsTask tempTask)
        {
            string DataTask = "";
            DataTask += tempTask.GetTaskName() + "#//#";
            DataTask += tempTask.GetTaskPriority() + "#//#";
            DataTask += tempTask.GetDate() + "#//#";
            DataTask += tempTask.GetisChecked();

            return DataTask;
        }

        private void AddTasksToFile(string DataTask)
        {
            if (!File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, DataTask+'\n');
                return;
            }
            else
            {
                File.AppendAllText(FilePath, DataTask+'\n');
            }

        }
        private void UpdateTasksInFile()
        {
            if (File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, "");

                for(int i=lsTasksMenue.Count-1;i>=0;i--)
                {
                    File.AppendAllText(FilePath, ConvertTaskToDataLine(lsTasksMenue[i])+'\n');
                }
               
            }


        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            

            ListViewItem tempItem = listView1.Items[e.Index];

            if(tempItem.Tag is clsTask Task)
            {
                if(e.NewValue==CheckState.Checked)
                {
                    Task.SetisChecked(true);
                }
                else
                {
                    Task.SetisChecked(false);
                }


                UpdateTasksInFile();
            }

        }

        private bool SetTheListViewInTasksNotExistMode()
        {
            if (lsTasksMenue.Count == 0)
            { 
                pictureBox1.BackgroundImage = Resources.no_task;

                label1.Visible = true;
                listView1.Visible = false;
                menuStrip1.Enabled = false;
                return true;
            }
            else
                return false;
        }

        private bool SetTheListViewInTasksNotExistModeForViewMode()
        {
            if (listView1.Items.Count == 0)
            {
                pictureBox1.BackgroundImage = Resources.no_task;

                label1.Visible = true;
                label1.Text = $"Oops!,\n There is no tasks in {ViewMode} \nview mode";
                listView1.Visible = false;
                return true;
            }
            else
            {
                SetTheListViewInTasksExistMode();
                return false;
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            ViewMode = enViewMode.All;

            if(listView1.Items.Count==0)
            {
                SetTheListViewInTasksNotExistMode();
                return;
            }


            lsTasksMenue.Clear();
            listView1.Items.Clear();
            SetTheListViewInTasksNotExistMode();
            File.WriteAllText(FilePath, "");
            btnDeleteAll.Enabled = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem SelectedItem in listView1.SelectedItems)
            {
                int IndexToDelete = SelectedItem.Index;
                SelectedItem.Remove();
                for(int i=0;i<lsTasksMenue.Count;i++)
                {
                    if(i==IndexToDelete)
                    {
                        lsTasksMenue.Remove(lsTasksMenue[i]);
                        break;
                    }
                }
            }

            if(lsTasksMenue.Count==0)
            {
                SetTheListViewInTasksNotExistMode();
            }

            UpdateTasksInFile();

        }

        private void taskNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count>1)
            {
                MessageBox.Show("Choose One Task To Edit", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            int IndexToEdit = listView1.SelectedItems[0].Index;

            for(int i=0;i<lsTasksMenue.Count;i++)
            {
                if (IndexToEdit==i)
                {
                    AddTaskForm frm = new AddTaskForm(true, false);
                    //this.Visible = false;
                    frm.Owner = this;
                    frm.Text = "Editing Task Name";
                    if(frm.ShowDialog()==DialogResult.OK)
                    {
                        string PreviousTaskName = lsTasksMenue[i].GetTaskName();
                        lsTasksMenue[i].SetTaskName(frm.GetTaskName());
                        MessageBox.Show($"Your Task Name Changed From {PreviousTaskName} To {frm.GetTaskName()} Successfully", "Done!", MessageBoxButtons.OK);
                        UpdateTasksInFile();
                        listView1.SelectedItems[0].Text = frm.GetTaskName();
                        //this.Visible = true;
                        return;
                    }

                }
            }
        }

        private void priorityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 1)
            {
                MessageBox.Show("Choose One Task To Edit", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            int IndexToEdit = listView1.SelectedItems[0].Index;

            for (int i = 0; i < lsTasksMenue.Count; i++)
            {
                if (IndexToEdit == i)
                {
                    AddTaskForm frm = new AddTaskForm(false, true);
                    //this.Visible = false;
                    frm.Owner = this;
                    frm.Text = "Editing Task Priority";
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string PreviousTaskPriority = lsTasksMenue[i].GetTaskPriority().ToString();
                        lsTasksMenue[i].EditTaskPriority((enTaskPriority)frm.GetTaskPriority());
                        MessageBox.Show($"Your Task Priority Changed From {PreviousTaskPriority} To {(enTaskPriority)frm.GetTaskPriority()} Successfully", "Done!", MessageBoxButtons.OK);
                        UpdateTasksInFile();
                        listView1.SelectedItems[0].ImageIndex = GetPriorityImageIndex(((enTaskPriority)frm.GetTaskPriority()).ToString());
                        //this.Visible = true;
                        return;
                    }

                }
            }
        }

        private void achievedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMode = enViewMode.Achieved;
            listView1.CheckBoxes = false;
            listView1.Items.Clear();
            foreach(clsTask tempTask in lsTasksMenue)
            {
                if(tempTask.GetisChecked())
                {
                    ListViewItem TempItem = new ListViewItem(tempTask.GetTaskName());
                    TempItem.ImageIndex = GetPriorityImageIndex(tempTask.GetTaskPriority().ToString());
                    TempItem.SubItems.Add(tempTask.GetDate());
                    TempItem.Checked = tempTask.GetisChecked();
                    TempItem.Tag = tempTask;
                    listView1.Items.Add(TempItem);
                }
            }

            SetTheListViewInTasksNotExistModeForViewMode();

            btnAddTask.Enabled = false;
            btnDeleteAll.Enabled = false;
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMode = enViewMode.All;
            listView1.CheckBoxes = true;
            listView1.Items.Clear();
            foreach (clsTask tempTask in lsTasksMenue)
            {
                ListViewItem TempItem = new ListViewItem(tempTask.GetTaskName());
                TempItem.ImageIndex = GetPriorityImageIndex(tempTask.GetTaskPriority().ToString());
                TempItem.SubItems.Add(tempTask.GetDate());
                TempItem.Checked = tempTask.GetisChecked();
                TempItem.Tag = tempTask;
                listView1.Items.Add(TempItem);
            }

            SetTheListViewInTasksNotExistModeForViewMode();

            btnAddTask.Enabled = true;
            btnDeleteAll.Enabled = true;
        }

       
        private void urgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMode = enViewMode.High;
            listView1.CheckBoxes = false;
            listView1.Items.Clear();
            foreach (clsTask tempTask in lsTasksMenue)
            {
                if (tempTask.GetTaskPriority() == clsTask.enTaskPriority.High)
                {
                    ListViewItem TempItem = new ListViewItem(tempTask.GetTaskName());
                    TempItem.ImageIndex = GetPriorityImageIndex(tempTask.GetTaskPriority().ToString());
                    TempItem.SubItems.Add(tempTask.GetDate());
                    TempItem.Checked = tempTask.GetisChecked();
                    TempItem.Tag = tempTask;
                    listView1.Items.Add(TempItem);
                }
            }

            SetTheListViewInTasksNotExistModeForViewMode();

            btnAddTask.Enabled = false;
            btnDeleteAll.Enabled = false;
        }

        private void midToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMode = enViewMode.Mid;
            listView1.CheckBoxes = false;
            listView1.Items.Clear();
            foreach (clsTask tempTask in lsTasksMenue)
            {
                if (tempTask.GetTaskPriority() == clsTask.enTaskPriority.Medium)
                {
                    ListViewItem TempItem = new ListViewItem(tempTask.GetTaskName());
                    TempItem.ImageIndex = GetPriorityImageIndex(tempTask.GetTaskPriority().ToString());
                    TempItem.SubItems.Add(tempTask.GetDate());
                    TempItem.Checked = tempTask.GetisChecked();
                    TempItem.Tag = tempTask;
                    listView1.Items.Add(TempItem);
                }
            }

            SetTheListViewInTasksNotExistModeForViewMode();

            btnAddTask.Enabled = false;
            btnDeleteAll.Enabled = false;
        }

        private void lowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMode = enViewMode.Low;
            listView1.CheckBoxes = false;
            listView1.Items.Clear();
            foreach (clsTask tempTask in lsTasksMenue)
            {
                if (tempTask.GetTaskPriority() == clsTask.enTaskPriority.Low)
                {
                    ListViewItem TempItem = new ListViewItem(tempTask.GetTaskName());
                    TempItem.ImageIndex = GetPriorityImageIndex(tempTask.GetTaskPriority().ToString());
                    TempItem.SubItems.Add(tempTask.GetDate());
                    TempItem.Checked = tempTask.GetisChecked();
                    TempItem.Tag = tempTask;
                    listView1.Items.Add(TempItem);
                }
            }

            SetTheListViewInTasksNotExistModeForViewMode();

            btnAddTask.Enabled = false;
            btnDeleteAll.Enabled = false;
        }

        private void btnMyGitHub_Click(object sender, EventArgs e)
        {
            string githubUrl = "https://github.com/Yusuf200526";

           
            Process.Start(githubUrl);
        }

        
    }
}
