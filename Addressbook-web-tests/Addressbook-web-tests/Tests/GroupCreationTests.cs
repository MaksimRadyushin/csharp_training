using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using System.Xml.Serialization;
using System.Xml;
using System.Linq;

namespace Addressbook_web_tests 
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        
        public static IEnumerable<GroupAttributes> RandomGroupDataProvider()
        {
            List<GroupAttributes> groups = new List<GroupAttributes>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupAttributes(GenerateRandomString(30))
                {
                    HeaderGroup = GenerateRandomString(100),
                    FooterGroup = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupAttributes> GroupDataFromCsvFile()
        {
            List<GroupAttributes> groups = new List<GroupAttributes>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupAttributes(parts[0])
                {
                    HeaderGroup = parts[1],
                    FooterGroup = parts[2]
                });
            }
                return groups;
        }


        public static IEnumerable<GroupAttributes> GroupDataFromXmlFile()
        {
            return (List<GroupAttributes>)
                new XmlSerializer(typeof(List<GroupAttributes>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }


        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void GroupCreationTest(GroupAttributes group)
        {
            List<GroupAttributes> oldGroups = GroupAttributes.GetAll();

            app.Groups.Create(group);

            List<GroupAttributes> newGroups = GroupAttributes.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupAttributes> fromUi = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<GroupAttributes> fromDB = GroupAttributes.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
    }
}
