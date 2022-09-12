using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinimalAPiTest.Context;
using MinimalAPiTest.Models;

namespace MinimalAPiTest.Pages.Categorias
{
    public class addModel : PageModel
    {
        private readonly TareasContext _context;
        [BindProperty]
        public CategoriaViewModel CategoriaGuardable { set; get; } 
        public addModel(TareasContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Instancio el objeto Tarea
            Categoria categoria = new Categoria(CategoriaGuardable);
            //Agrego el objeto tarea
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
