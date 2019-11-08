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
            app.Navigator.OpenGroupsPage();
            app.Auth.Logout();
            app.Groups
                .NewGroup()
                .FillGroupForm(new GroupAttributes("RaDYUS5HIfNmAKS", "mAfK1S", "Maf4ks"))
                .SubmitGroupCreation()
                .ReturnHomePageGroup();
        }                   
    }
}
