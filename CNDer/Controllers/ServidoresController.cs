using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CNDer.Data;
using CNDer.Models;
using System.Text.RegularExpressions;
using CNDer.Helpers;

namespace CNDer.Controllers
{
    public class ServidoresController : Controller
    {
        private readonly Contexto _context;

        public ServidoresController(Contexto context)
        {
            _context = context;
        }

        // GET: Servidores
        public async Task<IActionResult> Index(string searchString)
        {
            var servidores = from s in _context.Servidores
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                servidores = servidores.Where(s => s.Cpf.Contains(searchString) || s.Matricula.Contains(searchString) || s.Nome.Contains(searchString));
            }
            return View(await servidores.ToListAsync());
        }
        public async Task<IActionResult> Busca(string searchString = null)
        {
            //    var servidores = from s in _context.Servidores
            //          select s;
            //     if (!String.IsNullOrEmpty(searchString))
            //     {
            //         servidores = servidores.Where(s => s.Cpf == searchString || s.Matricula == searchString || s.Nome == searchString);
            //     }FF
            if(searchString == null){
                ViewBag.primeiraVez = true;
            } 

            var servidor = _context.Servidores.Include(s => s.Objetos)
            .ThenInclude(o => o.Tipo)
            .Where(s => s.Cpf == searchString || s.Matricula == searchString || s.Nome == searchString);

             if(searchString != null && servidor.Count() == 0 ){
                 ViewBag.primeiraVez = false;
            }else{
                ViewBag.primeiraVez = true;
            }
            
            return View(await servidor.FirstOrDefaultAsync());
        }


        // GET: Servidores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidores
                .Include(o => o.Objetos)
                .FirstOrDefaultAsync(m => m.Id == id);
            var objetos = _context.Objetos
                .Include(t => t.Tipo)
                .OrderBy(o => o.StatusAtivo)
                .FirstOrDefault(o => o.ServidorId == id);

            if (servidor == null)
            {
                return NotFound();
            }

            AtualizarStatus(Convert.ToInt32(id));

            return View(servidor);
        }
        public async Task<IActionResult> GerarCertidao(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidores
                .Include(o => o.Objetos)
                .FirstOrDefaultAsync(m => m.Id == id);
            var objetos = _context.Objetos.FirstOrDefault(o => o.ServidorId == id);

            if (servidor == null)
            {
                return NotFound();
            }

            AtualizarStatus(Convert.ToInt32(id));

            return View(servidor);
        }
        public async Task<IActionResult> Selecionar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servidor == null)
            {
                return NotFound();
            }

            return RedirectToAction("Create", "Objetos", new { ServidorId = servidor.Id });
        }

        // GET: Servidores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servidores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Matricula")] Servidor servidor)
        {
            servidor.Cpf = Helpers.FormatadorHelper.RemoveCaracteresCPF(servidor.Cpf);
            if (ModelState.IsValid)
            {
                var exist = _context.Servidores.Where(s => s.Cpf == servidor.Cpf || s.Matricula == servidor.Matricula).Any();
                if (!exist)
                {
                    _context.Add(servidor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Create", "Objetos", new { ServidorId = servidor.Id });
                }
                return View(servidor);
            }
            return View(servidor);
        }

        // GET: Servidores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidores.FindAsync(id);
            if (servidor == null)
            {
                return NotFound();
            }
            return View(servidor);
        }

        // POST: Servidores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Matricula")] Servidor servidor)
        {
            if (id != servidor.Id)
            {
                return NotFound();
            }
            servidor.Cpf = Helpers.FormatadorHelper.RemoveCaracteresCPF(servidor.Cpf);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServidorExists(servidor.Id))
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
            return View(servidor);
        }

        // GET: Servidores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servidor == null)
            {
                return NotFound();
            }

            return View(servidor);
        }

        // POST: Servidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servidor = await _context.Servidores.FindAsync(id);
            _context.Servidores.Remove(servidor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServidorExists(int id)
        {
            return _context.Servidores.Any(e => e.Id == id);
        }

        public void AtualizarStatus(int id)
        {
            var Objetos = _context.Objetos.Where(o => o.ServidorId == id);

            foreach (var item in Objetos)
            {
                Objeto objeto = new Objeto();
                objeto = item;
                if (objeto.DataFim < DateTime.Now)
                {
                    objeto.StatusAtivo = false;
                }
                else
                {
                    objeto.StatusAtivo = true;
                }
                _context.Update(objeto);
            }

            _context.SaveChanges();

        }

        public static string RemoveCaracteresCPF(string text)
        {
            if (text == null)
            {
                return "";
            }
            return text.Replace(".", "").Replace("-", "").Replace("/", "");
        }

    }
}



    

