﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projeto_pucminas_eixo2.Models;

namespace projeto_pucminas_eixo2.Controllers
{
    public class VendasController : Controller
    {
        private readonly AppDbContext _context;

        public VendasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Consumos.Include(v => v.Produto);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Consumos
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            // Passando a lista de produtos diretamente para a ViewBag
            ViewBag.Produtos = _context.Produtos.ToList();

            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cliente,Data,QuantidadeVenda,Tipo,ProdutoId")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                // Buscar o produto selecionado
                var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == venda.ProdutoId);

                if (produto != null)
                {
                    venda.Valor = produto.ValorProduto;
                }
                else
                {
                    ModelState.AddModelError("ProdutoId", "Produto não encontrado.");
                    ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", venda.ProdutoId);
                    return View(venda);
                }

                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", venda.ProdutoId);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Consumos.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", venda.ProdutoId);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cliente,Data,Valor,QuantidadeVenda,Tipo,ProdutoId")] Venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.Id))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", venda.ProdutoId);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Consumos
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Consumos.FindAsync(id);
            if (venda != null)
            {
                _context.Consumos.Remove(venda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Consumos.Any(e => e.Id == id);
        }
    }
}
