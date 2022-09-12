using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinimalAPiTest.Context;
using MinimalAPiTest.Models;

namespace MinimalAPiTest.Pages.Tareas
{
    public class editModel : PageModel
    {
        //Traigo una instancia del context para vincular
        private readonly TareasContext _context;
        //Defino el constructor de la clase
        public editModel(TareasContext context) { _context = context; }
        [BindProperty]
        public TareaViewModel TareaEditable { set; get; }
        public async Task OnGet(int id)
        {
            TareaEditable = new TareaViewModel( await _context.Tareas.FindAsync(id));         
        }
        public async Task<IActionResult> OnPost() 
        {
            if (ModelState.IsValid) 
            {
                //Variable a editar
                var TareaEditada = await _context.Tareas.FindAsync(TareaEditable.TareaID);

                TareaEditada.Titulo = TareaEditable.Titulo;
                TareaEditada.CategoriaID = TareaEditable.CategoriaID;
                TareaEditada.Descripcion = TareaEditable.Descripcion;
                TareaEditada.EstadoTarea = TareaEditable.EstadoTarea;

                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
