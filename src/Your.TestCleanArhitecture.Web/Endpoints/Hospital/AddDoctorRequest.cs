using System.ComponentModel.DataAnnotations;

namespace Your.TestCleanArhitecture.Web.Endpoints.Hospital;

public class AddDoctorRequest
{
  public const string Route = "/Hospital";

  [Required]
  public int? Id { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? MiddleName { get; set; }
  public int Post { get; set; }
  public int ReceptionSchedule { get; set; }
}
