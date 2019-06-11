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
    public class EditUserTests
    {
        [Fact]
        public void EditUserNamesAndAge_ShouldChangeInfo()
        {
            AddUser addUser = new AddUser();
            UserList.GetUserList().AddUserToList(addUser.MakeNewUser("Lex", "Carao", "testCustomname1", "lex12321@bai.com", 22, "321Password"));
            EditUser editUser = new EditUser();
            editUser.EditUserNamesAndAge("lex12321@bai.com", "321Password","Felix","Carao",25);
            Assert.True(UserList.GetUserList().GetUserWithEmail("lex12321@bai.com", "321Password").UserFirstName=="Felix");
        }
        [Fact]
        public void EditUserPassword_ShouldChangePassword()
        {
            AddUser addUser = new AddUser();
            UserList.GetUserList().AddUserToList(addUser.MakeNewUser("Passwordchange", "Carao", "testCustomname121211", "lexan@bai.com", 22, "321Password"));
            EditUser editUser = new EditUser();
            editUser.EditUserPassword("lexan@bai.com", "321Password", "Password123");
            Assert.True(UserList.GetUserList().GetUserWithEmail("lexan@bai.com", "Password123").UserFirstName== "Passwordchange");
        }

        [Fact]
        public void EditUserPassword_WrongFormatNewPasswordShouldFail()
        {
            AddUser addUser = new AddUser();
            UserList.GetUserList().AddUserToList(addUser.MakeNewUser("Passwordchange", "Carao", "testcustname", "lexan1@bai.com", 22, "321Password"));
            EditUser editUser = new EditUser();
            
            Assert.Throws<ArgumentException>("UserPassword", () => editUser.EditUserPassword("lexan1@bai.com", "321Password", "badpass"));
        }

        [Theory]
        [ClassData(typeof(DummyData.EditUserTestDataMissingFields))]
        public void EditUserPassword_EmptyNewParametersShouldFail(string firstName, string lastName,string customName,string email, int age, string param)
        {
            AddUser addUser = new AddUser();
            EditUser editUser = new EditUser();
            UserList.GetUserList().AddUserToList(addUser.MakeNewUser("Lex", "Carao", customName, email,22, "321Password"));

            Assert.Throws<ArgumentException>(param, () => editUser.EditUserNamesAndAge(email, "321Password", firstName, lastName, age));
        }

    }
}
