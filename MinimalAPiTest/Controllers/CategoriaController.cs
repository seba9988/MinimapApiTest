using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPiTest.Auth;
using MinimalAPiTest.Context;
using MinimalAPiTest.Models;
using System.Diagnostics;

namespace MinimalAPiTest.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private readonly TareasContext _context;
        public CategoriaController(TareasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()        
         => View(await _context.Categorias.ToListAsync());
        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(CategoriaViewModel categoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoriaNueva = new Categoria(categoria);
                    _context.Categorias.Add(categoriaNueva);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Ocurrio un error, vuelva a intentarlo." });
                }
            }
            return View(categoria);
        }
        public IActionResult Edit(int id)
        {
            var categoria = _context.Categorias.Find(id);
            var bebidaView = new CategoriaViewModel(categoria);
            return View(bebidaView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoriaViewModel categoria)
        {
            if (ModelState.IsValid)
                try
                {
                    Categoria categoriaEditada = new Categoria(categoria);
                    _context.Categorias.Update(categoriaEditada);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Ocurrio un error, vuelva a intentarlo." });
                }
            return View(categoria);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            //Buscamos e instanciamos el objeto de su id
            var categoriaEliminar = await _context.Categorias.FindAsync(id);
            //Definimos la logica de eliminacion
            try
            {
                if (categoriaEliminar != null)
                {
                    _context.Categorias.Remove(categoriaEliminar);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return NotFound("El id ingresado no exite!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Ocurrio un error, vuelva a intentarlo." });
            }
        }
    }
}

