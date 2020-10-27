using System;
using System.Linq;

namespace DB_TaskAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TaskAssistantContext taskAssistantDB = new TaskAssistantContext())
            {
                var users = taskAssistantDB.Users.ToList();

                var tasks = taskAssistantDB.Tasks.ToList();

                Console.WriteLine("Users list:");
                Console.WriteLine("");
                foreach (var u in users)
                {
                    Console.WriteLine($"Username: {u.Username}\nName: {u.Name}\nSurname: {u.Surname}\nPassword: {u.Password.GetHashCode()}");
                    Console.WriteLine("");
                }

                Console.WriteLine("Tasks list:");
                Console.WriteLine("");
                foreach (var t in tasks)
                {
                    Console.WriteLine($"Task ID: {t.Id}\nUsername: {t.Username}\nNote: {t.Note}\nPriority: {t.Priority}");
                    Console.WriteLine("");
                }
            }
            Console.ReadKey();
        }
    }
}
