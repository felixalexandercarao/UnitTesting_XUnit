using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class DeleteUser
    {
        public static void deleteUser(string email, string password)
        {
            BaseUser userTobeDeleted = UserList.GetUserList().GetUserWithEmail(email, password);
            UserList.GetUserList().DeleteUserFromList(userTobeDeleted);
        }
    }
}
