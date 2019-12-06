using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Addressbook_web_tests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeTest = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string newFormat = args[3];
            //string typeTest = args[0];
            if (typeTest == "contacts")
            {
                List<ContactAttributes> contacts = new List<ContactAttributes>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactAttributes(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        Address = TestBase.GenerateRandomString(10),
                        HomePhone = TestBase.GenerateRandomPhonenumber(10),
                        MobilePhone = TestBase.GenerateRandomPhonenumber(10),
                        WorkPhone = TestBase.GenerateRandomPhonenumber(10),
                        Email = TestBase.GenerateRandomString(10),
                        Email2 = TestBase.GenerateRandomString(10),
                        Email3 = TestBase.GenerateRandomString(10)
                    }
                    );
                }
                if (newFormat == "csv")
                {
                    WritecontactToCsvFile(contacts, writer);
                }
                else if (newFormat == "xml")
                {
                    WritecontactToXmlFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Указан не верный формат файла " + newFormat);
                }
            }
            else if (typeTest == "groups")
            {
                List<GroupAttributes> groups = new List<GroupAttributes>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupAttributes(TestBase.GenerateRandomString(10))
                    {
                        HeaderGroup = TestBase.GenerateRandomString(10),
                        FooterGroup = TestBase.GenerateRandomString(10)
                    }
                    );
                }
                if (newFormat == "csv")
                {
                    WritegroupsToCsvFile(groups, writer);
                }
                else if (newFormat == "xml")
                {
                    WritegroupsToXmlFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Указан не верный формат файла " + newFormat);
                }
            }
            writer.Close();
        }

        static void WritegroupsToCsvFile(List<GroupAttributes> groups, StreamWriter writer)
        {
            foreach (GroupAttributes group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.NameGroup, group.HeaderGroup, group.FooterGroup));
            }
        }
        static void WritegroupsToXmlFile(List<GroupAttributes> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupAttributes>)).Serialize(writer, groups);
        }

        static void WritecontactToCsvFile(List<ContactAttributes> contacts, StreamWriter writer)
        {
            foreach (ContactAttributes contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8}",
                    contact.FirstnameContact,
                    contact.LastnameContact,
                    contact.Address,
                    contact.HomePhone,
                    contact.MobilePhone,
                    contact.WorkPhone,
                    contact.Email,
                    contact.Email2,
                    contact.Email3));
            }
        }
        static void WritecontactToXmlFile(List<ContactAttributes> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactAttributes>)).Serialize(writer, contacts);
        }
    }
}
