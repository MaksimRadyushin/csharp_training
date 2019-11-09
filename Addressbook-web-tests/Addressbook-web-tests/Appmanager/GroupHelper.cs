using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Addressbook_web_tests
{
   public class GroupHelper : HelperBase
    {
  
        public GroupHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public GroupHelper Create(GroupAttributes group)
        {

            manager.Navigator.OpenGroupsPage();
            NewGroup();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnHomePageGroup();
            return this;
        }

        public GroupHelper Remove(int p)
        {

            manager.Navigator.OpenGroupsPage();
            SelectGroup(p);
            RemovalGroup();
            ReturnHomePageGroup();
            return this;
        }
        public GroupHelper Modify(int p, GroupAttributes newData)
        {
            manager.Navigator.OpenGroupsPage();
            SelectGroup(p);
            ModificationGroup();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnHomePageGroup();

            return this;
        }

        public GroupHelper NewGroup()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemovalGroup()
        {
            driver.FindElement(By.Name("delete")).Click(); ;
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupAttributes group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.NameGroup);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.HeaderGroup);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.FooterGroup);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper ReturnHomePageGroup()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper ModificationGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
