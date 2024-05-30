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
    public class ClienteController : Controller
    {
        private readonly ImobiliariaContext _context;
        
        // Ingestão de dependencia
        public ClienteController(ImobiliariaContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index(string searchString) //pagina inicial
        {
            // se a minha tabela de clientes for nula o sistema para por qui e reporta um problema
            if(_context.Cliente == null)
            {
                return Problem("Tabela de Clientes nula");
            }

            // se tabela não for nula e eu quiser trazer um determinado cliente para o controller
            var clientes = from c in _context.Cliente select c; //linguagem linq (select * from Cliente)

            if(!String.IsNullOrEmpty(searchString))
            {
                clientes = clientes.Where(c => c.Nome!.Contains(searchString)); //clientes que contiver no nome a searchString. O ! diz que se o nome não for vazio retorna a searchString
            }	


            return View(await clientes.ToListAsync()); // select
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Email")] Cliente cliente)
        {
            // segue as regras de validacao do Cliente.cs
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // joga para o banco de dados
            }
            return View(cliente); //volta com os dados
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //FindAsync = select para não depender do banco de dados
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // Faz primeiramente verificações, para depois fazer alterações NO BANCO DE DADOS
        [HttpPost]
        [ValidateAntiForgeryToken] // autorização para entrar, alterar e sair do banco de dados
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Email")] Cliente cliente) //quais atributos são diferentes do original
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente); // conecta ao banco de dados e atualiza
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}
