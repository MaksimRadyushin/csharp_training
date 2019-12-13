using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactDetailsInformationTests : GroupTestBase
    {
        [Test]
        public void TestDetailsContactInformation()
        {
            ContactAttributes fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            string infoForm = app.Contacts.GetContactInformationFromDetailsForm(0);
            Assert.AreEqual(fromForm.AboutContact, infoForm);
        }
    }
}
