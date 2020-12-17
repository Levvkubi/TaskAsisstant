namespace DBTaskAssistant
{
    using System;
    using System.Collections.ObjectModel;
    using DevExpress.Mvvm;

    /// <summary>
    /// Class that is used to work with data in Add task View.
    /// </summary>
    public class AddVM : ViewModelBase
    {
        private Task task;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddVM"/> class.
        /// </summary>
        public AddVM()
        {
            this.Hours = new ObservableCollection<int>();
            this.Minutes = new ObservableCollection<int>();
            this.Priorities = new ObservableCollection<int>();
            for (int i = 1; i < 4; i++)
            {
                this.Priorities.Add(i);
            }

            for (int i = 0; i < 24; i++)
            {
                this.Hours.Add(i);
            }

            for (int j = 0; j < 60; j++)
            {
                this.Minutes.Add(j);
            }

            this.CurrHour = DateTime.Now.Hour;
            this.CurrMinute = DateTime.Now.Minute;
            this.Date = DateTime.Now;
            this.Priority = 3;
        }

        /// <summary>
        /// Gets or sets hours value that is shown in a form.
        /// </summary>
        public ObservableCollection<int> Hours { get; set; }

        /// <summary>
        /// Gets or sets priority value that is shown in a form.
        /// </summary>
        public ObservableCollection<int> Priorities { get; set; }

        /// <summary>
        /// Gets or sets minutes value that is shown in a form.
        /// </summary>
        public ObservableCollection<int> Minutes { get; set; }

        /// <summary>
        /// Gets or sets current hour variable.
        /// </summary>
        public int CurrHour { get; set; }

        /// <summary>
        /// Gets or sets current minute variable.
        /// </summary>
        public int CurrMinute { get; set; }

        /// <summary>
        /// Gets or sets current hour variable.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets current hour variable.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets priority variable.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Function that is used to set Date, Priority, Current hour & minute.
        /// </summary>
        /// <param name="tasks">Task list.</param>
        /// <param name="currtask">Current task.</param>
        /// <param name="change">Bool variable to show changes.</param>
        public void Zapovn(ObservableCollection<Task> tasks, Task currtask, bool change)
        {
            if (!change)
            {
                this.CurrHour = DateTime.Now.Hour;
                this.CurrMinute = DateTime.Now.Minute;
                this.Date = DateTime.Now;
                this.Priority = 3;
            }
            else
            {
                this.CurrHour = currtask.Date.Hour;
                this.CurrMinute = currtask.Date.Minute;
                this.Note = currtask.Note;
                this.Priority = currtask.Priority;
            }
        }
    }
}
