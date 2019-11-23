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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactAttributes contact)
        {
            Type(By.Name("firstname"), contact.FirstnameContact);
            Type(By.Name("lastname"), contact.LastnameContact);
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
            driver.FindElement(By.XPath("(//tbody//a[contains(@href,'edit')])[" + (index+1) + "]")).Click();
            return this;
        }
        public void ValidationCreationContact()
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                NewContact();
                ContactAttributes newContact = new ContactAttributes("Maksim","Radysuhin");
                //newContact.LastnameContact = "Radyushin";
                FillContactForm(newContact);
                SubmitContactCreation();
                ReturnHomePageContact();

            }
        }
        public List<ContactAttributes> GetContactList()
        {
            List<ContactAttributes> contacts = new List<ContactAttributes>();
            manager.Navigator.OpenHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            ICollection<IWebElement> cells = null;
            foreach (IWebElement element in elements)
            {
                cells = element.FindElements(By.TagName("td"));
                contacts.Add(new ContactAttributes(cells.ElementAt(2).Text, cells.ElementAt(1).Text));
            }
            return contacts;
        }
    }
}
