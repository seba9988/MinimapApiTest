using MinimalAPiTest.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPiTest.Models
{
    public class Tarea
    {
        //[Key]
        public int TareaID { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? Descripcion { get; set; }
        //[ForeignKey("CategoriaID")]
        public int CategoriaID { get; set; }
        public Categoria? Categoria { get; set; }
        public Prioridad PrioridadTarea { get; set; }
        public Estado EstadoTarea { get; set; }
        public bool Procastinable { get; set; }
        public bool Estado { get; set; }     
        [NotMapped]
        public string? Resumen { get; set; }
        //Constructores
        public Tarea() { }
        public Tarea(TareaViewModel tareaVM) 
        {
            Titulo = tareaVM.Titulo;
            Descripcion = tareaVM.Descripcion;
            CategoriaID = tareaVM.CategoriaID;
            EstadoTarea = tareaVM.EstadoTarea;
        }
    }
    public enum Prioridad 
    {
        Alta,
        Media,
        Baja
    }
    public enum Estado
    {
        Completado,
        Pendiente,
        Transicion
    }

}