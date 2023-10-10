using System.ComponentModel.DataAnnotations;

namespace SampleRestAPI.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Status { get; set; }
  //  [Range(18, 60)]
    public int Age { get; set; }
}
