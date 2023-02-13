using Arquivos.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arquivos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArquivosController: ControllerBase
    {

        [HttpPost("upload")]
        public async Task<IActionResult> GetFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Arquivo nao recebido");
            var arquivoService = new ArquivoService();

            var result = await arquivoService.SaveFile(file);
            if (!result)
                return BadRequest(new {Message= "Falha ao Salvar o Arquivo"});
            return Ok(new {Message = "Arquivo Salvo com Sucesso"});
        }
    }
}
