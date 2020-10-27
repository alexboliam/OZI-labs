using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2OZI
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public bool IsBanned { get; set; }
        public bool IsPasswordLimited { get; set; }

        public User(string login, string password, Role role)
        {
            this.Role = role;
            this.Login = login;
            this.Password = password;
        }
    }

    public enum Role { User, Admin }
}
