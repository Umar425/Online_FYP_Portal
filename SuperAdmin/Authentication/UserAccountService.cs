namespace SuperAdmin.Authentication
{

    public class UserAccountService
    {
        public UserAccount GetByUserName(string userName)
        {

            if (userName == "admin")
            {
                return new UserAccount
                {
                    Username = "admin",
                    Password = "admin",
                    Role = "admin"
                };
            }
            else if (userName == "user")
            {
                return new UserAccount
                {
                    Username = "user",
                    Password = "user",
                    Role = "user"
                };
            }

            return null;
        }
    }
}