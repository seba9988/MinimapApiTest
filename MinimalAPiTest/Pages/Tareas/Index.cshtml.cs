using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MinimalAPiTest.Context;
using MinimalAPiTest.Models;

namespace MinimalAPiTest.Pages.Tareas
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TareasContext _context;
        public IndexModel(TareasContext context)
        {
            _context = context;
        }
        //Defino una coleccion enumerable a pasar
        public IEnumerable<TareaViewModel> TareasListadas { get; set; }
        //Metodo asincrono para llamar a la conexion
        public async Task OnGet()
        {
            TareasListadas = await _context.Tareas.Select(x => new TareaViewModel(x)).ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
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
                    return RedirectToPage("Index");
                }
                else throw new Exception();
            }
            catch(Exception)
            {
                return NotFound("Esta tarea no existe!");
            }
        }
    }
}
