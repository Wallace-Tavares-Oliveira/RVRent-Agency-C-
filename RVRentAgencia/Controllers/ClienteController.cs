using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RVRentAgencia.Data;
using RVRentAgencia.Models;

namespace RVRentAgencia.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteContext _context;

        public ClienteController(ClienteContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            var clienteContext = _context.Clientes.Include(c => c.Contato).Include(c => c.Destino).Include(c => c.Promocao);
            return View(await clienteContext.ToListAsync());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Contato)
                .Include(c => c.Destino)
                .Include(c => c.Promocao)
                .FirstOrDefaultAsync(m => m.Id_Cliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            ViewData["ContatoId_contato"] = new SelectList(_context.Contatos, "Id_Contato", "Email");
            ViewData["DestinoId_destino"] = new SelectList(_context.Destinos, "Id_Destino", "Estado");
            ViewData["PromocaoId_promocao"] = new SelectList(_context.Promocoes, "Id_Promocao", "Preco");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Cliente,Nome,Telefone,DestinoId_destino,PromocaoId_promocao,ContatoId_contato")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContatoId_contato"] = new SelectList(_context.Contatos, "Id_Contato", "Email", cliente.ContatoId_contato);
            ViewData["DestinoId_destino"] = new SelectList(_context.Destinos, "Id_Destino", "Estado", cliente.DestinoId_destino);
            ViewData["PromocaoId_promocao"] = new SelectList(_context.Promocoes, "Id_Promocao", "Preco", cliente.PromocaoId_promocao);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["ContatoId_contato"] = new SelectList(_context.Contatos, "Id_Contato", "Email", cliente.ContatoId_contato);
            ViewData["DestinoId_destino"] = new SelectList(_context.Destinos, "Id_Destino", "Estado", cliente.DestinoId_destino);
            ViewData["PromocaoId_promocao"] = new SelectList(_context.Promocoes, "Id_Promocao", "Preco", cliente.PromocaoId_promocao);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Cliente,Nome,Telefone,DestinoId_destino,PromocaoId_promocao,ContatoId_contato")] Cliente cliente)
        {
            if (id != cliente.Id_Cliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id_Cliente))
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
            ViewData["ContatoId_contato"] = new SelectList(_context.Contatos, "Id_Contato", "Email", cliente.ContatoId_contato);
            ViewData["DestinoId_destino"] = new SelectList(_context.Destinos, "Id_Destino", "Estado", cliente.DestinoId_destino);
            ViewData["PromocaoId_promocao"] = new SelectList(_context.Promocoes, "Id_Promocao", "Preco", cliente.PromocaoId_promocao);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Contato)
                .Include(c => c.Destino)
                .Include(c => c.Promocao)
                .FirstOrDefaultAsync(m => m.Id_Cliente == id);
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
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id_Cliente == id);
        }
    }
}
