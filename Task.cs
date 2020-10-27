using System;
using System.ComponentModel.DataAnnotations;

namespace DB_TaskAssistant
{
    public partial class Task
    {
        [Key]
        public int Id { get; set; }
        public User Username { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public int Priority { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}
