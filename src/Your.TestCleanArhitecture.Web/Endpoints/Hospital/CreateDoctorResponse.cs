namespace Your.TestCleanArhitecture.Web.Endpoints.Hospital;

public class CreateDoctorResponse
{
  public CreateDoctorResponse(int id, string? firstName, string? lastName, string? middleName, int? post, int? receptionSchedule)
  {
    Id = id;
    FirstName = firstName;
    LastName = lastName;
    MiddleName = middleName;
    Post = post;
    ReceptionSchedule = receptionSchedule;

  }
  public int? Id { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? MiddleName { get; set; }
  public int? Post { get; set; }
  public int? ReceptionSchedule { get; set; }
}
