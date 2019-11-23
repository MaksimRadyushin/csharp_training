using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
   public class ContactAttributes : IEquatable<ContactAttributes>, IComparable<ContactAttributes>
    {
        private string firstnameContact;
        private string lastnameContact ;

        public ContactAttributes(string firstnameContact, string lastnameContact)
        {
            this.firstnameContact = firstnameContact;
            this.lastnameContact = lastnameContact;
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

        public string LastnameContact
        {
            get
            {
                return lastnameContact;
            }
            set
            {
                lastnameContact = value;
            }
        }
    }
}
