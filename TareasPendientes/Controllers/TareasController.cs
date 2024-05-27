﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasPendientes.Data;
using TareasPendientes.Models;

[Route("api/[controller]")]
[ApiController]
public class TareasController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TareasController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
    {
        return await _context.Tareas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tarea>> GetTarea(int id)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea == null) return NotFound();
        return tarea;
    }

    [HttpPost]
    public async Task<ActionResult<Tarea>> PostTarea(Tarea tarea)
    {
        _context.Tareas.Add(tarea);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetTarea", new { id = tarea.ID }, tarea);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTarea(int id, Tarea tarea)
    {
        if (id != tarea.ID) return BadRequest();
        _context.Entry(tarea).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Tareas.Any(e => e.ID == id)) return NotFound();
            else throw;
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTarea(int id)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea == null) return NotFound();
        _context.Tareas.Remove(tarea);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
