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
    public class CarroController : Controller
    {
        private readonly DBContext _context;

        public CarroController(DBContext context)
        {
            _context = context;
        }

        // GET: Carro
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.Carros.Include(c => c.Marca).Include(c => c.Modelo);
            return View(await dBContext.ToListAsync());
        }

        // GET: Carro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carros == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros
                .Include(c => c.Marca)
                .Include(c => c.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Carro/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nome");
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Nome");
            return View();
        }

        // POST: Carro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,MarcaId,ModeloId")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nome", carro.MarcaId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Nome", carro.ModeloId);
            return View(carro);
        }

        // GET: Carro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carros == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nome", carro.MarcaId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Nome", carro.ModeloId);
            return View(carro);
        }

        // POST: Carro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,MarcaId,ModeloId")] Carro carro)
        {
            if (id != carro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.Id))
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
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nome", carro.MarcaId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Nome", carro.ModeloId);
            return View(carro);
        }

        // GET: Carro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carros == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros
                .Include(c => c.Marca)
                .Include(c => c.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carros == null)
            {
                return Problem("Entity set 'DBContext.Carros'  is null.");
            }
            var carro = await _context.Carros.FindAsync(id);
            if (carro != null)
            {
                _context.Carros.Remove(carro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
          return (_context.Carros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
