using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MinimalAPiTest.Models
{
    public class Categoria
    {
        //Propiedades
        //[Key] // indico que la proxima propiedad va a se clave primariad
        public int CategoriaID { get; set; }
        //[Required]
        //[MaxLength(150)]
        public string? Nombre { get; set; }
        public string?  Descripcion { get; set; }
        [JsonIgnore]
        public ICollection<Tarea> Tareas { get; set; }
        //Constructores
        public Categoria() { }
        public Categoria(CategoriaViewModel categoriaVm) 
        {
            CategoriaID = categoriaVm.CategoriaID;
            Nombre = categoriaVm.Nombre;
            Descripcion = categoriaVm.Descripcion;
        }
    }
}
