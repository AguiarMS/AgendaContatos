using AgendaContatos.Models;
using AgendaContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           ContatoModel contato = _contatoRepositorio.ListarId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmation(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "O contato foi apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemError"] = "Ops, não foi possível apagar este contato";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception error)
            {
                TempData["MensagemSucesso"] = $"Não foi possível apagar este contato, detalhes do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (System.Exception error)
            {
                TempData["MenssagemErro"] = $"Não conseguimos cadastrar seu contato, tente novamente, detalhes do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch(System.Exception error)
            {
                TempData["MenssagemErro"] = $"Não conseguimos atualizar seu contato, tente novamente, detalhes do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
