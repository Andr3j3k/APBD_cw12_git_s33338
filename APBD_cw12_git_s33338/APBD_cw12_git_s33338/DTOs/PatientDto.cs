namespace APBD_cw12_git_s33338.DTOs;

public class PatientDto
{
    public string Pesel { get; set; }=String.Empty;
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public int Age { get; set; }
    public string Sex {get; set; } = String.Empty;
    public List<AdmissionsDto> Admissions { get; set; } = [];
    public List<BedAssignmentDto> BedAssignment { get; set; } = [];
}