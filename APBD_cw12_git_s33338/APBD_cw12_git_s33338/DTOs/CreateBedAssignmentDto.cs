namespace APBD_cw12_git_s33338.DTOs;

public class CreateBedAssignmentDto
{
    public DateTime From { get; set; }
    public DateTime? To { get; set; }
    public string BedType { get; set; }=String.Empty;
    public string Ward { get; set; }=String.Empty;
}