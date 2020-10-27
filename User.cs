using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB_TaskAssistant
{
    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
