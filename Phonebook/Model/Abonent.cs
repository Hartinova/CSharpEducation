using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Model
{
  /// <summary>
  /// Абонент.
  /// </summary>
  public class Abonent
  {
    /// <summary>
    /// Максимальное количество знаков в телефоне.
    /// </summary>
    public const short MaxLengthPhone = 11;

    /// <summary>
    /// Идентификатор абонента.
    /// </summary>
    public int Id { get;private set; }

    /// <summary>
    /// Имя абонента.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Номер телефона.
    /// </summary>
    private string phoneNumber;

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string PhoneNumber 
    {
      get 
      {  
        return phoneNumber; 
      }
      set
      {
        if (value.Length <= MaxLengthPhone && long.TryParse(value, out long phone))
        {
          phoneNumber = value;
        }
        else
        {
          throw new ArgumentException($"Неверный формат номера телефона {value}.");
        }
      }
    }

    public Abonent(int id, string name, string phone)
    {
      this.Id = (id == -1) ? (Phonebook.GetPhonebook().abonents.Max(e => e.Id) + 1) : id;
      this.Name = name;
      this.phoneNumber = phone;
    }

    public Abonent(string name, string phone) : this(-1, name, phone) { }

    public Abonent(string lineFromFile)
    {
      var array = lineFromFile.Trim().Split(';');
      if (int.TryParse(array[0], out int id))
      {
        Id = id;
      }
      else
      {
        Id = -1;
      }
      Name = array[1];
      PhoneNumber = array[2];     
    }

    /// <summary>
    /// Изменить имя абонента.
    /// </summary>
    /// <param name="name">Присваимое значение имени.</param>
    public void ChangeName(string name)
    {
      this.Name = name;
    }

    /// <summary>
    /// Изменить номер телефона абонента.
    /// </summary>
    /// <param name="phoneNumber">Присваиваемое значение номера телефона.</param>
    public void ChangeNumber(string phoneNumber)
    {
      this.phoneNumber = phoneNumber;
    }
  }
}
