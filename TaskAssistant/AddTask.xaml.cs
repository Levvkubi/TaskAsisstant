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

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTask"/> class.
        /// </summary>
        /// <param name="loggedUser">User that is logged.</param>
        /// <param name="tasks">Collection of tasks of current user.</param>
        public AddTask(User loggedUser, ObservableCollection<Task> tasks)
        {
            InitializeComponent();
            taskADB = new TaskAssistantContext();
            currentUser = loggedUser;
            addVM = (AddVM)DataContext;
            taskList = tasks;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int index = taskADB.Tasks.Count() + 10;
            Random rnd = new Random();

            TaskModel newTask = new TaskModel();
            newTask.Note = Note.Text;
            newTask.Date = new DateTime(addVM.Date.Year, addVM.Date.Month, addVM.Date.Day, addVM.CurrHour, addVM.CurrMinute, 1);
            newTask.Priority = Convert.ToInt32(addVM.Priority);
            newTask.Id = index++;

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
