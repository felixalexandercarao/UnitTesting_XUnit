using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Entities;
using Repositories;
using Business;

namespace AccountManagement.Tests
{
    public class DeleteUserTests
    {
        [Theory]
        [InlineData("email1@deletetests.com", "321Pasword")]
        public void DeleteUser_ShouldWork(string email,string password)
        {
            AddUser addUser = new AddUser();
            BaseUser newUsertoDelete = addUser.MakeNewUser("Lex", "Carao", "deletetestscustname1", email, 22, password);          
            UserList.GetUserList().AddUserToList(newUsertoDelete);
            UserList.GetUserList().AddUserToList(addUser.MakeNewUser("Lex", "Carao", "deletetestscustname2", "email2@deletetests.com", 22, "kobeK911"));
            UserList.GetUserList().AddUserToList(addUser.MakeNewUser("Lex", "Carao", "deletetestscustname3", "email3@deletetests.com", 22, "kosS111be"));
            int expectedSize = UserList.GetUserList().GetSizeOfList()-1;
            DeleteUser.deleteUser(email, password);
            int actualSize = UserList.GetUserList().GetSizeOfList();
            Assert.True(InputChecker.duplicateEmailcheck(email));
            Assert.Equal(expectedSize,actualSize);
        }
        [Theory]
        [InlineData("email4@deletetests.com", "321Pasword","UserPassword")]
        public void DeleteUser_CorrectEmailWrongPasswordShouldFail(string email, string password,string param)
        {
            AddUser addUser = new AddUser();

            BaseUser newUser = addUser.MakeNewUser("Lex", "Carao", "deletetestscustname4", email, 22, "123Password");
            UserList.GetUserList().AddUserToList(newUser);

            Assert.Throws<ArgumentException>(param, () => DeleteUser.deleteUser(email, password));
        }

        [Theory]
        [InlineData("email5@deletetests.com", "321Pasword", "UserPassword")]
        public void DeleteUser_CorrectPasswordWrongEmailShouldFail(string email, string password, string param)
        {
            AddUser addUser = new AddUser();

            BaseUser newUser = addUser.MakeNewUser("Lex", "Carao", "deletetestscustname5", "lex1332bai.com", 22,password);
            UserList.GetUserList().AddUserToList(newUser);

            Assert.Throws<ArgumentException>(param, () => DeleteUser.deleteUser(email, password));
        }



        //[Fact]
        //public void DeleteUser_NoExistingRecordsShouldFail()
        //{
        //    Exception expectedException= new MissingMemberException();
        //    Exception actualException=null;
        //    try
        //    {
        //        DeleteUser.deleteUser("lex313@bai.com", "3123Password");
        //    }
        //    catch (Exception ex)
        //    {
        //        actualException = ex;
        //    }
        //    Assert.Equal(expectedException, actualException);
        //}
    }
}
