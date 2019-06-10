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
    public class AddAccountTests
    {
        [Theory]
        [InlineData("Lex","Carao","lex@bai.com",22, "321Password")]
        public void MakeNewAccount_ShouldCreateAcount(string firstName, string lastName, string email,int age, string password)
        {
            AddUser addUser = new AddUser();
            int expected = AccountList.GetAccountList().GetSizeOfList()+1;

            BaseUser newAccount = addUser.MakeNewAccount(firstName, lastName, email, age, password);

            AccountList.GetAccountList().AddAccountToList(newAccount);
            int actual = AccountList.GetAccountList().GetSizeOfList();
            
            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData("", "Carao", "lex@bai.com", 22, "321Password", "UserFirstName")]
        [InlineData("Lex", "", "lex@bai.com", 22, "321Password", "UserLastName")]
        [InlineData("Lex", "Carao", "", 22, "321Password", "UserEmail")]
        [InlineData("Lex", "Carao", "lex@bai.com", 22, "", "UserPassword")]
        public void MakeNewAccount_EmptyFieldsShouldFail(string firstName, string lastName, string email, int age, string password,string param)
        {
            AddUser addUser = new AddUser();

            Assert.Throws<ArgumentException>(param, () => addUser.MakeNewAccount(firstName, lastName, email, age, password));
        }

        [Theory]
        [InlineData("AAAAAAAAAAAAA", "UserPassword")] //no lowercase
        [InlineData("asdfgwasdfbn", "UserPassword")]//long but no numbers
        [InlineData("1111111111111", "UserPassword")] //no uppercase
        [InlineData("11Pass", "UserPassword")]//correct format but short
        public void MakeNewAccount_WrongPasswordFormatShouldFail(string password, string param)
        {
            AddUser addUser = new AddUser();

            Assert.Throws<ArgumentException>(param, () => addUser.MakeNewAccount("Lex", "Carao", "lex@bai.com", 22, password));
        }



    }
}
