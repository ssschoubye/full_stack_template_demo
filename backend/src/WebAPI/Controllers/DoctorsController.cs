using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;




[Route("api/[controller]")]
[ApiController]
[Authorize] // Can only be accessed by authenticated users
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    // CRUD operation endpoints

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAll()
    {
        var Doctors = await _doctorService.GetAllDoctorsAsync();
        return Ok(Doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDto>> GetById(int id)
    {
        var Doctor = await _doctorService.GetDoctorByIdAsync(id);
        if (Doctor == null)
            return NotFound();
        
        return Ok(Doctor);
    }

    [HttpPost]
    public async Task<ActionResult<DoctorDto>> Create(CreateDoctorDto createDto)
    {
        var createdDoctor = await _doctorService.CreateDoctorAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = createdDoctor.Id }, createdDoctor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateDoctorDto updateDto)
    {
        try
        {
            await _doctorService.UpdateDoctorAsync(id, updateDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _doctorService.DeleteDoctorAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}