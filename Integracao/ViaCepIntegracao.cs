using Cad_Cliente.Integracao.Interfece;
using Cad_Cliente.Integracao.Refit;
using Cad_Cliente.Integracao.Response;
using System.Threading.Tasks;

namespace CadastroCliente.Integracao
{
    public class ViaCepIntegracao : IviaCepIntegracao
    {
        private readonly IcepRefit _icepRefit;

        public ViaCepIntegracao(IcepRefit icepRefit)
        {
            _icepRefit = icepRefit;
        }

        public async Task<ViaCepResponse> dadoscep(string cep)
        {
          var responsedado =await _icepRefit.dadoscep(cep);

            if(responsedado != null && responsedado.IsSuccessStatusCode) 
            { 
                return responsedado.Content;
            }
            return null;
        }
    }
}
