using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace Addressbook_web_tests
{
    [Table(Name = "addressbook")]
    public class ContactAttributes : IEquatable<ContactAttributes>, IComparable<ContactAttributes>
    {
        private string allEmails;
        private string allPhones;
        private string aboutContact;
        public ContactAttributes() { }

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
            return "name" + FirstnameContact + " " + LastnameContact + MobilePhone + WorkPhone + HomePhone;
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

        [Column(Name = "firstname"), NotNull]
        public string FirstnameContact { get; set; }

        [Column(Name = "lastname"), NotNull]
        public string LastnameContact { get; set; }

        [Column(Name = "address"), NotNull]
        public string Address { get; set; }

        [Column(Name = "home"), NotNull]
        public string HomePhone { get; set; }

        [Column(Name = "mobile"), NotNull]
        public string MobilePhone { get; set; }

        [Column(Name = "work"), NotNull]
        public string WorkPhone { get; set; }

        [Column(Name = "email"), NotNull]
        public string Email { get; set; }

        [Column(Name = "email2"), NotNull]
        public string Email2 { get; set; }

        [Column(Name = "email3"), NotNull]
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
                    return (CleanEmail(Email) + CleanEmail(Email2) + CleanEmail(Email3)).Trim();
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
            return Regex.Replace(phone, "[- ()]", "") + "\r\n";
        }

        private string CleanEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ ]", "") + "\r\n";
        }

        private string CleanAddress(string address)
        {
            if (address == null || address == "")
            {
                return "";
            }
            return Regex.Replace(address, "[ ]", "") + "\r\n";
        }

        public string AboutContact
        {
            get
            {
                if (aboutContact != null)
                {
                    return aboutContact;
                }

                else
                {
                    if (HomePhone != null)
                    { 
                        HomePhone = "H: " + HomePhone + "\r\n"; 
                    }
                    if (MobilePhone != null)
                    {
                        MobilePhone = "M: " + MobilePhone + "\r\n"; 
                    }
                    if (WorkPhone != null)
                    {
                        WorkPhone = "W: " + WorkPhone + "\r\n"; 
                    }

                    return (FirstnameContact + " " + LastnameContact + "\r\n" + Address + "\r\n" + "\r\n" + HomePhone + MobilePhone + WorkPhone + "\r\n" + AllEmails).Trim();
                }
            }
            set
            {
                aboutContact = value;
            }

        }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<ContactAttributes> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }
    }
}
