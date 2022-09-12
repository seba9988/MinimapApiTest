using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinimalAPiTest.Context;
using MinimalAPiTest.Models;

namespace MinimalAPiTest.Pages.Categorias
{
    public class editModel : PageModel
    {
        private readonly TareasContext _context;
        [BindProperty]
        public CategoriaViewModel CategoriaEditable { set; get; }
        public editModel(TareasContext context)
        {
            _context = context;
        }
        public async Task OnGet( int id)
        {
            CategoriaEditable = new CategoriaViewModel(await _context.Categorias.FindAsync(id));
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //Variable a editar
                var CategoriaEditada = await _context.Categorias.FindAsync(CategoriaEditable.CategoriaID);

                CategoriaEditada.CategoriaID = CategoriaEditable.CategoriaID;
                CategoriaEditada.Nombre = CategoriaEditable.Nombre;
                CategoriaEditada.Descripcion = CategoriaEditable.Descripcion;

                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
