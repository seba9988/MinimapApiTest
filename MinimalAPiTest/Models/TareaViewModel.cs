using System.ComponentModel.DataAnnotations;

namespace MinimalAPiTest.Models
{
	public class TareaViewModel
    {
        //Propiedades
        public int TareaID { get; set; }
        [Required(ErrorMessage = "Se requiere un Titulo")]
        public string? Titulo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        [Required(ErrorMessage = "Se requiere una Descripcion")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Se requiere una Categoria")]
        public int CategoriaID { get; set; }
        [Required(ErrorMessage = "Se requiere un Estado")]
        public Estado EstadoTarea { get; set; }
        public Prioridad PrioridadTarea { get; set; }

        //Constructores
        public TareaViewModel() { }
        public TareaViewModel(Tarea tarea)
        {
            TareaID = tarea.TareaID;
            Titulo = tarea.Titulo;
            CategoriaID = tarea.CategoriaID;
            FechaCreacion = tarea.FechaCreacion;
            Descripcion = tarea.Descripcion;
            EstadoTarea = tarea.EstadoTarea;
        }
    }
}
