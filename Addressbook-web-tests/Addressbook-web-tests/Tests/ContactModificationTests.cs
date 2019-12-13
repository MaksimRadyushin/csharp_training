using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : GroupTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactAttributes newData = new ContactAttributes("te455dsat","3JH545JH534");
            //newData.LastnameContact = "test2";

            app.Navigator.OpenHomePage();
            app.Contacts.ValidationCreationContact();

            List<ContactAttributes> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0, newData);

            List<ContactAttributes> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstnameContact = newData.FirstnameContact;
            oldContacts[0].LastnameContact = newData.LastnameContact;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            // app.Auth.Logout();
        }
    }
}
