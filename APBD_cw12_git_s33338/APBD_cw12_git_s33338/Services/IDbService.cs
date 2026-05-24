namespace APBD_cw12_git_s33338.Services;
using APBD_cw12_git_s33338.DTOs;

public interface IDbService
{
    Task<List<PatientDto>> GetAllPatients(string? search);
}