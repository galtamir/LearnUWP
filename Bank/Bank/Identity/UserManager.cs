using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Identity
{
    public class UserManager
    {
        private Dictionary<string, BankUser> users;

        public UserManager()
        {
            users = new Dictionary<string, BankUser>();
        }

        public LoginResult Login(string userName, string password, out BankUser bankUser)
        {
            bankUser = null;
            if (users.TryGetValue(userName, out BankUser user))
            {
                if (user.Password.Equals(password))
                {
                    bankUser = user;
                    return LoginResult.Sucess;
                }
                else
                {
                    return LoginResult.InvalidPassword;
                }
            }

            return LoginResult.InvalidUser;
        }

        public bool AddNewUser(BankUser user)
        {
            return users.TryAdd(user.UserName, user);
        }

        public bool Contains(string userName)
        {
            return users.ContainsKey(userName);
        }
    }
}
