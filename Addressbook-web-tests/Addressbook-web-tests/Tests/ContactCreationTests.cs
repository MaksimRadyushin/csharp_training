using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {        
        [Test]
        public void ContactCreationTest()
        {
            ContactAttributes contact = new ContactAttributes("89984899");
            contact.MiddlenameContact = "5455545";

            app.Contacts.Create(contact);
            app.Auth.Logout();
        }           
    }
}
