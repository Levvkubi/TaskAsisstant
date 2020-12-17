namespace TaskAssistant
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using DBTaskAssistant;
    using DBTaskAssistant.Models;

    /// <summary>
    /// Class that adds logic to Add Task View.
    /// </summary>
    public partial class AddTask : Window
    {
        private AddVM addVM;
        private TaskAssistantContext taskADB;
        private User currentUser = new User();
        private ObservableCollection<Task> taskList;
        private Task oldTask = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTask"/> class.
        /// </summary>
        /// <param name="loggedUser">User that is logged.</param>
        /// <param name="tasks">Collection of tasks of current user.</param>
        /// <param name="oldtask">Task to change .</param>
        public AddTask(User loggedUser, ObservableCollection<Task> tasks, Task oldtask = null)
        {
            InitializeComponent();
            taskADB = new TaskAssistantContext();
            currentUser = loggedUser;
            addVM = (AddVM)DataContext;
            taskList = tasks;

            if (oldtask != null)
            {
                oldTask = oldtask;
                addVM.Note = oldTask.Note;
                addVM.Priority = oldtask.Priority;
                addVM.CurrHour = oldtask.Date.Hour;
                addVM.CurrMinute = oldtask.Date.Minute;
                addVM.Date = oldtask.Date.Date;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            TaskModel newTask = new TaskModel();

            newTask.Note = addVM.Note;
            newTask.Date = new DateTime(addVM.Date.Year, addVM.Date.Month, addVM.Date.Day, addVM.CurrHour, addVM.CurrMinute, 1);
            newTask.Priority = Convert.ToInt32(addVM.Priority);
            int index;
            if (oldTask == null)
            {
                index = taskADB.Tasks.Max(i => i.Id) + 1;
            }
            else
            {
                index = oldTask.Id;
                taskADB.Tasks.Remove(oldTask);
                taskList.Remove(oldTask);
            }

            newTask.Id = index;

            Task task = new Task(newTask.Id, currentUser.Username, newTask.Note, newTask.Date, newTask.Priority);

            currentUser.Tasks.Add(task);
            taskADB.Users.Find(currentUser.Username).Tasks.Add(task);
            taskADB.Tasks.Add(task);
            taskADB.SaveChanges();
            taskList.Add(task);
            this.Close();
        }
    }
}
