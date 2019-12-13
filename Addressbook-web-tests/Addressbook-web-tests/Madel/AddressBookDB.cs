using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace Addressbook_web_tests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook") { }

        public ITable<GroupAttributes> Groups { get { return GetTable<GroupAttributes>(); } }

        public ITable<ContactAttributes> Contacts { get { return GetTable<ContactAttributes>(); } }
    }
}
