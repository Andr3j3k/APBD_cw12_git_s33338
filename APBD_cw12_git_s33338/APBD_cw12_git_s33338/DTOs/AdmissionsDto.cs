namespace APBD_cw12_git_s33338.DTOs;

public class AdmissionsDto
{
    public int  Id { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime? DischargeDate { get; set; }
    public WardDto Ward { get; set; } = new WardDto();
}