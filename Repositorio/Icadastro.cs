using Cad_Cliente.Models;
using System.Collections.Generic;

namespace Cad_Cliente.Repositorio
{
    public interface Icadastro
    {
        CadastroModel pesquisa(int id);
        CadastroModel listaId(int id);
        List<CadastroModel> buscar();
        CadastroModel adiconar(CadastroModel cadastro);

        CadastroModel atualizar(CadastroModel cadastro);

        bool excluir(int id);
    }
}
