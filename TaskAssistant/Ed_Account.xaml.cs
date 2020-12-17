namespace TaskAssistantForms
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows;
    using DBTaskAssistant;
    using TaskAssistant;

    /// <summary>
    /// Interaction logic for Ed_Account.xaml.
    /// </summary>
    public partial class EditAccount : Window
    {
        private string passtagText;
        private string conftagText;
        private User currentUser;
        private TaskAssistantContext taskADB;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditAccount"/> class.
        /// </summary>
        /// <param name="user">Current user.</param>
        public EditAccount(User user)
        {
            InitializeComponent();
            currentUser = user;
            passtagText = PassBox.Tag.ToString();
            conftagText = ConfPassBox.Tag.ToString();
            firstNameBox.Text = user.Name;
            secondNameBox.Text = user.Surname;
            UsernameBox.Text = user.Username;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainView main = new MainView(currentUser);
            this.Close();
            main.Show();
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

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            MainView main = new MainView(currentUser);
            if (!Regex.IsMatch(firstNameBox.Text, @"^[\p{L}\p{M}' \.\-]+$") || firstNameBox.Text.Length < 2 || firstNameBox.Text.Length > 10)
            {
                firstNameErrorBloc.Text = "Enter valid first name!";
                secondNameErrorBloc.Text = string.Empty;
                usernameErrorBloc.Text = string.Empty;
                passwordErrorBloc.Text = string.Empty;
                confPasswordErrorBloc.Text = string.Empty;
            }
            else if (!Regex.IsMatch(secondNameBox.Text, @"^[\p{L}\p{M}' \.\-]+$") || secondNameBox.Text.Length < 2 || secondNameBox.Text.Length > 15)
            {
                secondNameErrorBloc.Text = "Enter valid second name!";
                firstNameErrorBloc.Text = string.Empty;
                usernameErrorBloc.Text = string.Empty;
                passwordErrorBloc.Text = string.Empty;
                confPasswordErrorBloc.Text = string.Empty;
            }
            else if (!Regex.IsMatch(UsernameBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") || UsernameBox.Text.Length < 5 || UsernameBox.Text.Length > 20)
            {
                usernameErrorBloc.Text = "Enter valid username!";
                secondNameErrorBloc.Text = string.Empty;
                firstNameErrorBloc.Text = string.Empty;
                passwordErrorBloc.Text = string.Empty;
                confPasswordErrorBloc.Text = string.Empty;
            }
            else if (!Regex.IsMatch(PassBox.Password, @"^(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,15})$"))
            {
                passwordErrorBloc.Text = "Enter valid password!";
                secondNameErrorBloc.Text = string.Empty;
                usernameErrorBloc.Text = string.Empty;
                firstNameErrorBloc.Text = string.Empty;
                confPasswordErrorBloc.Text = string.Empty;
            }
            else if (!string.Equals(ConfPassBox.Password, PassBox.Password))
            {
                confPasswordErrorBloc.Text = "Password confirmation is incorrect!";
                secondNameErrorBloc.Text = string.Empty;
                usernameErrorBloc.Text = string.Empty;
                passwordErrorBloc.Text = string.Empty;
                firstNameErrorBloc.Text = string.Empty;
            }
            else
            {
                taskADB = new TaskAssistantContext();
                var user = from u in taskADB.Users.ToList()
                           where u.Username == UsernameBox.Text
                           select u;
                user.FirstOrDefault().Name = firstNameBox.Text;
                currentUser.Name = firstNameBox.Text;
                user.FirstOrDefault().Surname = secondNameBox.Text;
                currentUser.Surname = secondNameBox.Text;
                user.FirstOrDefault().Username = UsernameBox.Text;
                currentUser.Username = UsernameBox.Text;
                if (!(PassBox.Password == "NoPassword1"))
                {
                    user.FirstOrDefault().Password = DataGenerator.GetSaltHash(PassBox.Password, user.FirstOrDefault().Salt);
                }

                taskADB.SaveChanges();
                this.Close();
                main.Show();
            }
        }
    }
}
