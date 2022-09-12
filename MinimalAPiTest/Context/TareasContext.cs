using Microsoft.EntityFrameworkCore;
using MinimalAPiTest.Auth;
using MinimalAPiTest.Models;

namespace MinimalAPiTest.Context
{
    public class TareasContext: ValidateIdentityContext
    {
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Tarea>? Tareas { get; set; }
        //public DbSet<Categoria> Categorias => Set<Categoria>();
        //public DbSet<Tarea> Tareas => Set<Tarea>();

        //constructor de contexto
        public TareasContext(DbContextOptions<TareasContext> options): base(options) 
        {

        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            //aca definimos todos los metodos que alteran nuestas tablas
            List<Categoria> categoriaInit = new List<Categoria>();

            categoriaInit.Add(new Categoria()
            { 
                CategoriaID=100,
                Nombre="Personal",
                Descripcion="algo"
            });
            categoriaInit.Add(new Categoria()
            {
                CategoriaID = 110,
                Nombre = "Trabajo",
                Descripcion = "algo mas"
            });
            categoriaInit.Add(new Categoria()
            {
                CategoriaID = 200,
                Nombre = "Facultad",
                Descripcion = "estudio"
            });
            //Creamos la tabla categoria
            modelBuilder.Entity<Categoria>(categoria =>
            {
                //Definimos que categoria sera una tabla
                categoria.ToTable("Categoria");

                //Definimos las relaciones
                categoria.HasKey(p => p.CategoriaID);
                //Definimos las propiedades de las tablas
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).IsRequired().HasMaxLength(300);
                //se le agregan valores iniciales a la tabla
                categoria.HasData(categoriaInit);
            });
            List<Tarea> tareasInit = new List<Tarea>();

            tareasInit.Add(new Tarea() 
            {
                TareaID= 1151,
                CategoriaID = 100,
                PrioridadTarea = Prioridad.Media,
                Titulo = "Pago de servidios publico",
                FechaCreacion = DateTime.Now,
            });
            tareasInit.Add(new Tarea()
            {
                TareaID = 2252,
                CategoriaID = 200,
                PrioridadTarea = Prioridad.Alta,
                Titulo = "Estudiar para parcial",
                FechaCreacion = DateTime.Now,
            });
            modelBuilder.Entity<Tarea>(tarea =>
            {
                //Definimos el modelo
                tarea.ToTable("Tarea");

                //Definimos la relacion con categoria y la pk
                tarea.HasKey(p => p.TareaID);
                //Relacion 1..N con Categorias 
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaID);

                //Definimos las propiedades
                tarea.Property(p => p.Titulo).HasMaxLength(100);
                tarea.Property(p => p.Descripcion);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                tarea.Property(p => p.Procastinable);
                tarea.Property(p => p.EstadoTarea);
                //Se le agregan valores iniciales a la tabla
                tarea.HasData(tareasInit);

                //Ignoramos las propiedades que no peremos que persistan
                tarea.Ignore(p => p.Resumen);
            });
        }
    }
}
