using Entities;
using System;

namespace Business
{
    public class AddUser
    {
        InputChecker inputChecker = new InputChecker();
        public BaseUser MakeNewAccount(string newFirstname,string newLastname, string newEmail, int newAge,string newPassword )
        {
            if (string.IsNullOrWhiteSpace(newFirstname))
            {
                throw new ArgumentException("Please input your first name", "UserFirstName");
            }
            if (string.IsNullOrWhiteSpace(newLastname))
            {
                throw new ArgumentException("Please input your last name", "UserLastName");
            }
            if (string.IsNullOrWhiteSpace(newEmail))
            {
                throw new ArgumentException("Please input your email", "UserEmail");
            }
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                throw new ArgumentException("Please input a password", "UserPassword");
            }
            if (passwordChecker.passwordCheck(newPassword)==false)
            {
                throw new ArgumentException("Password must have at least 8 characters, a number, and an uppercase letter", "UserPassword");
            }
            BaseUser newAccount = new BaseUser
            {
                UserFirstName = newFirstname,
                UserLastName = newLastname,
                UserEmail = newEmail,
                UserAge = newAge,
                UserPassword = newPassword
            };
            return newAccount;
        }
    }
}
