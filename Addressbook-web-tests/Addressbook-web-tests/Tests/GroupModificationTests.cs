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
            GroupAttributes newData = new GroupAttributes("jgfjgh");
            newData.HeaderGroup = null;
            newData.FooterGroup = null;

            app.Navigator.OpenGroupsPage();
            app.Groups.ValidationCreationGroup();
            app.Groups.Modify(1, newData);
        }
    }
}
