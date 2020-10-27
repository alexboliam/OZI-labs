using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Lab2OZI
{
    public static class UserService
    {
        public static List<User> dbUsers { get; set; }
        private static string filePath = "userdb.json";
        public static string passwordLimiter = @"[1-9]|[+,-]|['%','/','*']";
        public static User currentUser { get; set; } = null;
        public static void WriteToFile()
        {
            using (StreamWriter fs = new StreamWriter(filePath))
            {
                User u = new User("ADMIN", "", Role.Admin);
                List<User> l = new List<User>();
                l.Add(u);
                JsonSerializer s = new JsonSerializer();
                s.Serialize(fs, l);
            }
        }
        public static void ReadFromFile()
        {
            if(!File.Exists(filePath))
            {
                WriteToFile();
            }

            using (StreamReader fs = new StreamReader(filePath))
            {
                JsonSerializer s = new JsonSerializer();
                List<User> users = new List<User>();
                dbUsers = (List<User>)s.Deserialize(fs, typeof(List<User>));
            }
        }
        public static void ChangePassword(string newPassword)
        {
            using (StreamWriter fs = new StreamWriter(filePath))
            {
                dbUsers[dbUsers.IndexOf(currentUser)].Password = newPassword;
                JsonSerializer s = new JsonSerializer();
                s.Serialize(fs, dbUsers);
                currentUser.Password = newPassword;
            }
        }

        public static void AddUserToFile(string userName)
        {
            using (StreamWriter fs = new StreamWriter(filePath))
            {
                dbUsers.Add(new User(userName, "", 0));
                JsonSerializer s = new JsonSerializer();
                s.Serialize(fs, dbUsers);
            }
        }
        public static void UpdateUsersStatus()
        {
            using (StreamWriter fs = new StreamWriter(filePath))
            {
                JsonSerializer s = new JsonSerializer();
                s.Serialize(fs, dbUsers);
            }
        }
    }
}
