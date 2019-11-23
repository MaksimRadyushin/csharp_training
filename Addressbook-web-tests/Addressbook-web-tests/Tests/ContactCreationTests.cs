using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {        
        [Test]
        public void ContactCreationTest()
        {
            ContactAttributes contact = new ContactAttributes("89984444899", "5554445");
            //contact.LastnameContact = "5455545";

            List<ContactAttributes> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactAttributes> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }        
    }
}
