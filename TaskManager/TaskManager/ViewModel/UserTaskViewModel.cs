using System;
using System.ComponentModel;
using TaskManager.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManager.Command;

namespace TaskManager.ViewModel
{
    public class UserTaskViewModel : INotifyPropertyChanged
    {

        private UserTask _userTask;
        private string _appMessage =string.Empty;

        public string AppMessage
        {
            get
            {
                return _appMessage;
            }
            set
            {
                _appMessage = value;
                NotifyPropertyChanged("AppMessage");
            }
        }

        public UserTask UserTask
        {
            get { return _userTask; }
            set { _userTask = value; NotifyPropertyChanged("UserTask"); }
        }

        
        private ObservableCollection<UserTask> _usertasks;
        public ObservableCollection<UserTask> UserTasks
        {
            get
            {
                return _usertasks;
            }
            set
            {
                _usertasks = value;
                NotifyPropertyChanged("UserTasks");
            }
        }
        private ICommand _CreateCommand;
        private ICommand _DeleteSelectedItem;
        private ICommand _UpdateSelectedItem;

        public ICommand CreateCommand
        {
            get
            {
                if (_CreateCommand == null)
                {
                    _CreateCommand = new RelayCommand(CreateExecute, CanCreateExecute, false);
                    Console.WriteLine(AppMessage);
                }
                return _CreateCommand;
            }

        }

        public ICommand DeleteSelectedItem
        {
            get
            {
                if (_DeleteSelectedItem == null)
                {
                    _DeleteSelectedItem = new RelayCommand(DeleteItem, CanDeleteExecute, false);
                }
                return _DeleteSelectedItem;
            }
        }

        public ICommand UpdateSelectedItem
        {
            get
            {
                if (_UpdateSelectedItem == null)
                {
                    _UpdateSelectedItem = new RelayCommand(UpdateItem, CanCreateExecute, false);
                }
                return _UpdateSelectedItem;
            }
        }


        /// <summary>
        /// Method: UpdateItem
        /// Parameters: UserTask.TaskID
        /// Description: Deletes an object of type UserTask with requested TaskID and removes it from in ObservableCollection called UserTasks
        /// </summary>
        private void DeleteItem(object parameter)
        {
            //var taskId = SelectedRow.TaskID;
            foreach (UserTask uTask in UserTasks)
            {
                if (uTask.TaskID == (int)parameter)
                { 
                    UserTasks.Remove(uTask);
                    AppMessage = "Task has been deleted";
                    break;
                }
            }
        }

        /// <summary>
        /// Method: UpdateItem
        /// Parameters: Object
        /// Description: Updates an object of type UserTask  present in ObservableCollection called UserTasks
        /// </summary>
        private void UpdateItem(object parameter)
        {
            foreach (UserTask uTask in UserTasks)
            {
                if(uTask.TaskID == UserTask.TaskID)
                {
                    uTask.TaskName = UserTask.TaskName;
                    uTask.Status = UserTask.Status;
                    uTask.DueDate = UserTask.DueDate;
                    // If task is past due date, and mentioned as Pending, then mark status as Overdue
                    if (uTask.DueDate < DateTime.Today && uTask.Status != "Completed" )
                        uTask.Status = "Overdue";
                    AppMessage = " Task has been updated as requested";
                    return;
                }
            }
            AppMessage = "Task with Task ID requested for update does not exist, please create a new Task";
        }
        


        /// <summary>
        /// Initialise the UserTaskViewModel() and UserTask objects
        /// </summary>
        public UserTaskViewModel()
        {
            UserTask = new UserTask();
            UserTasks = new ObservableCollection<UserTask>();
        }

        /// <summary>
        /// Method: CreateExecute
        /// Parameters: Object
        /// Description: Creates an object of type UserTask and adds it to ObservableCollection called UserTasks
        /// </summary>
        private void CreateExecute(object parameter)
        {

            UserTask newTask= new UserTask();
            newTask.TaskID = UserTask.TaskID;
            newTask.TaskName = UserTask.TaskName;           
            newTask.Status = UserTask.Status;
            newTask.DueDate = UserTask.DueDate.Date;
            // If task is past due date, and mentioned as Pending, then mark status as Overdue
            if (newTask.DueDate < DateTime.Today && newTask.Status != "Completed")
                newTask.Status = "Overdue";

            foreach (UserTask uTask in UserTasks)
            {
                if (uTask.TaskID == UserTask.TaskID)
                {
                    AppMessage = "Task with same Task ID already exists, please create new Task";
                    return;
                }
            }

            UserTasks.Add(newTask);
            AppMessage = string.Empty;
        }


        /// <summary>
        /// Method: CanDeleteExecute
        /// Parameters: object
        /// Description: Checks if the Delete button should be enabled/disabled. In this scenario, it will be enabled always.
        /// </summary>
        private bool CanDeleteExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Method: CanCreateExecute
        /// Parameters: object
        /// Description: Checks if the Create and Update button should be enabled/disabled. In this scenario, it will be enabled if Task ID is populated. Else,
        /// it will not allow the user to create/update the task without a TaskID
        /// </summary>
        private bool CanCreateExecute(object parameter)
        {
            if (Global.updatedTaskID)
                UserTask.TaskID = 0;
            if (UserTask.TaskID.ToString() == "0")
            {
                return false;
            }
            else
                return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
}
