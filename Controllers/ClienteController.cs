using Cad_Cliente.Models;
using Cad_Cliente.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cad_Cliente.Controllers
{
    public class ClienteController : Controller
    {
        private readonly Icadastro _cadastroRepositorio;
        public ClienteController(Icadastro CadastroRepositorio) 
        { 
        
            _cadastroRepositorio = CadastroRepositorio;
        }
        public IActionResult Index()
        {
          List<CadastroModel> cadastros = _cadastroRepositorio.buscar();
            
            return View(cadastros);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           CadastroModel pesquisa = _cadastroRepositorio.listaId(id);
            return View(pesquisa);
        }

        public IActionResult apagar(int id)
        {
            CadastroModel cliente = _cadastroRepositorio.listaId(id);
            return View(cliente);
        }
        public IActionResult Excluir(int id)
        {
            _cadastroRepositorio.excluir(id);
            return RedirectToAction("Index");
        }
        public IActionResult Pesquisar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(CadastroModel cadastro)
        {
            _cadastroRepositorio.adiconar(cadastro);
            return RedirectToAction("Criar");
        }

        [HttpPost]
        public IActionResult Alterar(CadastroModel cadastro)
        {
            _cadastroRepositorio.atualizar(cadastro);
            return RedirectToAction("Criar");
        }

        [HttpPost]
        public IActionResult Pesquisar(int id)
        {
            CadastroModel pbusca = _cadastroRepositorio.pesquisa(id);
            return View(pbusca);
        }
    }
}
