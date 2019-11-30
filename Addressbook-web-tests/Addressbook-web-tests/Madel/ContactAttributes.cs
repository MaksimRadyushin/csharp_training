using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Addressbook_web_tests
{
   public class ContactAttributes : IEquatable<ContactAttributes>, IComparable<ContactAttributes>
    {
        private string allEmails;
        private string allPhones;

        public ContactAttributes(string firstnameContact, string lastnameContact)
        {
            FirstnameContact = firstnameContact;
            LastnameContact = lastnameContact;
        }

        public bool Equals(ContactAttributes other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstnameContact == other.FirstnameContact) && (LastnameContact == other.LastnameContact);
        }

        public override int GetHashCode()
        {
            return FirstnameContact.GetHashCode(); 
        }

        public override string ToString()
        {
            return "name" + FirstnameContact + " " + LastnameContact;
        }

        public int CompareTo(ContactAttributes other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastnameContact.CompareTo(other.LastnameContact) == 0)
            {
                return (FirstnameContact.CompareTo(other.FirstnameContact));
            }
            else { return LastnameContact.CompareTo(other.LastnameContact); }
            
        }

        public string FirstnameContact { get; set; }

        public string LastnameContact { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if(allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return Email+ "\r\n" + Email2 + "\r\n" + Email3;
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
    }
}
