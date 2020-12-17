namespace DBTaskAssistant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using R = System.Security.Cryptography.RandomNumberGenerator;

    /// <summary>
    /// Class that generates random data.
    /// </summary>
    public class DataGenerator
    {
        private static int minLogLen = 3;
        private static int maxLogLen = 12;
        private static int minPassLen = 8;
        private static int maxPassLen = 30;
        private static int minNamesLen = 3;
        private static int maxNamesLen = 12;
        private static int minNoteLen = 0;
        private static int maxNoteLen = 100;
        private static int maxPrior = 10;
        private static int saltLen = 6;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGenerator"/> class.
        /// </summary>
        public DataGenerator() { }

        /// <summary>
        /// Function that generates random string.
        /// </summary>
        /// <param name="minLen">Minimal length.</param>
        /// <param name="maxLen">Maximum length.</param>
        /// <param name="useDigit">Value that indicates if numbers are included.</param>
        /// <returns>String value.</returns>
        public static string GetRandStr(int minLen, int maxLen, bool useDigit = false)
        {
            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (useDigit)
            {
                valid += "1234567890";
            }

            StringBuilder res = new StringBuilder();
            int length = R.GetInt32(minLen, maxLen + 1);
            for (int i = 0; i < length; i++)
            {
                res.Append(valid[R.GetInt32(valid.Length)]);
            }

            return res.ToString();
        }

        /// <summary>
        /// Function that converts salt into hash.
        /// </summary>
        /// <param name="pass">Password that is added to salt.</param>
        /// <param name="salt">Salt that is added to password and then hashed.</param>
        /// <returns>Hash code.</returns>
        public static string GetSaltHash(string pass, string salt)
        {
            string toHash = pass + salt;
            HashAlgorithm hesher = new SHA256Managed();
            byte[] toHasgBytes = Encoding.UTF8.GetBytes(toHash);
            byte[] hash = hesher.ComputeHash(toHasgBytes);
            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Generates values to DB.
        /// </summary>
        /// <param name="context">DB context.</param>
        /// <param name="usersCount">Number of users.</param>
        /// <param name="tasksCount">Number of tasks.</param>
        public static void GenerateData(TaskAssistantContext context, int usersCount = 30, int tasksCount = 50)
        {
            string login, name, surname, pass, salt, heshpass;
            for (int i = 0; i < usersCount; i++)
            {
                do
                {
                    login = GetRandStr(minLogLen, maxLogLen, true);
                }
                while (Contain(context.Users.ToList(), login));
                name = GetRandStr(minNamesLen, maxNamesLen, false);
                surname = GetRandStr(minNamesLen, maxNamesLen, false);
                pass = GetRandStr(minPassLen, maxPassLen, true);
                salt = GetRandStr(saltLen, saltLen, true);
                heshpass = GetSaltHash(pass, salt);
                User user = new User(login, name, surname, heshpass, salt);
                context.Users.Add(user);
            }

            context.SaveChanges();

            Random rnd = new Random();

            int startId = 1;
            if (context.Tasks.Count() > 0)
            {
                startId = context.Tasks.ToList()[context.Tasks.ToList().Count - 1].Id + 1;
            }

            int id, prior;
            string usname, note;
            List<User> users = context.Users.ToList();
            if (users.Count > 0)
            {
                for (int i = 0; i < tasksCount; i++)
                {
                    DateTime time = DateTime.Now;
                    time.AddDays(rnd.Next(10));
                    time.AddHours(rnd.Next(24));
                    id = startId + i;
                    while (Contain(context.Tasks.ToList(), id))
                    {
                        id = context.Tasks.Max(i => i.Id) + 1;
                    }

                    usname = users[rnd.Next(users.Count)].Username;
                    note = GetRandStr(minNoteLen, maxNoteLen, true);
                    prior = rnd.Next(maxPrior);
                    Task task = new Task(id, usname, note, time, prior);
                    context.Tasks.Add(task);
                }
            }

            context.SaveChanges();
        }

        private static bool Contain(List<User> users, string login)
        {
            foreach (var item in users)
            {
                if (item.Username == login)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool Contain(List<Task> tasks, int id)
        {
            foreach (var item in tasks)
            {
                if (item.Id == id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
