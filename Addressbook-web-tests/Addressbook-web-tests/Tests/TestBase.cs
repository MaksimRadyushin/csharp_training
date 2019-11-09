using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
   public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
           app = new ApplicationManager();

           app.Navigator.OpenHomePage();
           app.Auth.Authorization("admin", "secret");
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }             
   }
}
