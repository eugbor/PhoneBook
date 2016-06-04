namespace PhoneBook
{
    using System;

    class EntryMainPoint
    {
        static void Main()
        {
            int command;
            PhoneBook phoneBook = new PhoneBook();

            do
            {
                Console.WriteLine(@"1:Найти по номеру
2:Найти по фамилии
3:Добавить новый контакт
4:Удалить запись по номеру
5:Распечатать список
6:Выход");
                int.TryParse(Console.ReadLine(), out command);
                switch (command)
                {
                    case (int)Actions.SearchByNumber:
                        phoneBook.SearchByNumber();
                        break;
                    case (int)Actions.SearchByName:
                        phoneBook.SearchByName();
                        break;
                    case (int)Actions.AddNewContact:
                        phoneBook.AddNewContact();
                        break;
                    case (int)Actions.DeleteEntryByNumber:
                        phoneBook.DeleteEntryByNumber();
                        break;
                    case (int)Actions.PrintList:
                        phoneBook.PrintList();
                        break;
                    default:
                        Console.WriteLine("Вводите значения от 1 до 6:");
                        break;
                }
            } while (command != (int)Actions.Exit);
        }
    }
}
