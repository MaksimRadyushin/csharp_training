﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.OpenGroupsPage();
            app.Groups.ValidationCreationGroup();
            app.Groups.Remove(1);
            //app.Auth.Logout();
        }
    }
}
