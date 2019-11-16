using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactAttributes newData = new ContactAttributes("test");
            newData.MiddlenameContact = "test2";

            app.Contacts.Modify(1, newData);
           // app.Auth.Logout();
        }
    }
}
