using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CNDer.Data;
using CNDer.Models;

namespace CNDer.Controllers
{
    public class ObjetosController : Controller
    {
        private readonly Contexto _context;

        public ObjetosController(Contexto context)
        {
            _context = context;
        }

        // GET: Objetos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Objetos.Include(o => o.Servidor).Include(o => o.Tipo);
            return View(await contexto.ToListAsync());
        }

        // GET: Objetos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objeto = await _context.Objetos
                .Include(o => o.Servidor)
                .Include(o => o.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objeto == null)
            {
                return NotFound();
            }

            return View(objeto);
        }
        // GET: Objetos/Create
        public IActionResult Create(int? ServidorId)
        {
            Objeto objeto = new Objeto();
            objeto.ServidorId = Convert.ToInt32(ServidorId);
            ViewBag.ServidorNome = _context.Servidores.Find(ServidorId).Nome;
            ViewData["ServidorId"] = new SelectList(_context.Servidores, "Id", "Nome");
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Nome");
            return View(objeto);
        }

        // POST: Objetos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Objeto objeto)
        {

            if (ModelState.IsValid)
            {
                UpdateStatus(objeto);
                _context.Add(objeto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Servidores");
            }
            ViewData["ServidorId"] = new SelectList(_context.Servidores, "Id", "Nome", objeto.ServidorId);
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Nome", objeto.TipoId);
            return View(objeto);
        }

        // GET: Objetos/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var objeto = await _context.Objetos.FindAsync(Id);
            ViewBag.ServidorNome = _context.Servidores.Find(objeto.ServidorId).Nome;
            if (objeto == null)
            {
                return NotFound();
            }
            ViewData["ServidorId"] = new SelectList(_context.Servidores, "Id", "Nome", objeto.ServidorId);
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Nome", objeto.TipoId);
            return View(objeto);
        }

        // POST: Objetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Objeto objeto)
        {
            if (id != objeto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjetoExists(objeto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServidorId"] = new SelectList(_context.Servidores, "Id", "Nome", objeto.ServidorId);
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Nome", objeto.TipoId);
            return View(objeto);
        }

        // GET: Objetos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objeto = await _context.Objetos
                .Include(o => o.Servidor)
                .Include(o => o.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objeto == null)
            {
                return NotFound();
            }

            return View(objeto);
        }

        // POST: Objetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objeto = await _context.Objetos.FindAsync(id);
            _context.Objetos.Remove(objeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjetoExists(int id)
        {
            return _context.Objetos.Any(e => e.Id == id);
        }

        public void UpdateStatus(Objeto objeto)
        {
            if (objeto.DataFim < DateTime.Now)
            {
                objeto.StatusAtivo = false;
            }
            else
            {
                objeto.StatusAtivo = true;
            }

        }




    }
}
