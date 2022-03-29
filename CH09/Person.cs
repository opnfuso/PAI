using System.Xml.Serialization;

namespace CH09
{
  public class Person
  {
    public Person()
    {

    }

    public Person(decimal initialSalary)
    {
      Salary = initialSalary;
    }

    [XmlAttribute("FName")]
    public string? FirstName { get; set; }

    [XmlAttribute("LName")]
    public string? LastName { get; set; }

    [XmlAttribute("DoB")]
    public DateTime DateOfBirth { get; set; }

    public HashSet<Person> Children { get; set; }
    protected decimal Salary { get; set; }
  }
}