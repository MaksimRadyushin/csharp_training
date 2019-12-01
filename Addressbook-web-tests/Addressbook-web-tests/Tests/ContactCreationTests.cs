using NUnit.Framework;
using System.Collections.Generic;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        public static IEnumerable<ContactAttributes> RandomContactDataProvider()
        {
            List<ContactAttributes> contact = new List<ContactAttributes>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactAttributes(GenerateRandomString(20), GenerateRandomString(20))
                {

                    Address = GenerateRandomString(20),
                    MobilePhone = GenerateRandomPhonenumber(10),
                    WorkPhone = GenerateRandomPhonenumber(10),
                    HomePhone = GenerateRandomPhonenumber(10)

                });
            }
            return contact;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactAttributes contact)
        {

     

            //ContactAttributes contact = new ContactAttributes("00jfjghf", "jhgj545454h");
            //contact.Address = "1";
            //contact.HomePhone = "8(999)-764-55-55";
            //contact.MobilePhone = "3";
            //contact.WorkPhone = "4";
            //contact.Email = "5";
            //contact.Email2 = "6";
            //contact.Email3 = "7";


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
