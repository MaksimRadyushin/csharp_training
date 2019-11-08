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
            OpenHomePage();
            Authorization("admin", "secret");
            NewContact();
            FillContactForm(new ContactAttributes("m5664AKS", "5mA5KdS"));
            SubmitContactCreation();
            ReturnHomePageContact();
            Logout();
        }           
    }
}
