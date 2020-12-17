namespace DBTaskAssistant.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Class that adds validation to Task class.
    /// </summary>
    public class TaskModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private int id;

        private string note;

        private DateTime date;

        private int priority;

        /// <summary>
        /// Occurs when a property value is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets username variable.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets id variable.
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Gets or sets note variable.
        /// </summary>
        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
                OnPropertyChanged("Note");
            }
        }

        /// <summary>
        /// Gets or sets Date variable.
        /// </summary>
        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        /// <summary>
        /// Gets or sets priority variable.
        /// </summary>
        public int Priority
        {
            get
            {
                return priority;
            }

            set
            {
                priority = value;
                OnPropertyChanged("Priority");
            }
        }

        /// <summary>
        /// Gets Error from ErrorCollection.
        /// </summary>
        public string Error
        {
            get { return null; }
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
                    case "Note":
                        if (Note.Length < 5 || Note.Length > 300)
                        {
                            result = "Note must contain 5-300 symbols";
                        }

                        break;
                    case "Priority":
                        if (Priority < 1 || Priority > 10)
                        {
                            result = "Priority must be more than 1, less than 10";
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
