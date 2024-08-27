using Cad_Cliente.Integracao.Response;
using System.Threading.Tasks;

namespace Cad_Cliente.Integracao.Interfece
{
    public interface IviaCepIntegracao
    {
        Task<ViaCepResponse> dadoscep(string cep);
    }
}
