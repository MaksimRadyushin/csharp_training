using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {        
        [Test]
        public void ContactCreationTest()
        {
            app.Auth.Logout();
            app.Contacts
                .NewContact()
                .FillContactForm(new ContactAttributes("m56f64AKS", "5mAf5KdS"))
                .SubmitContactCreation()
                .ReturnHomePageContact();
        }           
    }
}
