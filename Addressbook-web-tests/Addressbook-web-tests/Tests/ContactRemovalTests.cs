using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            app.Contacts.Remove(1);
           // app.Auth.Logout();
        }
    }
}
