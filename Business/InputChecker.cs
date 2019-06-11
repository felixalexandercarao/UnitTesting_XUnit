using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class InputChecker
    {
        public static bool passwordCheck(string newPassword)
        {
            bool upperResult = false;
            bool numberResult = false;
            foreach (char letter in newPassword.ToCharArray())
            {
                if (Char.IsUpper(letter) == true)
                {
                    upperResult = true;
                }
                if (Char.IsDigit(letter) == true)
                {
                    numberResult = true;
                }
            }
            if (newPassword.Length < 8)
            {
                upperResult = false;
            }
            return (numberResult && upperResult);
        }
        public static bool duplicateEmailcheck(string newEmail)
        {
            bool result = true;
            foreach (BaseUser user in UserList.GetUserList())
            {
                if (newEmail == user.UserEmail)
                {
                    return result =false;
                }
            }
            return result;
        }
        //public static bool duplicateCustomnameCheck(string newCustomname)
        //{
        //    bool result = true;
        //    foreach (BaseUser user in UserList.GetUserList())
        //    {
        //        if (newCustomname == user.UserCustomName)
        //        {
        //            result= false;
        //        }
        //    }
        //    return result;
        //}
        public static void NullInputCheck(string newFirstname, string newLastname, string newCustomname, string newEmail, int newAge)
        {
            if (string.IsNullOrWhiteSpace(newFirstname))
            {
                throw new ArgumentException("Please input your first name", "UserFirstName");
            }

            if (string.IsNullOrWhiteSpace(newLastname))
            {
                throw new ArgumentException("Please input your last name", "UserLastName");
            }
            if (string.IsNullOrWhiteSpace(newCustomname))
            {
                throw new ArgumentException("Please input your custom name", "UserCustomName");
            }
            if (string.IsNullOrWhiteSpace(newEmail))
            {
                throw new ArgumentException("Please input your email", "UserEmail");
            }
        }
    }
}
