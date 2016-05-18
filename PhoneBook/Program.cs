using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Spravochnik
    {
        string firstName;
        public string lastName { get; set; }

        public int Number { get; set; }

        public override string ToString()
        {
            return String.Format("Абонент по имени: {0} {1},зарегистрирован за номером: {2}", firstName, lastName, Number);
        }
        public Spravochnik(int number, string firstName, string lastName)
        {
            this.Number = number;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public bool Findname(Spravochnik sp)
        {
            return sp.lastName == lastName;
        }
        public bool Findnumber(Spravochnik sp)
        {
            return sp.Number == Number;
        }
    }
    class EntryMainPoint
    {
        static void Main()
        {
            string command;
            List<Spravochnik> mylist = GetRandomSpravochnik();

            do
            {
                Console.WriteLine(@"1:Найти по номеру
2:Найти по фамилии
3:Добавить новый контакт
4:Удалить запись по номеру
5:Распечатать список
6:выход");
                command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        Console.WriteLine("Введите номер абонента для поиска:");
                        int nomer = int.Parse(Console.ReadLine());
                        Spravochnik spp = new Spravochnik(nomer, "", "");
                        Spravochnik sp = mylist.Find(new Predicate<Spravochnik>(spp.Findnumber));
                        if (sp != null)
                        {
                            Console.WriteLine(sp);
                        }
                        else
                        {
                            Console.WriteLine("Абонент с таким номером не найден:");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите фамилию абонента для поиска:");
                        string lastName = Console.ReadLine();
                        var search = mylist.Where(e => e.lastName == lastName);
                        Console.WriteLine("Результаты поиска:");

                        if (search != null)
                        {
                            foreach (var item in search)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    case "3":
                        Console.Write("Введите имя: ");
                        string fname = Console.ReadLine();
                        Console.Write("Введите фамилию: ");
                        string lname = Console.ReadLine();
                        Console.Write("Введите номер: ");
                        int num = int.Parse(Console.ReadLine());
                        mylist.Add(new Spravochnik(num, fname, lname));
                        break;
                    case "4":
                        Console.Write("Введите номер для удаления: ");
                        int remnum = int.Parse(Console.ReadLine());
                        Spravochnik remEntry = mylist.Where(e => e.Number == remnum).FirstOrDefault();
                        mylist.Remove(remEntry);
                        break;
                    case "5":
                        foreach (var item in mylist)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    default:
                        Console.WriteLine("Вводите значения от 1 до 6:");
                        break;
                }

            } while (command != "6");
        }

        static List<Spravochnik> GetRandomSpravochnik()
        {
            string[] firstNames = new string[] { "Иван", "Илья", "Евгений", "Антон", "Степан" };
            string[] lastNames = new string[] { "Петров", "Смирнов", "Иванов", "Сидоров", "Белов" };

            List<Spravochnik> list = new List<Spravochnik>();
            Random ran = new Random();
            for (int i = 0; i < firstNames.Length; i++)
            {
                for (int j = 0; j < lastNames.Length; j++)
                {
                    int number = ran.Next(10000, 35000);
                    list.Add(new Spravochnik(number, firstNames[i], lastNames[j]));
                }
            }

            return list;
        }
    }
}
