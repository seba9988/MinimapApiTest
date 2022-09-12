using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MinimalAPiTest.Context;
using MinimalAPiTest.Models;

namespace MinimalAPiTest.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly TareasContext _context;
        public IEnumerable<CategoriaViewModel>  CategoriasListadas{ get; set; }
        public IndexModel(TareasContext context) 
        {
            _context = context;
        }
        public async Task OnGet()
        {
            CategoriasListadas = await _context.Categorias.Select(x => new CategoriaViewModel(x)).ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
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
                    return RedirectToPage("Index");
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                return NotFound("Esta categoria no existe!");
            }
        }
    }
}
