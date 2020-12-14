namespace DBTaskAssistant.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using DevExpress.Mvvm;
    using Microsoft.EntityFrameworkCore;

    public class MainVM : ViewModelBase
    {
        private TaskAssistantContext taskADB;
        private Task _CurrTask;
        User currentUser;

        public ObservableCollection<Task> Tasks { get; set; }

        public MainVM() { }

        public MainVM(User loggedUser)
        {
            currentUser = loggedUser;
            taskADB = new TaskAssistantContext();
            Tasks = new ObservableCollection<Task>(taskADB.Users.Include(u => u.Tasks).FirstOrDefault(u => u.Username == loggedUser.Username).Tasks);
        }

        public Task CurrTask
        {
            get
            {
                return _CurrTask;
            }

            set
            {
                _CurrTask = value;
                this.RaisePropertyChanged(() => _CurrTask);
            }
        }

        public void Delete()
        {
            if (CurrTask != null)
            {
                taskADB.Tasks.Remove(taskADB.Tasks.Find(CurrTask.Id));
                taskADB.SaveChanges();
                Tasks.Remove(CurrTask);
            }
        }

        public void UpdateTasks()
        {
            Tasks = new ObservableCollection<Task>(taskADB.Users.Include(u => u.Tasks).FirstOrDefault(u => u.Username == currentUser.Username).Tasks);
        }

        public void SortByPriority()
        {
            for (int i = 1; i < Tasks.Count; i++)
            {
                for (int j = 0; j < Tasks.Count; j++)
                {
                    if (Tasks[j].Priority > Tasks[i].Priority)
                    {
                        Task currtask = Tasks[i];
                        Tasks[i] = Tasks[j];
                        Tasks[j] = currtask;
                    }
                }
            }
        }

        public void SortByTime()
        {
            for (int i = 1; i < Tasks.Count; i++)
            {
                for (int j = 0; j < Tasks.Count; j++)
                {
                    if (Tasks[j].Date > Tasks[i].Date)
                    {
                        Task currtask = Tasks[i];
                        Tasks[i] = Tasks[j];
                        Tasks[j] = currtask;
                    }
                }
            }
        }
    }

    public partial class TaskModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private int id;

        private string note;

        private DateTime date;

        private int priority;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Username { get; set; }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
                OnPropertyChanged("Note");
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public int Priority
        {
            get
            {
                return priority;
            }

            set
            {
                priority = value;
                OnPropertyChanged("Priority");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "Note":
                        if (Note.Length < 5 || Note.Length > 300)
                        {
                            result = "Note must contain 5-300 symbols";
                        }

                        break;
                    case "Priority":
                        if (Priority < 1 || Priority > 10)
                        {
                            result = "Priority must be more than 1, less than 10";
                        }

                        break;
                }

                if (ErrorCollection.ContainsKey(columnName))
                {
                    ErrorCollection[columnName] = result;
                }
                else if (result != null)
                {
                    ErrorCollection.Add(columnName, result);
                }

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
