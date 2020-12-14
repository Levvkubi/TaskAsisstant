namespace TaskAssistant
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Documents;
    using DBTaskAssistant;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class that adds logic to SignIn View.
    /// </summary>
    public partial class SignIn : Window
    {
        private TaskAssistantContext taskADB;

        private string tagText;

        public SignIn()
        {
            InitializeComponent();
            tagText = PassBox.Tag.ToString();
        }

        private void PassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PassBox.Password.Length == 0)
            {
                PassBox.Tag = tagText;
            }
            else
            {
                PassBox.Tag = string.Empty;
            }
        }

        private void regist_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            this.Close();
            registration.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
#if DEBUG
            if (this.usernameBox.Text == "a")
            {
                usernameBox.Text = "kos@gmail.com";
                this.PassBox.Password = "qwerty123";
            }
#endif
            taskADB = new TaskAssistantContext();

            var loggedUserTasks = taskADB.Users.Include(u => u.Tasks).FirstOrDefault(u => u.Username == usernameBox.Text).Tasks;

            var loggedUser = from u in taskADB.Users.ToList() // !!! taskADB.Users.ToList() не має списку тасків
                             where u.Username == usernameBox.Text && DataGenerator.GetSaltHash(PassBox.Password, u.Salt) == u.Password
                             select u;

            if (loggedUser.Any())
            {
                MainView mainPage = new MainView(loggedUser.ToList().FirstOrDefault());
                mainPage.Show();
                this.Close();
            }
            else
            {
                usernameErrorBloc.Text = "Enter correct data!";
            }
        }
    }
}
