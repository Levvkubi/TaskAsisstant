namespace DBTaskAssistant
{
    using System.Collections.Generic;

    public partial class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.Tasks = new HashSet<Task>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="log">User's username.</param>
        /// <param name="name">User's name.</param>
        /// <param name="surname">User's surname.</param>
        /// <param name="password">User's password.</param>
        /// <param name="salt">Salt that is added to password.</param>
        public User(string log, string name, string surname, string password, string salt)
        {
            this.Username = log;
            this.Name = name;
            this.Surname = surname;
            this.Password = password;
            this.Salt = salt;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="user">User element.</param>
        public User(User user)
        {
            this.Username = user.Username;
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.Password = user.Password;
            this.Salt = user.Salt;
            foreach (var value in user.Tasks)
            {
                Tasks.Add(value);
            }
        }

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets salt that is added to password.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Gets or sets auto generated value.
        /// </summary>
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
