using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class UserList:IEnumerable
    {
        List<BaseUser> users = new List<BaseUser>();

        private static UserList instance;

        public static UserList GetUserList()
        {
            if (instance == null)
            {
                instance = new UserList();
            }

            return instance;
        }
        public void AddUserToList(BaseUser newUser)
        {
            users.Add(newUser);
        }
        public void DeleteUserFromList(BaseUser toBedeletedUser)
        {
            users.Remove(toBedeletedUser);
        }
        public int GetSizeOfList()
        {
            return users.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)users).GetEnumerator();
        }

        public BaseUser GetUserWithEmail(string email,string password)
        {
            foreach (BaseUser userResult in users)
            {
                if(email==userResult.UserEmail && password == userResult.UserPassword)
                {
                    return userResult;
                }
                if (email == userResult.UserEmail && password != userResult.UserPassword)
                {
                    throw new ArgumentException("You typed the wrond password", "UserPassword");
                }
            }
            throw new MissingMemberException();
        }

        public bool duplicateCustomnameCheck(string newCustomname)
        {
            //return !users.Any(user => user.UserCustomName == newCustomname);
            bool result = true;
            foreach (BaseUser user in users)
            {
                if (newCustomname == user.UserCustomName)
                {
                    result = false;
                }
            }
            return result;
        }
        public bool duplicateEmailcheck(string newEmail)
        {
            //return !users.Any(user => user.UserEmail == newEmail);
            bool result = true;
            foreach (BaseUser user in UserList.GetUserList())
            {
                if (newEmail == user.UserEmail)
                {
                    return result = false;
                }
            }
            return result;
        }
    }
}
