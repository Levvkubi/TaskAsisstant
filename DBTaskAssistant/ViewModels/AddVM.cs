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
        public int CurrHour
        {
            get
            {
                return currHour;
            }

            set
            {
                currHour = value;
                this.RaisePropertyChanged(() => currHour);
            }
        }

        /// <summary>
        /// Gets or sets current minute variable.
        /// </summary>
        public int CurrMinute
        {
            get
            {
                return currMinute;
            }

            set
            {
                currMinute = value;
                this.RaisePropertyChanged(() => currMinute);
            }
        }

        /// <summary>
        /// Gets or sets current hour variable.
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
                this.RaisePropertyChanged(() => date);
            }
        }

        /// <summary>
        /// Gets or sets current hour variable.
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
                this.RaisePropertyChanged(() => note);
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
                this.RaisePropertyChanged(() => priority);
            }
        }

        private int currHour { get; set; }

        private int currMinute { get; set; }

        private DateTime date { get; set; }

        private string note { get; set; }

        private int priority { get; set; }
    }
}
