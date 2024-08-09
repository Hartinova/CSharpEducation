using Phonebook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Model.Phonebook.CreateFileForTest(); 

      Model.Phonebook phonebook = Model.Phonebook.GetPhonebook();

      Console.WriteLine("Cписок абонентов из файла:");
      phonebook.PrintAbonents();

      string nameForFind = "тимур";
      if (phonebook.GetPhoneNumberByName(nameForFind, out string number))
      {
        Console.WriteLine($"Номер телефона искомого абонента {nameForFind}: {number}");
      }
      else
      {
        Console.WriteLine($"Абонент {nameForFind} не найден.");
      }
      Console.ReadLine();

      string numberForFind = "81221234569";
      if (phonebook.GetNameByPhoneNumber(numberForFind, out string name))
      {
        Console.WriteLine($"Имя абонента с номером телефона {numberForFind}: {name}");
      }
      else
      {
        Console.WriteLine($"Абонент с номером {numberForFind} не найден.");
      }
      Console.ReadLine();

      string nameForAdd = "Влад";
      string numberForAdd = "12333612322";
      phonebook.AddAbonent(nameForAdd, numberForAdd);
      Console.WriteLine($"Добавлен абонент {nameForAdd}:");
      phonebook.PrintAbonents();

      var abonent2 = phonebook.abonents[2];
      phonebook.DeleteAbonent(abonent2);
      Console.WriteLine($"Удален абонент {abonent2.Id}:");
      phonebook.PrintAbonents();

      var abonent = phonebook.abonents[1];
      abonent.ChangeName("Лена");
      Console.WriteLine($"У абонента {abonent.Id} изменено имя:");
      phonebook.PrintAbonents();

      abonent.ChangeNumber("99999999999");
      Console.WriteLine($"У абонента {abonent.Id} изменен номер:");
      phonebook.PrintAbonents();

      phonebook.SaveToFile();
    }
  }
}
