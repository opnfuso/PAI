namespace PeopleLibrary;
//access modifier
//public, private, protected
//private protected, protected protected, public protected
using System.Collections; //List<T>, Tuple<>, Dictionary<>
public class Person : IComparable<Person>
{
  // field, member
  // private string FirstName;

  //prop
  public string FirstName { get; set; }
  private string SurName;

  public DateTime DateOfBirth;

  public VaccineApplied vaccine;

  public List<Person> Children = new List<Person>();
  //Tuplas tipos de datos compuestos
  public (string, int) GetFruit()
  {
    return ("Apple", 5);
  }

  public int CompareTo(Person? other)
  {
    if (other is null)
    {
      return 0;
    }
    return FirstName.CompareTo(other.FirstName);
  }
}
