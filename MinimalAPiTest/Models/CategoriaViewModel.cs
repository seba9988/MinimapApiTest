using System.ComponentModel.DataAnnotations;

namespace MinimalAPiTest.Models
{
	public class CategoriaViewModel
	{
        public int CategoriaID { get; set; }
        [Required(ErrorMessage = "Se requiere un Nombre")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Se requiere una Descripcion")]
        public string? Descripcion { get; set; }

        public CategoriaViewModel() { }
        public CategoriaViewModel(Categoria categoria)
        {
            CategoriaID = categoria.CategoriaID;  
            Nombre = categoria.Nombre;
            Descripcion = categoria.Descripcion;
        }
    }
}
