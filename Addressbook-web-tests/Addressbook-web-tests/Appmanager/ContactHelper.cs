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
   public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }
        public ContactHelper Create(ContactAttributes contact)
        {

            manager.Navigator.OpenHomePage();
            NewContact();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnHomePageContact();
            return this;
        }
        public ContactHelper Remove(int p)
        {

            manager.Navigator.OpenHomePage();
            SelectContact(p);
            RemovalContact();
            ReturnHomePageContact();
            return this;
        }
        public ContactHelper Modify(int p, ContactAttributes newData)
        {
            manager.Navigator.OpenHomePage();
            ModificationContact(p);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnHomePageContact();
            return this;
        }
        public ContactHelper NewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper RemovalContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactAttributes contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstnameContact);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddlenameContact);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper ReturnHomePageContact()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper ModificationContact(int index)
        {
            driver.FindElement(By.XPath("(//tbody//a[contains(@href,'edit')])[" + index + "]")).Click();
            return this;
        }
    }
}
