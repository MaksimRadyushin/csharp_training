using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupAttributes newData = new GroupAttributes("888");
            newData.HeaderGroup = "888";
            newData.FooterGroup = "888";

            app.Groups.Modify(1, newData);
        }
    }
}
