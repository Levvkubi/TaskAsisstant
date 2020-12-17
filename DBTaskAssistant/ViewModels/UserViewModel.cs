namespace DBTaskAssistant.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Class that is used to store user info in specific collection.
    /// </summary>
    public class UserViewModel : INotifyPropertyChanged
    {
        private TaskAssistantContext taskADB;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserViewModel"/> class.
        /// </summary>
        public UserViewModel()
        {
            this.taskADB = new TaskAssistantContext();
            this.Users = new ObservableCollection<User>(taskADB.Users.ToList());
        }

        /// <summary>
        /// Occurs when a property value is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the collection of users.
        /// </summary>
        public ObservableCollection<User> Users { get; set; }

        /// <summary>
        /// Function that changes value in a form.
        /// </summary>
        /// <param name="prop">Value that changes.</param>
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
