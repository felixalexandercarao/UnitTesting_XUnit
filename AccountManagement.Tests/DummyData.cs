using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Tests
{
    public class DummyData
    {
        public class AddUserTestDataMissingFields : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { "", "Carao", "testCustomname", "lex@bai.com", 22, "321Password", "UserFirstName" };
                yield return new object[] { "Lex", "", "testCustomname", "lex@bai.com", 22, "321Password", "UserLastName" };
                yield return new object[] { "Lex", "Carao", "", "lex@bai.com", 22, "321Password", "UserCustomName" };
                yield return new object[] { "Lex", "Carao", "testCustomname", "", 22, "321Password", "UserEmail" };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class AddUserTestDataWrongPasswords : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { "AAAAAAAAAAAAA", "UserPassword" };//no lowercase
                yield return new object[] { "asdfgwasdfbn", "UserPassword" };//long but no numbers
                yield return new object[] { "1111111111111", "UserPassword" };//no uppercase
                yield return new object[] { "11Pass", "UserPassword" };//correct format but short

            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class EditUserTestDataMissingFields : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { "", "Carao","editcustname1","bailex1@yahoo.com",  22, "UserFirstName" };
                yield return new object[] { "Lex", "", "editcustname2", "bailex2@yahoo.com", 22,  "UserLastName" };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
