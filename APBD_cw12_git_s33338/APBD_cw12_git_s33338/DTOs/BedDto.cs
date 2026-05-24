namespace APBD_cw12_git_s33338.DTOs;

public class BedDto
{
    public int Id { get; set; }
    public BedTypeDto BedType { get; set; } = new BedTypeDto();
    public RoomDto Room { get; set; } = new RoomDto();
}