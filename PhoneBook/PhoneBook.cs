using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    public class PhoneBook : IEnumerable<PhoneBookItem>
    {
        private List<PhoneBookItem> phoneBookItems;

        public PhoneBook()
        {
            this.phoneBookItems = GetRandomPhoneBookItem();
        }

        private static List<PhoneBookItem> GetRandomPhoneBookItem()
        {
            string[] firstNames = new string[] { "Иван", "Илья", "Евгений", "Антон", "Степан" };
            string[] lastNames = new string[] { "Петров", "Смирнов", "Иванов", "Сидоров", "Белов" };

            List<PhoneBookItem> list = new List<PhoneBookItem>();
            Random ran = new Random();
            for (int i = 0; i < firstNames.Length; i++)
            {
                for (int j = 0; j < lastNames.Length; j++)
                {
                    int number = ran.Next(10000, 35000);
                    list.Add(new PhoneBookItem(number, firstNames[i], lastNames[j]));
                }
            }

            return list;
        }

        public IEnumerator<PhoneBookItem> GetEnumerator()
        {
            return phoneBookItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void SearchByNumber()
        {
            Console.WriteLine("Введите номер абонента для поиска:");
            int nomer = int.Parse(Console.ReadLine());
            PhoneBookItem spp = new PhoneBookItem(nomer, "", "");
            PhoneBookItem sp = phoneBookItems.Find(new Predicate<PhoneBookItem>(spp.Findnumber));
            if (sp != null)
            {
                Console.WriteLine(sp);
            }
            else
            {
                Console.WriteLine("Абонент с таким номером не найден:");
            }
        }

        public void SearchByName()
        {
            Console.WriteLine("Введите фамилию абонента для поиска:");
            string lastName = Console.ReadLine();
            var search = phoneBookItems.Where(e => e.lastName.ToLower() == lastName.ToLower());
            Console.WriteLine("Результаты поиска:");

            if (search != null)
            {
                foreach (var item in search)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void AddNewContact()
        {
            Console.Write("Введите имя: ");
            string fname = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string lname = Console.ReadLine();
            Console.Write("Введите номер: ");
            int num = int.Parse(Console.ReadLine());
            phoneBookItems.Add(new PhoneBookItem(num, fname, lname));
        }

        public void DeleteEntryByNumber()
        {
            Console.Write("Введите номер для удаления: ");
            int remnum = int.Parse(Console.ReadLine());
            PhoneBookItem remEntry = phoneBookItems.Where(e => e.Number == remnum).FirstOrDefault();
            phoneBookItems.Remove(remEntry);
        }

        public void PrintList()
        {
            foreach (var item in phoneBookItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}
