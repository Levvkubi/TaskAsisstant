namespace DBTaskAssistant.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class that adds validation to Task class.
    /// </summary>
    public class UserModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private string username;
        private string name;
        private string surname;
        private string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserModel"/> class.
        /// </summary>
        public UserModel() { }

        /// <summary>
        /// Occurs when a property value is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets salt that is added to password.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Gets or sets username variable.
        /// </summary>
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.username = value;
                this.OnPropertyChanged("Username");
            }
        }

        /// <summary>
        /// Gets or sets name variable.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets surname variable.
        /// </summary>
        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                this.surname = value;
                this.OnPropertyChanged("Surname");
            }
        }

        /// <summary>
        /// Gets or sets password variable.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
                this.OnPropertyChanged("Password");
            }
        }

        /// <summary>
        /// Gets Error from ErrorCollection.
        /// </summary>
        public string Error
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the collection of errors that could happen.
        /// </summary>
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets the error message for the property with the givven name.
        /// </summary>
        /// <param name="columnName">The name of the field.</param>
        /// <returns>Error from ErrorCollection.</returns>
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "Username":
                        if (string.IsNullOrEmpty(this.Username))
                        {
                            result = "Username cannot be empty";
                        }
                        else if (this.Username.Length < 5 || this.Username.Length > 20)
                        {
                            result = "Username must contain 5-20 symbols";
                        }
                        else if (!Regex.IsMatch(this.Username, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                        {
                            result = "Username does not match the template";
                        }

                        break;
                    case "Name":
                        if (string.IsNullOrEmpty(this.Name))
                        {
                            result = "Name cannot be empty";
                        }
                        else if (this.Name.Length < 2 || this.Name.Length > 10)
                        {
                            result = "Name must contain 2-10 symbols";
                        }
                        else if (!Regex.IsMatch(this.Name, @"^[\p{L}\p{M}' \.\-]+$"))
                        {
                            result = "Name does not match the template";
                        }

                        break;
                    case "Surname":
                        if (string.IsNullOrEmpty(this.Surname))
                        {
                            result = "Surname cannot be empty";
                        }
                        else if (Surname.Length < 2 || Surname.Length > 15)
                        {
                            result = "Surname must contain 2-15 symbols";
                        }
                        else if (!Regex.IsMatch(Surname, @"^[\p{L}\p{M}' \.\-]+$"))
                        {
                            result = "Surname does not match the template";
                        }

                        break;
                    case "Password":
                        if (string.IsNullOrEmpty(Password))
                        {
                            result = "Password cannot be empty";
                        }
                        else if (!Regex.IsMatch(Password, @"^(?=.*[a - z])(?=.*[A - Z])(?=.*\d)(?=.*[^\da - zA - Z]).{ 6,15}$"))
                        {
                            result = "Password does not match the template";
                        }
                        else if (Password.Length < 6 || Password.Length > 15)
                        {
                            result = "Password must contain 6-15 symbols";
                        }

                        break;
                }

                if (ErrorCollection.ContainsKey(columnName))
                {
                    ErrorCollection[columnName] = result;
                }
                else if (result != null)
                {
                    ErrorCollection.Add(columnName, result);
                }

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }

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
