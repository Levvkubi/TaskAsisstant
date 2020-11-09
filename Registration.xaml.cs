using DBTaskAssistant;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TaskAssistant
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        TaskAssistantContext taskADB;

        string emaildef = "Електронна пошта";

        string passImagePath = @"C:\Users\gradk\source\repos\TaskAssistant\TaskAssistant\Images\Password.jpg";

        ImageBrush passImage;

        public Registration()
        {
            InitializeComponent();
            passImage = new ImageBrush();
            passImage.ImageSource =
                new BitmapImage(
                    new Uri(passImagePath, UriKind.Relative)
                );
            passImage.AlignmentX = AlignmentX.Left;
            passImage.Stretch = Stretch.None;
        }

        private void GotFocusField(object sender, RoutedEventArgs e)
        {
            TextBox t = (TextBox)sender;

            if (t.Text == emaildef)
                t.Text = string.Empty;
        }

        private void LostFocusField(object sender, RoutedEventArgs e)
        {
            TextBox t = (TextBox)sender;

            if (t.Text == string.Empty)
                t.Text = emaildef;
        }

        private void passBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox t = (PasswordBox)sender;
            if (t.Password == string.Empty)
                t.Background = null;
        }

        private void passBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox t = (PasswordBox)sender;
            if (t.Password == string.Empty)
                t.Background = passImage;
        }

        private void signUpButt_Click(object sender, RoutedEventArgs e)
        {
            taskADB = new TaskAssistantContext();
            var user = new User();
            user.Name = fNameBox.Text;
            user.Surname = lNameBox.Text;
            user.Username = emailBox.Text;
            user.Salt = DataGenerator.GetRandStr(6, 6, true);
            user.Password = DataGenerator.GetSaltHash(passBox.Password, user.Salt);

            taskADB.Users.Add(user);
            taskADB.SaveChanges();

            SignIn signInPage = new SignIn();
            signInPage.Show();
            this.Close();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            SignIn signInPage = new SignIn();
            signInPage.Show();
            this.Close();
        }
    }
}
