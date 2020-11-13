using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CNDer.Data;
using CNDer.Models;
using CNDer.Services;
using CNDer.Models.ViewModels;

namespace CNDer.Controllers
{
    public class TiposController : Controller
    {
        private readonly Contexto _context;

        public TiposController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriarObjetoVM objeto)
        {

            if (ModelState.IsValid)
            {
                _context.Add(objeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objeto);
        }


    }
}