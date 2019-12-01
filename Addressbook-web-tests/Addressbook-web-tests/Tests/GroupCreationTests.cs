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
        
        public static IEnumerable<GroupAttributes> RandomGroupDataProvider()
        {
            List<GroupAttributes> groups = new List<GroupAttributes>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupAttributes(GenerateRandomString(30))
                {
                    HeaderGroup = GenerateRandomString(100),
                    FooterGroup = GenerateRandomString(100)
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupAttributes group)
        {
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
