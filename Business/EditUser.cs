using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class EditUser
    {
        public void EditUserNamesAndAge(string email, string password,string firstName,string lastName,int age)
        {
            BaseUser toBeedited = UserList.GetUserList().GetUserWithEmail(email, password);
            InputChecker.NullInputCheck(firstName, lastName, toBeedited.UserCustomName,email , age);
            toBeedited.UserFirstName = firstName;
            toBeedited.UserLastName = lastName;
            toBeedited.UserAge = age;
        }

        public void EditUserPassword(string email, string password, string newPassword)
        {
            BaseUser toBeedited = UserList.GetUserList().GetUserWithEmail(email, password);

            if (InputChecker.passwordCheck(newPassword) == false)
            {
                throw new ArgumentException("Password must have at least 8 characters, a number, and an uppercase letter", "UserPassword");
            }
            toBeedited.UserPassword = newPassword;
        }
    }
}
