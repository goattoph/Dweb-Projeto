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
    public class UtilizadoresController : Controller{
        /// <summary>
        /// referência à base de dados do projeto
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// objecto que contém os dados do Servidor
        /// </summary>
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UtilizadoresController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Utilizadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilizador.ToListAsync());
        }

        // GET: Utilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizador
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // GET: Utilizadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Nome,DataNascimento,Telefone")] Utilizador utilizador, IFormFile ImagemFoto){
            // a anotação [Bind] informa o servidor de quais os atributos
            // que devem ser lidos do objeto que vem do browser

            /* Guardar a imagem no disco rígido do Servidor
             * Algoritmo
             * 1- há ficheiro?
             *    1.1 - não
             *          devolvo controlo ao browser
             *          com mensagem de erro
             *    1.2 - sim
             *          Será imagem (JPG,JPEG,PNG)?
             *          1.2.1 - não
             *                  devolvo controlo ao browser
             *                  com mensagem de erro
             *          1.2.2 - sim
             *                  - determinar o nome da imagem
             *                  - guardar esse nome na BD
             *                  - guardar o ficheir no disco rígido
             */

            // avalia se os dados recebido do browser estão
            // de acordo com o Model

            if (ModelState.IsValid){

                // vars auxiliares
                string nomeImagem = "";
                bool haImagem = false;

                // há ficheiro?
                if (ImagemFoto == null)
                {
                    //não há, crio msg de erro
                    ModelState.AddModelError("", "Deve fornecer uma imagem");
                    //devolvo controlo ao browser
                    return View(utilizador);
                }
                else
                {
                    // há ficheiro, será uma imagem?
                    if (!(ImagemFoto.ContentType == "image/jpeg" ||
                        ImagemFoto.ContentType == "image/jpg" ||
                        ImagemFoto.ContentType == "image/png"))
                    {
                        //não é uma imagem
                        ModelState.AddModelError("", "O ficheiro fornecido não é uma imagem válida");
                        //devolvo controlo ao browser
                        return View(utilizador);
                    }
                    else
                    {
                        // há imagem e é uma imagem válida
                        haImagem = true;
                        // determinar o nome da imagem
                        Guid g = Guid.NewGuid();
                        nomeImagem = g.ToString();
                        string extensaoImagem = Path.GetExtension(ImagemFoto.FileName).ToLowerInvariant();
                        nomeImagem += extensaoImagem;
                        // guardar o nome da imagem na BD
                        utilizador.Foto = nomeImagem;
                    }
                }
                                
                // adiciona à BD os dados vindos da View
                _context.Add(utilizador);
                // commit
                await _context.SaveChangesAsync();

                // guardar a imagem da foto no disco rígido
                if (haImagem) {
                    // determinar o local de armazenamento da imagem
                    string localizacaoImagem = _webHostEnvironment.WebRootPath;
                    // adicionar à raiz da parte web, o nome da pasta onde queremos guardar as imagens
                    localizacaoImagem = Path.Combine(localizacaoImagem, "Imagens");

                    // será que o local existe?
                    if (!Directory.Exists(localizacaoImagem))
                    {
                        Directory.CreateDirectory(localizacaoImagem);
                    }

                    // atribuir ao caminho o nome da imagem
                    localizacaoImagem = Path.Combine(localizacaoImagem, nomeImagem);

                    // guardar a imagem no Disco Rígido
                    using var stream = new FileStream(
                       localizacaoImagem, FileMode.Create
                       );
                    await ImagemFoto.CopyToAsync(stream);
                }

                // redireciona o utilizador para a página de 'início'
                // dos Cursos
                return RedirectToAction(nameof(Index));
            }
            // se cheguei aqui é pq alguma coisa correu mal
            // devolve controlo à View, apresentando os dados recebidos
            return View(utilizador);
        }

        // GET: Utilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizador.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,Nome,Foto,DataNascimento,Telefone")] Utilizador utilizador)
        {
            if (id != utilizador.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadorExists(utilizador.UserID))
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
            return View(utilizador);
        }

        // GET: Utilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizador
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizador = await _context.Utilizador.FindAsync(id);
            if (utilizador != null)
            {
                _context.Utilizador.Remove(utilizador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadorExists(int id)
        {
            return _context.Utilizador.Any(e => e.UserID == id);
        }
    }
}
