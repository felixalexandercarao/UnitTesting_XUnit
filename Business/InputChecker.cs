using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class InputChecker
    {
        public bool passwordCheck(string newPassword)
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
        public bool duplicateEmailcheck(string newEmail)
        {
            foreach (BaseUser user in AccountList.GetAccountList())
            {
                if (newEmail == user.UserEmail)
                {
                    return false;
                }
            }
            return true;
        }
        public bool duplicateCustomnameCheck(string newCustomname)
        {
            foreach (BaseUser user in AccountList.GetAccountList())
            {
                if (newCustomname == user.UserCustomName)
                {
                    return false;
                }
            }
            return true;
        }
        public void NullInputCheck(string newFirstname, string newLastname, string newCustomname, string newEmail, int newAge, string newPassword)
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
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                throw new ArgumentException("Please input a password", "UserPassword");
            }
        }
    }
}
