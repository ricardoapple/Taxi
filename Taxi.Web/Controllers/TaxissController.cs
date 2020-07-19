using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Taxi.Web.Data;
using Taxi.Web.Models;

namespace Taxi.Web.Controllers
{
    public class TaxissController : Controller
    {
        private readonly DataContext _context;

        public TaxissController(DataContext context)
        {
            _context = context;
        }

        // GET: Taxiss
        public async Task<IActionResult> Index()
        {
            return View(await _context.Taxis.ToListAsync());
        }

        // GET: Taxiss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxis = await _context.Taxis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxis == null)
            {
                return NotFound();
            }

            return View(taxis);
        }

        // GET: Taxiss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taxiss/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Taxis taxis)
        {
                //Validamos el modelo, significa que cumpla con todas las DataAnnotations que le hayamos puesto.
                if (ModelState.IsValid)
                {
                    taxis.Plaque = taxis.Plaque.ToUpper();//Antes de guardar convertimos la placa a mayúscula.
                    _context.Add(taxis);//Añade al modelo las propiedades, EF es tan inteligente que no es necesario _context.Taxis.Add(taxis), el lo asume que vamos a guardar en Taxis   
                }

                try
                {
                    await _context.SaveChangesAsync();//Guarda los cambios en la base de datos
                    return RedirectToAction(nameof(Index));//Me redirecciona a la vista
                }
                catch (Exception ex)
                {
                    if(ex.InnerException.Message.Contains("duplicada"))
                    {
                        ModelState.AddModelError(string.Empty,"La placa ya esta registrada");
                    }
                    else
                    {
                       ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }    
                }

            return View(taxis);
        }

        // GET: Taxiss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxis = await _context.Taxis.FindAsync(id);
            if (taxis == null)
            {
                return NotFound();
            }
            return View(taxis);
        }

        // POST: Taxiss/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Taxis taxis)
        {
            if (id != taxis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                taxis.Plaque = taxis.Plaque.ToUpper();//Antes de guardar convertimos la placa a mayúscula.
                _context.Update(taxis);
                try
                {
                    await _context.SaveChangesAsync();//Guarda los cambios en la base de datos
                    return RedirectToAction(nameof(Index));//Me redirecciona a la vista
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicada"))
                    {
                        ModelState.AddModelError(string.Empty, "La placa ya esta registrada");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(taxis);
        }

        // GET: Taxiss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxis = await _context.Taxis.FindAsync(id);
            if (taxis == null)
            {
                return NotFound();
            }

            _context.Taxis.Remove(taxis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
    }
}
