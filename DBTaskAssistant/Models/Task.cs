namespace DBTaskAssistant
{
    using System;

    public partial class Task
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        public Task()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        /// <param name="id">ID of the task.</param>
        /// <param name="username">User's username.</param>
        /// <param name="note">User's note.</param>
        /// <param name="date">User's date.</param>
        /// <param name="priority">User's priority.</param>
        public Task(int id, string username, string note, DateTime date, int priority)
        {
            this.Id = id;
            this.Username = username;
            this.Note = note;
            this.Date = date;
            this.Priority = priority;
        }

        /// <summary>
        /// Gets or sets unique task Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets username which is binded to the task.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets task note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets task date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets task priority.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets auto generated value after connection to DB.
        /// </summary>
        public virtual User UsernameNavigation { get; set; }
    }
}
