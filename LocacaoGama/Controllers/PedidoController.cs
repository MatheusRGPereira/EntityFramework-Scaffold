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
    public class PedidoController : Controller
    {
        private readonly DBContext _context;

        public PedidoController(DBContext context)
        {
            _context = context;
        }

        // GET: Pedido
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.Pedidos.Include(p => p.Carro).Include(p => p.Cliente);
            return View(await dBContext.ToListAsync());
        }

        // GET: Pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Carro)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedido/Create
        public IActionResult Create()
        {
            ViewData["CarroId"] = new SelectList(_context.Carros, "Id", "Id");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,CarroId,DataLocacao,DataEntrega")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                var config = _context.Configuracao.FirstOrDefault();
                var dias = config is not null ? config.diasDeLocacao : 1;
                pedido.DataEntrega = pedido.DataLocacao.AddDays(dias);

                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroId"] = new SelectList(_context.Carros, "Id", "Id", pedido.CarroId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", pedido.ClienteId);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["CarroId"] = new SelectList(_context.Carros, "Id", "Id", pedido.CarroId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", pedido.ClienteId);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,CarroId,DataLocacao,DataEntrega")] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
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
            ViewData["CarroId"] = new SelectList(_context.Carros, "Id", "Id", pedido.CarroId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", pedido.ClienteId);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Carro)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedidos == null)
            {
                return Problem("Entity set 'DBContext.Pedidos'  is null.");
            }
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
          return (_context.Pedidos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
