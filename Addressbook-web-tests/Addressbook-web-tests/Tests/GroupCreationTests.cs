using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests 
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {
            GroupAttributes group = new GroupAttributes("Majssdd");
            group.HeaderGroup = "543";
            group.FooterGroup = "5455";

            List<GroupAttributes> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupAttributes> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }                   
    }
}
