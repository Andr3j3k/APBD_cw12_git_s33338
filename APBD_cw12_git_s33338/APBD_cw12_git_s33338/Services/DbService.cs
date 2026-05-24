using APBD_cw12_git_s33338.Data;
using APBD_cw12_git_s33338.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APBD_cw12_git_s33338.Services;

public class DbService : IDbService
{
    private readonly HospitalContext _context;
    
    public DbService(HospitalContext context)
    {
        _context = context;
    }

    public async Task<List<PatientDto>> GetAllPatients(string? search)
    {
        var query = _context.Patients.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query=query.Where(e=>
                EF.Functions.Like(e.FirstName,$"%{search}%") ||
                EF.Functions.Like(e.LastName,$"%{search}%"));
        }

        var res = await query
            .Select(e => new PatientDto
            {
                Pesel = e.Pesel,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Age = e.Age,
                Sex = e.Sex ? "Male" : "Female",

                Admissions = e.Admissions.Select(a => new AdmissionDto
                {
                    Id = a.Id,
                    AdmissionDate = a.AdmissionDate,
                    DischargeDate = a.DischargeDate,
                    Ward = new WardDto
                    {
                        Id = a.Ward.Id,
                        Name = a.Ward.Name,
                        Description = a.Ward.Description
                    }
                }).ToList(),

                BedAssignments = e.BedAssignments.Select(ba => new BedAssignmentDto
                {
                    Id = ba.Id,
                    From = ba.From,
                    To = ba.To,
                    
                    Bed = new BedDto
                    {
                        Id = ba.Bed.Id,
                        BedType = new BedTypeDto
                        {
                            Id = ba.Bed.BedType.Id,
                            Name = ba.Bed.BedType.Name,
                            Description = ba.Bed.BedType.Description
                        },

                        Room = new RoomDto
                        {
                            Id = ba.Bed.Room.Id,
                            HasTv = ba.Bed.Room.HasTv,

                            Ward = new WardDto
                            {
                                Id = ba.Bed.Room.Ward.Id,
                                Name = ba.Bed.Room.Ward.Name,
                                Description = ba.Bed.Room.Ward.Description
                            }
                        }
                    }
                }).ToList(),
            }).ToListAsync();
        return res;
    }
}