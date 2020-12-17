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

    /// <summary>
    /// Class that adds logic to Main form.
    /// </summary>
    public class MainVM : ViewModelBase
    {
        private TaskAssistantContext taskADB;
        private Task currTask;
        private User currentUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        public MainVM() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        /// <param name="loggedUser">User that is logged.</param>
        public MainVM(User loggedUser)
        {
            currentUser = loggedUser;
            taskADB = new TaskAssistantContext();
            Tasks = new ObservableCollection<Task>(taskADB.Users.Include(u => u.Tasks).FirstOrDefault(u => u.Username == loggedUser.Username).Tasks);
        }

        /// <summary>
        /// Gets or sets Task collection.
        /// </summary>
        public ObservableCollection<Task> Tasks { get; set; }

        /// <summary>
        /// Gets or sets current task value.
        /// </summary>
        public Task CurrTask
        {
            get
            {
                return currTask;
            }

            set
            {
                currTask = value;
                this.RaisePropertyChanged(() => currTask);
            }
        }

        /// <summary>
        /// Function that is used to delete chosen task.
        /// </summary>
        public void Delete()
        {
            if (CurrTask != null)
            {
                taskADB.Tasks.Remove(taskADB.Tasks.Find(CurrTask.Id));
                taskADB.SaveChanges();
                Tasks.Remove(CurrTask);
            }
        }

        /// <summary>
        /// Function that is used to sort tasks by priority.
        /// </summary>
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

        /// <summary>
        /// Function that is used to sort tasks by time.
        /// </summary>
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
}
