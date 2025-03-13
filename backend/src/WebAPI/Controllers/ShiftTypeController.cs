using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;




[Route("api/[controller]")]
[ApiController]
[Authorize] // Can only be accessed by authenticated users
public class ShiftTypeController : ControllerBase
{
    private readonly IShiftTypeService _shiftTypeService;

    public ShiftTypeController(IShiftTypeService shiftTypeService)
    {
        _shiftTypeService = shiftTypeService;
    }

    // CRUD operation endpoints

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShiftTypeDto>>> GetAll()
    {
        var ShiftTypes = await _shiftTypeService.GetAllShiftTypesAsync();
        return Ok(ShiftTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShiftTypeDto>> GetById(int id)
    {
        var ShiftType = await _shiftTypeService.GetShiftTypeByIdAsync(id);
        if (ShiftType == null)
            return NotFound();
        
        return Ok(ShiftType);
    }

    [HttpPost]
    public async Task<ActionResult<ShiftTypeDto>> Create(CreateShiftTypeDto createDto)
    {
        var createdShiftType = await _shiftTypeService.CreateShiftTypeAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = createdShiftType.Id }, createdShiftType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateShiftTypeDto updateDto)
    {
        try
        {
            await _shiftTypeService.UpdateShiftTypeAsync(id, updateDto);
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
            await _shiftTypeService.DeleteShiftTypeAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}