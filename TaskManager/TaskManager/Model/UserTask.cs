using System;
using System.ComponentModel;


namespace TaskManager.Models
{
    /// <summary>
    /// ClassName: UserTask
    /// Model to replicate type task with TaskID, TaskName, DueDate and Status properties
    /// </summary>
    public class UserTask : INotifyPropertyChanged
    {
        private int _taskid;
        private string _taskname;
        private DateTime _duedate = DateTime.Today;
        private string _status;
        public int TaskID
        {
            get
            {
                return _taskid;
            }
            set
            {
                _taskid = value;

            }
        }
        public string TaskName
        {
            get
            {
                return _taskname;
            }
            set
            {
                _taskname = value;
                OnPropertyChanged("TaskName");
            }
        }
        public DateTime DueDate
        {
            get
            {
                return _duedate;
            }
            set
            {
                _duedate = value;
                OnPropertyChanged("DueDate");
            }
        }
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
            {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }
    }
}
