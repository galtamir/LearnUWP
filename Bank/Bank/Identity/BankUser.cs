namespace Bank.Identity
{
    public class BankUser
    {
        public string UserName { get; }

        public string Password { get; private set; }

        public BankUser(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}