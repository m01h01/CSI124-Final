using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class UserAccount
    {
        public enum Role { User, Admin }

        string _name;
        string _userName;
        string _password;
        Role _role;


        public UserAccount(string name, string userName, string password, Role ROle)
        {
            Name = name;
            UserName = userName;
            Password = password;
            role = ROle;
        }

        public UserAccount()
        { }

        public string Name { get => _name; set => _name = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public Role role { get => _role; set => _role = value; }

    }//class
}//namespace
