using Entities;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class AccountList
    {
        List<BaseUser> users = new List<BaseUser>();

        private static AccountList instance;

        public static AccountList GetAccountList()
        {
            if (instance == null)
            {
                instance = new AccountList();
            }

            return instance;
        }
        public void AddAccountToList(BaseUser newAccount)
        {
            users.Add(newAccount);
        }
        public int GetSizeOfList()
        {
            return users.Count;
        }
    }
}
