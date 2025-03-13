using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;




[Route("api/[controller]")]
[ApiController]
[Authorize] // Can only be accessed by authenticated users
public class DoctorTypeController : ControllerBase
{
    private readonly IDoctorTypeService _doctorTypeService;

    public DoctorTypeController(IDoctorTypeService doctorTypeService)
    {
        _doctorTypeService = doctorTypeService;
    }

    // CRUD operation endpoints

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorTypeDto>>> GetAll()
    {
        var doctorTypes = await _doctorTypeService.GetAllDoctorTypesAsync();
        return Ok(doctorTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorTypeDto>> GetById(int id)
    {
        var doctorType = await _doctorTypeService.GetDoctorTypeByIdAsync(id);
        if (doctorType == null)
            return NotFound();
        
        return Ok(doctorType);
    }

    [HttpPost]
    public async Task<ActionResult<DoctorTypeDto>> Create(CreateDoctorTypeDto createDto)
    {
        var createdDoctorType = await _doctorTypeService.CreateDoctorTypeAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = createdDoctorType.Id }, createdDoctorType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateDoctorTypeDto updateDto)
    {
        try
        {
            await _doctorTypeService.UpdateDoctorTypeAsync(id, updateDto);
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
            await _doctorTypeService.DeleteDoctorTypeAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}