// <copyright file="AddVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DBTaskAssistant
{
    using System;
    using System.Collections.ObjectModel;
    using DevExpress.Mvvm;

    public class AddVM : ViewModelBase
    {
        public Task task;

        public ObservableCollection<int> hours { get; set; }

        public ObservableCollection<int> priorities { get; set; }

        public ObservableCollection<int> minutes { get; set; }

        private int currHour { get; set; }
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

        private int currMinute { get; set; }
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

        private DateTime date { get; set; }
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

        private string note { get; set; }
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

        private int priority { get; set; }
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

        public AddVM()
        {
            this.hours = new ObservableCollection<int>();
            this.minutes = new ObservableCollection<int>();
            this.priorities = new ObservableCollection<int>();
            for (int i = 1; i < 4; i++)
            {
                this.priorities.Add(i);
            }

            for (int i = 0; i < 24; i++)
            {
                this.hours.Add(i);
            }

            for (int j = 0; j < 60; j++)
            {
                this.minutes.Add(j);
            }

            this.CurrHour = DateTime.Now.Hour;
            this.CurrMinute = DateTime.Now.Minute;
            this.Date = DateTime.Now;
            this.Priority = 3;
        }

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
                this.priority = currtask.Priority;
            }
        }
    }
}
