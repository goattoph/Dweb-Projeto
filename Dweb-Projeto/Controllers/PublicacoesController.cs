using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dweb_Projeto.Data;
using Dweb_Projeto.Models;

namespace Dweb_Projeto.Controllers
{
    public class PublicacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Publicacoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Publicacao.Include(p => p.Utilizador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Publicacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacao
                .Include(p => p.Utilizador)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        // GET: Publicacoes/Create
        public IActionResult Create()
        {
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizador, "UserID", "UserID");
            return View();
        }

        // POST: Publicacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Titulo,Descricao,Foto,UtilizadorFK")] Publicacao publicacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizador, "UserID", "UserID", publicacao.UtilizadorFK);
            return View(publicacao);
        }

        // GET: Publicacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacao.FindAsync(id);
            if (publicacao == null)
            {
                return NotFound();
            }
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizador, "UserID", "UserID", publicacao.UtilizadorFK);
            return View(publicacao);
        }

        // POST: Publicacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Titulo,Descricao,Foto,UtilizadorFK")] Publicacao publicacao)
        {
            if (id != publicacao.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacaoExists(publicacao.PostId))
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
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizador, "UserID", "UserID", publicacao.UtilizadorFK);
            return View(publicacao);
        }

        // GET: Publicacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacao
                .Include(p => p.Utilizador)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        // POST: Publicacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicacao = await _context.Publicacao.FindAsync(id);
            if (publicacao != null)
            {
                _context.Publicacao.Remove(publicacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacaoExists(int id)
        {
            return _context.Publicacao.Any(e => e.PostId == id);
        }
    }
}
