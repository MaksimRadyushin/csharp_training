using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    class ContactAttributes
    {
        private string firstnameContact;
        private string middlenameContact;

        public ContactAttributes(string firstname, string middlename)
        {
            this.firstnameContact = firstname;
            this.middlenameContact = middlename;
        }

        public string FirstnameContact
        {
            get
            {
                return firstnameContact;
            }
            set
            {
                firstnameContact = value;
            }
        }

        public string MiddlenameContact
        {
            get
            {
                return middlenameContact;
            }
            set
            {
                middlenameContact = value;
            }
        }
    }
}
