using Entities;
using System;

namespace Business
{
    public class AddUser
    {
        InputChecker inputChecker = new InputChecker();
        public BaseUser MakeNewAccount(string newFirstname,string newLastname,string newCustomname, string newEmail, int newAge,string newPassword )
        {
            inputChecker.NullInputCheck(newFirstname,  newLastname, newCustomname, newEmail, newAge, newPassword);
            if (inputChecker.passwordCheck(newPassword)==false)
            {
                throw new ArgumentException("Password must have at least 8 characters, a number, and an uppercase letter", "UserPassword");
            }
            if (inputChecker.duplicateEmailcheck(newEmail) == false)
            {
                throw new ArgumentException("This email has been used", "UserEmail");
            }
            if (inputChecker.duplicateCustomnameCheck(newCustomname) == false)
            {
                throw new ArgumentException("This custom name has been used", "UserCustomName");
            }
            BaseUser newAccount = new BaseUser
            {
                UserFirstName = newFirstname,
                UserLastName = newLastname,
                UserCustomName=newCustomname,
                UserEmail = newEmail,
                UserAge = newAge,
                UserPassword = newPassword
            };
            return newAccount;
        }
    }
}
