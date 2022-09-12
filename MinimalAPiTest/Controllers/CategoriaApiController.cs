using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPiTest.Auth;
using MinimalAPiTest.Context;
using MinimalAPiTest.Models;
using System.Threading;

namespace MinimalAPiTest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaApiController : ControllerBase
    {
        private readonly TareasContext _context;
        public CategoriaApiController(TareasContext context)
        {
            _context = context;
        }
        public async Task<List<Categoria>> Get()
           => await _context.Categorias.ToListAsync();
        [HttpPost]
        public async Task<IActionResult> Add(CategoriaViewModel categoria) 
        {
            try 
            {
                var categoriaNueva = new Categoria(categoria);
                _context.Categorias.Add(categoriaNueva);
                await _context.SaveChangesAsync();
                return Ok(new Response { Status = "Success", Message = "Se agrego la nueva categoria con exito!." });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Ocurrio un error, vuelva a intentarlo." });
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]CategoriaViewModel categoria)
        {
            var categoriaActual = _context.Categorias.Find(categoria.CategoriaID);
            if(categoriaActual != null)
            try
            {
                categoriaActual.Nombre = categoria.Nombre;
                categoriaActual.Descripcion = categoria.Descripcion;

                await _context.SaveChangesAsync();
                return Ok(new Response { Status = "Success", Message = "Categoria editada con exito." });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Ocurrio un error, vuelva a intentarlo."});
            }
            return NotFound("El id ingresado no exite!");
        }

        [Authorize (Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]  
        public async Task<IActionResult> Delete(int id)
        {
            //Buscamos e instanciamos el objeto de su ir
            var categoriaEliminar = await _context.Categorias.FindAsync(id);
            //Definimos la logica de eliminacion
            try
            {
                if (categoriaEliminar != null)
                {
                    _context.Categorias.Remove(categoriaEliminar);
                    await _context.SaveChangesAsync();
                    return Ok(new Response { Status = "Success", Message = "Categoria eliminada con exito." });
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
