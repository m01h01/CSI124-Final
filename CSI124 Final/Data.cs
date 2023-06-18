using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MyClassLibrary;

namespace CSI124_Final
{
    public static class Data
    {
        public static string _loginName;
        public static UserAccount _currentUser = null;
        public static List<UserAccount> _accounts = new List<UserAccount>();
        public static string userInformation = "users.json";
        public static string TransactionExtension = "_transaction.csv";

        public static UserAccount CurrentUser { get => _currentUser; set => _currentUser = value; }
        public static List<UserAccount> Accounts { get => _accounts; set => _accounts = value; }
        public static string LoginName { get => _loginName; set => _loginName = value; }

        static Data()
        {
            Preload();
            ReadUsers();
        }

        public static string UsersTransactionsName()
        {
            return _currentUser.Name + TransactionExtension;
        }

        public static void Preload() // Used to load accounts list the first time, then save to .json
        { 
            _accounts.Add(new UserAccount("Monika","Mo", "A1", UserAccount.Role.User));
            _accounts.Add(new UserAccount("Ellie","El", "B2", UserAccount.Role.Admin));
            _accounts.Add(new UserAccount("Tifanny","Ti", "C3", UserAccount.Role.Admin));
            _accounts.Add(new UserAccount("Bonnie","Bo", "D4", UserAccount.Role.User));


            SaveUsers();

        }

        public static bool IsUser(string userName) // Used for login
        {
            foreach (UserAccount account in _accounts)
            {
                if (userName == account.UserName)
                {
                    CurrentUser = account;
                    return true;
                }   
            } 
            return false;
        }

        public static bool ValidateUser(string userName, string password) // Used for login
        {
            foreach (UserAccount account in _accounts)
            {
                if (userName == account.UserName && password == account.Password)
                {
                    return true;

                }

            }
            return false;

        }

        public static void AddUser(UserAccount account) // Add user to accounts and then save to json
        {
            _accounts.Add(account);
            SaveUsers();
        }

        public static void SaveUsers() // Save accounts json
        {
            JsonSerializerOptions jso = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonManager = JsonSerializer.Serialize(_accounts, jso);

            File.WriteAllText(userInformation, jsonManager);
        }

        public static void ReadUsers() // Read json and deserialize to accounts
        {
            string listFromFile = File.ReadAllText(userInformation);
            _accounts = JsonSerializer.Deserialize<List<UserAccount>>(listFromFile);
        }
    }//class
}//namespace
