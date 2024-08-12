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
    private const short MaxLengthPhone = 11;

    /// <summary>
    /// Идентификатор абонента.
    /// </summary>
    public int Id { get;private set; }

    /// <summary>
    /// Имя абонента.
    /// </summary>
    private string name;

    /// <summary>
    /// Имя абонента.
    /// </summary>
    public string Name 
    {
      get
      {
        return name;
      } 
      private set
      {
        name = value.Trim();
      }
    }
    
    /// <summary>
    /// Имя в нижней раскладке.
    /// </summary>
    public string NameLower
    {
      get
      { 
        return name.ToLower(); 
      }
    }

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
          phoneNumber = value.Trim();
        }
        else
        {
          throw new ArgumentException($"Неверный формат номера телефона {value}.");
        }
      }
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

    /// <summary>
    /// Получить новый идентификатор.
    /// </summary>
    /// <returns>Новый идентификатор.</returns>
    private int NewId()
    {
      if (Phonebook.Instance.Abonents == null || Phonebook.Instance.Abonents.Count() == 0)
      { 
        return 1; 
      }

      return Phonebook.Instance.Abonents.Max(e => e.Id) + 1;
    }

    public Abonent(string name, string phone)
    {
      this.Id = NewId();
      this.Name = name;
      this.phoneNumber = phone;
    }

    public Abonent(int id, string name, string phone)
    {
      this.Id = id;
      this.Name = name;
      this.phoneNumber = phone;
    }
  }
}
