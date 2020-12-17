namespace TaskAssistant
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows;
    using DBTaskAssistant;
    using DBTaskAssistant.Models;

    /// <summary>
    /// Class that adds logic to Registration View.
    /// </summary>
    public partial class Registration : Window
    {
        private TaskAssistantContext taskADB;
        private string passtagText;
        private string conftagText;

        /// <summary>
        /// Initializes a new instance of the <see cref="Registration"/> class.
        /// </summary>
        public Registration()
        {
            this.InitializeComponent();
            passtagText = PassBox.Tag.ToString();
            conftagText = ConfPassBox.Tag.ToString();
        }

        private void PassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PassBox.Password.Length == 0)
            {
                PassBox.Tag = passtagText;
            }
            else
            {
                PassBox.Tag = string.Empty;
            }
        }

        private void ConfPassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (ConfPassBox.Password.Length == 0)
            {
                ConfPassBox.Tag = conftagText;
            }
            else
            {
                ConfPassBox.Tag = string.Empty;
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();
            this.Close();
            signIn.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.taskADB = new TaskAssistantContext();
            var salt = DataGenerator.GetRandStr(6, 6, true);
            var userModel = new UserModel()
            {
                Name = firstNameBox.Text,
                Surname = secondNameBox.Text,
                Username = UsernameBox.Text,
                Salt = salt,
                Password = DataGenerator.GetSaltHash(PassBox.Password, salt),
            };

            var userList = from u in taskADB.Users.ToList()
                           where u.Username == UsernameBox.Text
                           select u;

            if (userList.ToList().Count > 0)
            {
                passwordErrorBloc.Text = string.Empty;
                confPasswordErrorBloc.Text = string.Empty;
                usernameErrorBloc.Text = "Such username already exits, try another!";
            }
            else if (!Regex.IsMatch(PassBox.Password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$"))
            {
                confPasswordErrorBloc.Text = string.Empty;
                usernameErrorBloc.Text = string.Empty;
                passwordErrorBloc.Text = "Password does not match the template!";
            }
            else if (PassBox.Password != ConfPassBox.Password)
            {
                passwordErrorBloc.Text = string.Empty;
                usernameErrorBloc.Text = string.Empty;
                confPasswordErrorBloc.Text = "Password confirmation does not match!";
            }
            else
            {
                var user = new User(userModel.Username, userModel.Name, userModel.Surname, userModel.Password, userModel.Salt);
                this.taskADB.Users.Add(user);
                this.taskADB.SaveChanges();

                SignIn signInPage = new SignIn();
                signInPage.Show();
                this.Close();
            }
        }
    }
}
