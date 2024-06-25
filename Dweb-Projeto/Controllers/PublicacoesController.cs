using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dweb_Projeto.Data;
using Dweb_Projeto.Models;
using Microsoft.AspNetCore.Hosting;

namespace Dweb_Projeto.Controllers
{
    public class PublicacoesController : Controller
    {

        /// <summary>
        /// referência à base de dados do projeto
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// objecto que contém os dados do Servidor
        /// </summary>
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PublicacoesController(
         ApplicationDbContext context,
         IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Titulo,Descricao,Foto")] Publicacao publicacao, IFormFile FotoPublicacao){
    // a anotação [Bind] informa o servidor de quais atributos
    // que devem ser lidos do objeto que vem do browser

    /* Guardar a imagem no disco rígido do Servidor
     * Algoritmo 
     * 1- há ficheiro?
     *  1.1 - não
     *        devolvo controlo ao browser com mensagem de erro
     *  1.2 - sim
     *        Será a foto (JPG, PNG, JPEG)?
     *        1.2.1 - não
     *                devolvo controlo ao browser com mensagem de erro
     *        1.2.2 - sim
     *              - determinar o nome da foto
     *              - guardar essa nome na BD
     *              - guardar o ficheiro no disco rígido
    */

    // declarando as variáveis fora do bloco if
    string nomeFoto = "";
    bool haFoto = false;

    // avalia se os dados recebidos do browser estão de acordo com o Model
    if (ModelState.IsValid){
        // verificar se existe ficheiro
        if(FotoPublicacao == null){
            // não há
            // criar msg de erro
            ModelState.AddModelError("", "Deve fornecer uma imagem");
            // devolver controlo à View
            return View(publicacao);
        } else {
            // há ficheiro, mas é uma foto?
            if(!(FotoPublicacao.ContentType == "image/png" ||
                FotoPublicacao.ContentType == "image/jpg" ||
                FotoPublicacao.ContentType == "image/jpeg")){
                    // não é uma foto
                    // criar msg de erro
                    ModelState.AddModelError("", "O ficheiro fornecido não é uma imagem");
                    // devolver controlo à View
                    return View(publicacao);
            } else {
                // há foto
                haFoto = true;
                // gerar nome foto
                Guid g = Guid.NewGuid();
                nomeFoto = g.ToString();
                string extensaoFoto = Path.GetExtension(FotoPublicacao.FileName).ToLowerInvariant();
                nomeFoto += extensaoFoto;
                // guardar o nome do ficheiro na BD
                publicacao.Foto = nomeFoto;
            }
        }

        // adiciona à BD os dados vindos da View
        _context.Update(publicacao);
        // Commit
        await _context.SaveChangesAsync();

        // guardar a foto da publicação
        if (haFoto) {
            // determinar o local de armazenamento da foto
            string localizacaoFoto = Path.Combine(_webHostEnvironment.WebRootPath, "images");

            // será que o local existe?
            if (!Directory.Exists(localizacaoFoto)){
                Directory.CreateDirectory(localizacaoFoto);
            }

            // atribuir ao caminho o nome da foto
            localizacaoFoto = Path.Combine(localizacaoFoto, nomeFoto);

            // guardar a foto no Disco Rígido
            using var stream = new FileStream(localizacaoFoto, FileMode.Create);
            await FotoPublicacao.CopyToAsync(stream);
        }

        return RedirectToAction(nameof(Index));
    }

    // Se o ModelState não é válido, retorna a View com os dados do modelo
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
