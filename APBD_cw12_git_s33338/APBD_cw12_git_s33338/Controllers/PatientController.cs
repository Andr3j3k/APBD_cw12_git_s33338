using APBD_cw12_git_s33338.DTOs;
using APBD_cw12_git_s33338.Exceptions;
using APBD_cw12_git_s33338.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_cw12_git_s33338.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IDbService _dbService;
    public PatientController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPatients(string? search)
    {
        try
        {
            var res = await _dbService.GetAllPatients(search);
            
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("{pesel}/bedassignments")]
    public async Task<IActionResult> AddBedAssignment(string pesel, CreateBedAssignmentDto dto)
    {
        try
        {
            await _dbService.AddBedAssignment(pesel, dto);
            return Created();
        }
        catch (NotFoundException e)
        {
            return NotFound(new
            {
                message = e.Message
            });
        }
    }
}