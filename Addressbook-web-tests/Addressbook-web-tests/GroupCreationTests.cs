using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Addressbook_web_tests 
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Authorization("admin", "secret");
            OpenGroupsPage();
            NewGroup();
            FillGroupForm(new GroupAttributes("RaDYUS5HINmAKS","mAK1S","Ma4ks"));
            SubmitGroupCreation();
            ReturnHomePageGroup();
            Logout();
        }                   
    }
}
