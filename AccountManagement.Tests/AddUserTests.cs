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
    public class AddUserTests
    {
        [Fact]
        public void MakeNewUser_ShouldCreateAcount()
        {
            AddUser addUser = new AddUser();
            int expected = UserList.GetUserList().GetSizeOfList() + 1;

            BaseUser newAccount = addUser.MakeNewUser("Lex", "Carao", "addtestscustname1", "email1@addtests.com", 22, "321Password");

            UserList.GetUserList().AddUserToList(newAccount);
            int actual = UserList.GetUserList().GetSizeOfList();
            Assert.Equal(UserList.GetUserList().GetUserWithEmail("email1@addtests.com", "321Password"),newAccount);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(DummyData.AddUserTestDataMissingFields))]
        public void MakeNewUser_EmptyFieldsShouldFail(string firstName, string lastName, string customName, string email, int age, string password, string param)
        {
            AddUser addUser = new AddUser();

            Assert.Throws<ArgumentException>(param, () => addUser.MakeNewUser(firstName, lastName, customName, email, age, password));
        }


        [Theory]
        [ClassData(typeof(DummyData.AddUserTestDataWrongPasswords))]
        public void MakeNewUser_WrongPasswordFormatShouldFail(string password, string param)
        {
            AddUser addUser = new AddUser();

            Assert.Throws<ArgumentException>(param, () => addUser.MakeNewUser("Lex", "Carao", "addtestscustname2", "email2@addtests.com", 22, password));
        }

        [Theory]
        [InlineData("email3@addtests.com", "UserEmail")]
        public void MakeNewUser_DuplicateEmailShouldFail(string email, string param)
        {
            AddUser addUser = new AddUser();
            BaseUser newAccount=addUser.MakeNewUser("Lex", "Carao", "addtestscustname3", email, 22, "321Password");
            UserList.GetUserList().AddUserToList(newAccount);
            Assert.Throws<ArgumentException>(param, () => addUser.MakeNewUser("Lex", "Carao", "addtestscustname4", email, 22, "321Password"));
        }

        [Theory]
        [InlineData("addtestscustname5", "UserCustomName")]
        public void MakeNewUser_DuplicateCustomNameShouldFail(string customName, string param)
        {
            AddUser addUser = new AddUser();
            BaseUser newAccount = addUser.MakeNewUser("Lex", "Carao", customName, "email4@addtests.com", 22, "321Password");
            UserList.GetUserList().AddUserToList(newAccount);
            Assert.Throws<ArgumentException>(param, () => addUser.MakeNewUser("Lex", "Carao", customName, "email4@addtests.com", 22, "321Password"));
        }

        //[Theory]
        //[ClassData(typeof(DummyData.AddUserTestDataWrongTypes))]
        //public void MakeNewUser_WrongInputTypesShouldntAdd(string firstName, string lastName, string customName, string email, int age, string password)
        //{
        //    AddUser addUser = new AddUser();
        //    int expected = UserList.GetUserList().GetSizeOfList() + 1;

        //    BaseUser newAccount = addUser.MakeNewUser(firstName, lastName, customName, email, age, password);

        //    UserList.GetUserList().AddUserToList(newAccount);
        //    int actual = UserList.GetUserList().GetSizeOfList();

        //    Assert.Equal(expected, actual);
        //}

    }
}
