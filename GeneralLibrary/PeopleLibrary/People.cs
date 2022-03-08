namespace PeopleLibrary;
//access modifier
//public, private, protected
//private protected, protected protected, public protected
using System.Collections; //List<T>, Tuple<>, Dictionary<>
public class Person
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

}
