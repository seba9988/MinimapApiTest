using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MinimalAPiTest.Auth;
using MinimalAPiTest.Context;
using MinimalAPiTest.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDb"));
//Conexion a SQLSERVER
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

builder.Services.AddDbContext<TareasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnTareas")));

/*builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ValidateIdentityContext>();*/
// agrego Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.Password.RequiredLength = 6;
    x.Password.RequireNonAlphanumeric = false;
}).
    AddEntityFrameworkStores<TareasContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();
//Autenticacion
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

//Agregamos Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});
//Agregamos Razor Pages
builder.Services.AddRazorPages();

/*builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();*/

var app = builder.Build();
//MapEnds

//GET
//.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("BBDD En memoria!" + dbContext.Database.IsInMemory());
});
app.MapGet("/listar/tareas", ([FromServices] TareasContext dbContext) =>
{
    try 
    {
        return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
    }
    catch (Exception)
    {
        return Results.NotFound("eso no existe!");
    }
});
app.MapGet("/listar/categorias", ([FromServices] TareasContext dbContext) => 
{
    try
    {
        return Results.Ok(dbContext.Categorias);
    }
    catch (Exception)
    {
        return Results.NotFound("eso no existe!");
    }
});
//POST
app.MapPost("/guardar/tarea", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) => 
{
    try 
    {
        tarea.FechaCreacion = DateTime.Now;
        await dbContext.AddAsync(tarea);
        // await dbContext.Tareas.AddAsync(tarea); es otra forma de hacerlo
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    catch (Exception)
    {
        return Results.NotFound("eso no existe!");
    }
});
app.MapPost("/guardar/categoria", async ([FromServices] TareasContext dbContext, [FromBody] Categoria categoria) =>
{
    try
    {
        await dbContext.AddAsync(categoria);
        // await dbContext.Categorias.AddAsync(tarea); es otra forma de hacerlo
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    catch (Exception)
    {
        return Results.NotFound("eso no existe!");
    }
});
//PUT
app.MapPut("/actualizar/tarea/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] int id) => 
{
    var tareaActual = dbContext.Tareas.Find(id);

    try 
    {
        tareaActual.CategoriaID = tarea.CategoriaID;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();
        return Results.Ok("Tarea actualizada correctamente!");
    }
    catch (Exception)
    {
        return Results.NotFound("eso no existe!");
    }
});
app.MapPut("/actualizar/categoria/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Categoria categoria, [FromRoute] int id) =>
{
    var categoriaActual = dbContext.Categorias.Find(id);

    try
    {
        categoriaActual.Nombre = categoria.Nombre;
        categoriaActual.Descripcion = categoria.Descripcion;

        await dbContext.SaveChangesAsync();
        return Results.Ok("Tarea actualizada correctamente!");
    }
    catch (Exception)
    {
        return Results.NotFound("eso no existe!");
    }
});
//DELETE
app.MapDelete("/eliminar/tarea/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] int id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);
    try
    {
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok("Tarea eliminada corractamente!");
    }
    catch (Exception)
    {
        return Results.NotFound("eso no existe!");
    }
});
app.MapDelete("/eliminar/categoria/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] int id) =>
{
    var categoriaActual = dbContext.Categorias.Find(id);
    try
    {
        dbContext.Remove(categoriaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok("Tarea eliminada corractamente!");
    }
    catch (Exception)
    {
        return Results.NotFound("eso no existe!");
    }
});


app.UseHttpsRedirection();
//Autenticacion y autorizacion
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//Para los estilos
app.UseStaticFiles();

//Para mapear las paginas de Razor

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();  