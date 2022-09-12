using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPiTest.Auth;
using MinimalAPiTest.Context;
using MinimalAPiTest.Models;
using System.Data;
using System.Threading;

namespace MinimalAPiTest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TareaApiController : ControllerBase
    {
        private readonly TareasContext _context;
        public TareaApiController(TareasContext context)
        {
            _context = context;
        }
        public async Task<List<Tarea>> Get()
            => await _context.Tareas.Include(x => x.Categoria).ToListAsync();
        [HttpPost]
        public async Task<IActionResult> Add(TareaViewModel Tarea)
        {
            try
            {
                var TareaNueva = new Tarea(Tarea);
                TareaNueva.FechaCreacion = DateTime.Now;
                _context.Tareas.Add(TareaNueva);
                await _context.SaveChangesAsync();
                return Ok(new Response { Status = "Success", Message = "Se agrego la nueva tarea con exito!." });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Ocurrio un error, vuelva a intentarlo." });
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] TareaViewModel Tarea)
        {
            var TareaActual = _context.Tareas.Find(Tarea.TareaID);
            if (TareaActual != null)
                try
                {
                    TareaActual.CategoriaID = Tarea.CategoriaID;
                    TareaActual.Titulo = Tarea.Titulo;
                    TareaActual.EstadoTarea = Tarea.EstadoTarea;
                    TareaActual.PrioridadTarea = Tarea.PrioridadTarea;
                    TareaActual.Descripcion = Tarea.Descripcion;

                    await _context.SaveChangesAsync();
                    return Ok(new Response { Status = "Success", Message = "Tarea editada con exito." });
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Ocurrio un error, vuelva a intentarlo." });
                }
            return NotFound("El id ingresado no exite!");
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Buscamos e instanciamos el objeto de su ir
            var TareaEliminar = await _context.Tareas.FindAsync(id);
            //Definimos la logica de eliminacion
            try
            {
                if (TareaEliminar != null)
                {
                    _context.Tareas.Remove(TareaEliminar);
                    await _context.SaveChangesAsync();
                    return Ok(new Response { Status = "Success", Message = "Tarea eliminada con exito." });
                }
                return NotFound("El id ingresado no exite!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Ocurrio un error, vuelva a intentarlo." });
            }
        }
    }
}
