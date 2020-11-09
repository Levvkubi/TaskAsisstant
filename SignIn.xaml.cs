using DBTaskAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TaskAssistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        TaskAssistantContext taskADB;

        string emaildef = "Електронна пошта";

        string passImagePath = @"C:\Users\gradk\source\repos\TaskAssistant\TaskAssistant\Images\Password.jpg";

        ImageBrush passImage;

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

        private void regist_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            this.Hide();
            registration.Show();
        }

        public SignIn()
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

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            taskADB = new TaskAssistantContext();


            if (usernameBox.Text.Length > 0)
            {
                if (passwordBox.Password.Length > 0)
                {
                    var loggedUser = from u in taskADB.Users.ToList()
                                     where u.Username == usernameBox.Text && DataGenerator.GetSaltHash(passwordBox.Password, u.Salt) == u.Password
                                     select u;

                    if (loggedUser.ToList().Count > 0)
                    {
                        MainPage mainPage = new MainPage();
                        mainPage.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Invalid password or username!");
                }
                else
                    MessageBox.Show("Enter password!");
            }
            else
                MessageBox.Show("Enter username!");
        }
    }
}
