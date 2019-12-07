using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml;


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

        public static IEnumerable<ContactAttributes> ContactDataFromCsvFile()
        {
            List<ContactAttributes> contacts = new List<ContactAttributes>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactAttributes(parts[0], parts[1])
                {
                    Address = parts[2],
                    HomePhone = parts[3],
                    MobilePhone = parts[4],
                    WorkPhone = parts[5],
                    Email = parts[6],
                    Email2 = parts[7],
                    Email3 = parts[8]
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactAttributes> ContactDataFromXmlFile()
        {
            return (List<ContactAttributes>)
                 new XmlSerializer(typeof(List<ContactAttributes>))
                 .Deserialize(new StreamReader(@"contacts.xml"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
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
