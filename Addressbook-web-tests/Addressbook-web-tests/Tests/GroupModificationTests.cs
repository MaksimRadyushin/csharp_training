using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupAttributes newData = new GroupAttributes("jgf554jgh");
            newData.HeaderGroup = null;
            newData.FooterGroup = null;

            app.Navigator.OpenGroupsPage();
            app.Groups.ValidationCreationGroup();

            List<GroupAttributes> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData);

            List<GroupAttributes> newGroups = app.Groups.GetGroupList();
            oldGroups[0].NameGroup = newData.NameGroup;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
