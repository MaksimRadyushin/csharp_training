using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.OpenGroupsPage();
            app.Groups.ValidationCreationGroup();

            List<GroupAttributes> oldGroups = GroupAttributes.GetAll();
            GroupAttributes toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            List<GroupAttributes> newGroups = GroupAttributes.GetAll();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            foreach(GroupAttributes group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
