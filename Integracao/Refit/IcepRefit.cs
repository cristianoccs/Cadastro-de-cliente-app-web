using Cad_Cliente.Integracao.Response;
using Refit;
using System.Threading.Tasks;

namespace Cad_Cliente.Integracao.Refit
{
    public interface IcepRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> dadoscep(string cep);
    }
}
