namespace APBD_cw12_git_s33338.DTOs;

public class RoomDto
{
    public string Id { get; set; }=string.Empty;
    public bool HasTv { get; set; }
    public WardDto Ward { get; set; } = new WardDto();
}