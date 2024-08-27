using Cad_Cliente.Integracao;
using Cad_Cliente.Integracao.Interfece;
using Cad_Cliente.Integracao.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cad_Cliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IviaCepIntegracao _integracao;

        public CepController(IviaCepIntegracao integracao)
        {
            _integracao = integracao;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListaCep(string cep)
        {
            var responsedado =  await _integracao.dadoscep(cep);

            if(responsedado == null) { return BadRequest("cep não encontrado"); }

            return Ok(responsedado);


        }
    }
}
