using System;
using System.Collections.Generic;
using System.Linq;

namespace Users.Model
{
  /// <summary>
  /// Список персон.
  /// </summary>
  public class UserList
  {
    #region Поля и свойства

    /// <summary>
    /// Список пользователей.
    /// </summary>
    private List<Person> list;

    #endregion

    #region Методы

    /// <summary>
    /// Добавить персону в список.
    /// </summary>
    /// <param name="user">Добавляемая персона.</param>
    /// <exception cref="ArgumentNullException">Ошибка возникает, если не задана персона для добавления.</exception>
    /// <exception cref="ArgumentException">Ошибка возникает, если пользователь уже существует в списке пользователей.</exception>
    public void Add(Person user)
    {
      if (user == null)
      {
        throw new ArgumentNullException("Не задан пользователь для добавления.");
      }
      if (list.Contains(user))
      {
        throw new ArgumentException($"Пользователь {user.Name} уже заведен.");
      }

      list.Add(user);
      Console.WriteLine($"Пользователь {user.Name} добавлен в список пользователей.");
    }

    /// <summary>
    /// Удалить пользователя из списка пользователей.
    /// </summary>
    /// <param name="user">Удаляемый пользователь.</param>
    /// <exception cref="ArgumentNullException">Ошибка возникает, если не задан пользователь для удаления.</exception>
    /// <exception cref="ArgumentException">Ошибка возникает, если в списке пользователей не найден удаляемый пользователь.</exception>
    public void Delete(Person user)
    {
      if (user == null)
      {
        throw new ArgumentNullException("Не задан пользователь для удаления.");
      }
      if (!list.Contains(user))
      {
        throw new ArgumentException($"В списке пользователей не найден пользователь {user.Name}.");
      }

      list.Remove(user);
      Console.WriteLine($"Пользователь {user.Name} удален из списка пользователей.");
    }

    /// <summary>
    /// Распечатать список пользователей.
    /// </summary>
    /// <exception cref="ArgumentNullException">Ошибка возникает, если список пользователей пуст.</exception>
    public void Print()
    {
      if (list == null || list.Count() == 0)
      {
        throw new ArgumentNullException("Список пользователей пуст.");
      }

      Console.WriteLine("Список пользователей:");
      foreach (var item in list)
      {
        Console.WriteLine(item.Name);
      }

    }

    #endregion 

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public UserList()
    {
      list = new List<Person>();
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="users">Список пользователей.</param>
    public UserList(List<Person> users)
    {
      this.list = users;
    }

    #endregion
  }
}
