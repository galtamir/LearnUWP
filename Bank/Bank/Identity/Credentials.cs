using System;

namespace Bank.Identity
{
    public class Credentials
    {
        public string UserName { get; private set; }
        private string password;

        private string seed;

        public Credentials(string userName, string password)
        {
            UserName = userName;
            this.password = password;
        }

        

        public bool CahngePassword(string oldPassword, string newPassword)
        {
            if (IsPasswordCorect(oldPassword))
            {
                oldPassword = newPassword;
                return true;
            }
            return false;
        }

        internal bool IsPasswordCorect(string password)
        {
            return password.Equals(password);
        }
    }
}