using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Addressbook_web_tests
{
    [Table(Name = "group_list")]
    public class GroupAttributes : IEquatable<GroupAttributes>, IComparable<GroupAttributes>
    {
            private string nameGroup;
            private string headerGroup = "";
            private string footerGroup = "";


        public GroupAttributes()
        {
        }


        public GroupAttributes(string nameGroup)
        {
            this.nameGroup = nameGroup;
        }

        public bool Equals(GroupAttributes other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return NameGroup == other.NameGroup;
        }
        
        public override int GetHashCode()
        {
            return NameGroup.GetHashCode();
        }


        public override string ToString()
        {
            return "name=" + NameGroup + "\nheader=" + HeaderGroup + "\nfooter" + FooterGroup;
        }

        public int CompareTo(GroupAttributes other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return NameGroup.CompareTo(other.NameGroup);
        }


        [Column(Name = "group_name"), NotNull]
        public string NameGroup
            {
                get
                {
                    return nameGroup;
                }
                set
                {
                    nameGroup = value;
                }
            }


        [Column(Name = "group_header"), NotNull]
        public string HeaderGroup
            {
                get
                {
                    return headerGroup;
                }
                set
                {
                    headerGroup = value;
                }
            }


        [Column(Name = "group_footer"), NotNull]
        public string FooterGroup
            {
                get
                {
                    return footerGroup;
                }
                set
                {
                    footerGroup = value;
                }
            }


        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupAttributes> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        public List<ContactAttributes> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }
    }
}

