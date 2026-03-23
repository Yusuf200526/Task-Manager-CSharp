using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List_Project
{
    internal class clsTask
    {
        public enum enTaskPriority
        {
            Low=0,
            Medium=1,
            High=2
        };

        private byte _ID;
        private enTaskPriority _TaskPriority;
        private string _TaskName;
        private string _TaskTime;
        private bool _isChecked;

        public clsTask(string TaskName,enTaskPriority TaskPriority )
        {
            _TaskName = TaskName;
            _TaskPriority = TaskPriority;
            _TaskTime = DateTime.Now.ToString();
        }

        public void EditTaskName(string TaskName)
        {
            _TaskName = TaskName;
        }

        public void SetTaskName(string TaskName)
        {
            _TaskName = TaskName;
        }
        public string GetTaskName()
        {
            return _TaskName;
        }

        public void EditTaskPriority(enTaskPriority TaskPriority)
        {
            _TaskPriority = TaskPriority;
        }

        public enTaskPriority GetTaskPriority()
        {
            return _TaskPriority;
        }

        public string GetDate()
        {
            return _TaskTime;
        }

        public void SetDate(string Date)
        {
            _TaskTime = Date;
        }

        public bool GetisChecked()
        {
            return _isChecked;
        }

        public void SetisChecked(bool isChecked)
        {
            _isChecked = isChecked;
        }


    }
}
