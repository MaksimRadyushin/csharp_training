using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : GroupTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.OpenHomePage();
            app.Contacts.ValidationCreationContact();

            List<ContactAttributes> oldContacts = ContactAttributes.GetAll();
            ContactAttributes toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);

            List<ContactAttributes> newContacts = ContactAttributes.GetAll();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactAttributes contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
