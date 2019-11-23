using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.OpenHomePage();
            app.Contacts.ValidationCreationContact();

            List<ContactAttributes> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(0);

            List<ContactAttributes> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
