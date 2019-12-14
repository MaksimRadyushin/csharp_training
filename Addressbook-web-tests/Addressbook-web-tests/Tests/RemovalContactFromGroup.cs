using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_web_tests
{
   public class RemovalContactFromgroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovalContactToGroup()
        {
            List<ContactAttributes> listContacts = ContactAttributes.GetAll();
            if (listContacts.Count == 0)
            {
                app.Navigator.OpenHomePage();
                app.Contacts.AddContact();//если контактов нет, то добавляем
            }
            List<GroupAttributes> listGroups = GroupAttributes.GetAll();
            if (listGroups.Count == 0)
            {
                app.Navigator.OpenGroupsPage();
                app.Groups.AddGroup();
            }
            listGroups = GroupAttributes.GetAll();//Вновь получаем список групп
            GroupAttributes group = listGroups[0];
            List<ContactAttributes> oldList = group.GetContacts();//Получаем изначальный список контатов
            ContactAttributes contact = null;//Создаём и инициализируем контейнер  для будущего контакта
            if (oldList.Count == 0)//Проверяем наличие контактов в выбранной группе
            {
                app.Contacts.AddContactToGroup(ContactAttributes.GetAll()[0], group);//Если контактов нет то создаём
                oldList = group.GetContacts(); //Заново получаем список контактов
                contact = oldList[0];//Выбираем первый из списка контактов
            }
            else
            {
                oldList = group.GetContacts();//Если же список контактов не пуст то получем список контактов
                contact = oldList[rnd.Next(0, oldList.Count - 1)];//Случайным образом выбираем контакт из списка контактов
            }
            app.Contacts.RemoveContactFromGroup(contact, group);
            List<ContactAttributes> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

    //        Assert.AreEqual(oldList, newList);
        }
    }
}