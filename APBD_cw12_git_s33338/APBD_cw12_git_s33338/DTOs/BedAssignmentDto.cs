namespace APBD_cw12_git_s33338.DTOs;

public class BedAssignmentDto
{
    public int Id { get; set; }
    public DateTime From { get; set; }
    public DateTime? To { get; set; }
    public BedDto Bed { get; set; } = new BedDto();
}