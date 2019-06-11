using Entities;
using Repositories;
using System;

namespace Business
{
    public class AddUser
    {
        public BaseUser MakeNewUser(string newFirstname,string newLastname,string newCustomname, string newEmail, int newAge,string newPassword )
        {
            InputChecker.NullInputCheck(newFirstname,  newLastname, newCustomname, newEmail, newAge);
            if (UserList.GetUserList().duplicateCustomnameCheck(newCustomname) == false)
            {
                throw new ArgumentException("This custom name has been used", "UserCustomName");
            }
            if (UserList.GetUserList().duplicateEmailcheck(newEmail) == false)
            {
                throw new ArgumentException("This email has been used", "UserEmail");
            }
            if (InputChecker.passwordCheck(newPassword)==false)
            {
                throw new ArgumentException("Password must have at least 8 characters, a number, and an uppercase letter", "UserPassword");
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
        public void AddUserToRepo(BaseUser newUser)
        {
            UserList.GetUserList().AddUserToList(newUser);
        }
    }
}
