using Cad_Cliente.Dados;
using Cad_Cliente.Migrations;
using Cad_Cliente.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cad_Cliente.Repositorio
{
    public class CadastroRepositorio : Icadastro
    {
        private readonly BancoContext _bancoContext;
        public CadastroRepositorio(BancoContext db_cadastro) 
        { 
            _bancoContext = db_cadastro;
        }
        public CadastroModel adiconar(CadastroModel cadastro)
        {
            // Grava no Banco de dados 
            _bancoContext.CadastroTabela.Add(cadastro);
            _bancoContext.SaveChanges();

            return cadastro;
            //throw new System.NotImplementedException();
        }

        public CadastroModel atualizar(CadastroModel cadastro)
        {
            CadastroModel cadastroDB = listaId(cadastro.Id);

            if (cadastroDB == null) throw new System.Exception("erro ao atualizar");

            cadastroDB.name = cadastro.name;
            cadastroDB.mail = cadastro.mail;
            cadastroDB.cpf = cadastro.cpf;
            cadastroDB.idade = cadastro.idade;

            _bancoContext.Update(cadastroDB);
            _bancoContext.SaveChanges();
            return cadastroDB;  
        }

        public List<CadastroModel> buscar()
        {
            
            return _bancoContext.CadastroTabela.ToList();
            //throw new System.NotImplementedException();
        }

        public bool excluir(int id)
        {
            CadastroModel cadastroDB = listaId(id);

            if (cadastroDB == null) throw new System.Exception("erro ao delatar");
            _bancoContext.CadastroTabela.Remove(cadastroDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public CadastroModel listaId(int id)
        {
            return _bancoContext.CadastroTabela.FirstOrDefault(x => x.Id == id);
        }

        public CadastroModel pesquisa(int id)
        {
            return _bancoContext.CadastroTabela.FirstOrDefault(n =>n.Id ==id);
            //throw new System.NotImplementedException();
        }

       
    }
}
