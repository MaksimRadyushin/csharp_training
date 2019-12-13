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

        public String GetContactInformationFromDetailsForm(int index)
        {
            manager.Navigator.OpenHomePage();
            DetailsContact(index);
            string contactDetails = driver.FindElement(By.XPath("//div[@id = 'content']")).Text;

            return contactDetails;
        }

        public ContactHelper DetailsContact(int index)
        {
            driver.FindElement(By.XPath("(//tbody//a[contains(@href,'view')])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactAttributes GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhone = cells[5].Text;

            return new ContactAttributes(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmail,
                AllPhones = allPhone,
            };


        }

        public ContactAttributes GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            ModificationContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactAttributes(firstName, lastName)
            {
                Address = address,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
            };
            
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
        public ContactHelper Remove(ContactAttributes contact)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(contact.Id);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
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
            contactCache = null;
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("//input[@name = 'selected[]' and @value='" + id + "']")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactAttributes contact)
        {
            Type(By.Name("firstname"), contact.FirstnameContact);
            Type(By.Name("lastname"), contact.LastnameContact);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
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
            contactCache = null;
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

        private List<ContactAttributes> contactCache = null;

        public List<ContactAttributes> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactAttributes>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                ICollection<IWebElement> cells = null;
                foreach (IWebElement element in elements)
                {
                    cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactAttributes(cells.ElementAt(2).Text, cells.ElementAt(1).Text));
                }
            }
            return new List<ContactAttributes>(contactCache);
        }
    }
}
