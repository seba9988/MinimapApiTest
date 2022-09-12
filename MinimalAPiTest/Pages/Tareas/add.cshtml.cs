using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinimalAPiTest.Context;
using MinimalAPiTest.Models;

namespace MinimalAPiTest.Pages.Tareas
{
    public class addModel : PageModel
    {
        //Traigo una instancia del context para vincular
        private readonly TareasContext _context;
        //Defino el constructor de la clase
        public addModel(TareasContext context) 
        {
            _context = context; 
        }
        //Traemos el modelo y le hacemos binding
        [BindProperty]
        public TareaViewModel TareaGuardable { set; get; }
        public void OnGet()
        {
        }
        //Metodo asincrono para guardar la informacion
        public async Task<IActionResult> OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Instancio el objeto Tarea
            Tarea tarea = new Tarea(TareaGuardable);
            //Seteo la fecha actual
            tarea.FechaCreacion = DateTime.Now;
            //Agrego el objeto tarea
            _context.Add(tarea);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
