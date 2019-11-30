using NUnit.Framework;
using System.Collections.Generic;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {        
        [Test]
        public void ContactCreationTest()
        {
            ContactAttributes contact = new ContactAttributes("00jfjghf", "jhgj545454h");
            contact.Address = "1";
            contact.HomePhone = "8(999)-764-55-55";
            contact.MobilePhone = "3";
            contact.WorkPhone = "4";
            contact.Email = "5";
            contact.Email2 = "6";
            contact.Email3 = "7";


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
