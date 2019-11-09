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
            GroupAttributes group = new GroupAttributes("Majssdd");
            group.HeaderGroup = "543";
            group.FooterGroup = "5455";

            app.Groups.Create(group);
            app.Auth.Logout();
        }                   
    }
}
