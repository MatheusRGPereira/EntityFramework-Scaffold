using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocacaoGama.Context;
using LocacaoGama.Models;

namespace LocacaoGama.Controllers
{
    public class ConfiguracaoController : Controller
    {
        private readonly DBContext _context;

        public ConfiguracaoController(DBContext context)
        {
            _context = context;
        }

        // GET: Configuracao
        public async Task<IActionResult> Index()
        {
              return _context.Configuracao != null ? 
                          View(await _context.Configuracao.ToListAsync()) :
                          Problem("Entity set 'DBContext.Configuracao'  is null.");
        }

        // GET: Configuracao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Configuracao == null)
            {
                return NotFound();
            }

            var configuracao = await _context.Configuracao
                .FirstOrDefaultAsync(m => m.id == id);
            if (configuracao == null)
            {
                return NotFound();
            }

            return View(configuracao);
        }

        // GET: Configuracao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Configuracao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,diasDeLocacao")] Configuracao configuracao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configuracao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(configuracao);
        }

        // GET: Configuracao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Configuracao == null)
            {
                return NotFound();
            }

            var configuracao = await _context.Configuracao.FindAsync(id);
            if (configuracao == null)
            {
                return NotFound();
            }
            return View(configuracao);
        }

        // POST: Configuracao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,diasDeLocacao")] Configuracao configuracao)
        {
            if (id != configuracao.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiguracaoExists(configuracao.id))
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
            return View(configuracao);
        }

        // GET: Configuracao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Configuracao == null)
            {
                return NotFound();
            }

            var configuracao = await _context.Configuracao
                .FirstOrDefaultAsync(m => m.id == id);
            if (configuracao == null)
            {
                return NotFound();
            }

            return View(configuracao);
        }

        // POST: Configuracao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Configuracao == null)
            {
                return Problem("Entity set 'DBContext.Configuracao'  is null.");
            }
            var configuracao = await _context.Configuracao.FindAsync(id);
            if (configuracao != null)
            {
                _context.Configuracao.Remove(configuracao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfiguracaoExists(int id)
        {
          return (_context.Configuracao?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
