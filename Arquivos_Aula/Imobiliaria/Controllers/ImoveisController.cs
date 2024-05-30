using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Imobiliaria.Models;

namespace Imobiliaria.Controllers
{
    public class ImoveisController : Controller
    {
        private readonly ImobiliariaContext _context;

        public ImoveisController(ImobiliariaContext context)
        {
            _context = context;
        }

        // GET: Imoveis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Imoveis.ToListAsync());
        }

        // GET: Imoveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imoveis = await _context.Imoveis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imoveis == null)
            {
                return NotFound();
            }

            return View(imoveis);
        }

        // GET: Imoveis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Imoveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Valor,Endereco,Bairro,Tipo")] Imoveis imoveis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imoveis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imoveis);
        }

        // GET: Imoveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imoveis = await _context.Imoveis.FindAsync(id);
            if (imoveis == null)
            {
                return NotFound();
            }
            return View(imoveis);
        }

        // POST: Imoveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Valor,Endereco,Bairro,Tipo")] Imoveis imoveis)
        {
            if (id != imoveis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imoveis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImoveisExists(imoveis.Id))
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
            return View(imoveis);
        }

        // GET: Imoveis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imoveis = await _context.Imoveis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imoveis == null)
            {
                return NotFound();
            }

            return View(imoveis);
        }

        // POST: Imoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imoveis = await _context.Imoveis.FindAsync(id);
            _context.Imoveis.Remove(imoveis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImoveisExists(int id)
        {
            return _context.Imoveis.Any(e => e.Id == id);
        }
    }
}
