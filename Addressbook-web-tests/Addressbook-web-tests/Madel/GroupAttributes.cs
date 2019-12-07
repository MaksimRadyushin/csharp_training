using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
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
    }
}

