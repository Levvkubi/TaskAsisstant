﻿// <copyright file="SignIn.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TaskAssistant
{
    using System.Linq;
    using System.Windows;
    using DBTaskAssistant;

    /// <summary>
    /// Class that adds logic to SignIn View.
    /// </summary>
    public partial class SignIn : Window
    {
        private TaskAssistantContext taskADB;

        private string tagText;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignIn"/> class.
        /// </summary>
        public SignIn()
        {
            this.InitializeComponent();
            this.tagText = PassBox.Tag.ToString();
        }

        private void PassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.PassBox.Password.Length == 0)
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
            taskADB = new TaskAssistantContext();

            var loggedUser = from u in taskADB.Users.ToList()
                             where u.Username == usernameBox.Text && DataGenerator.GetSaltHash(PassBox.Password, u.Salt) == u.Password
                             select u;

            if (loggedUser.ToList().Count > 0)
            {
                MainView mainPage = new MainView(loggedUser.First());
                mainPage.Show();
                this.Close();
            }
            else if (loggedUser.ToList().Count == 0)
            {
                usernameErrorBloc.Text = "Enter correct data!";
            }
        }
    }
}
