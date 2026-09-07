using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MensagensController : ControllerBase
{
    // Variável estática simples para guardar a última mensagem na memória do servidor
    private static string ultimaMensagem = "Nenhuma mensagem ainda.";

    // Endpoint para ENVIAR a mensagem (POST: /api/mensagens/enviar)
    [HttpPost("enviar")]
    public IActionResult EnviarMensagem([FromBody] MensagemModel dados)
    {
        if (dados == null || string.IsNullOrEmpty(dados.Texto))
        {
            return BadRequest("Mensagem inválida.");
        }

        ultimaMensagem = dados.Texto;
        return Ok(new { status = "Mensagem enviada com sucesso!" });
    }

    // Endpoint para RECEBER a mensagem (GET: /api/mensagens/receber)
    [HttpGet("receber")]
    public IActionResult ReceberMensagem()
    {
        return Ok(new { texto = ultimaMensagem });
    }
}

// Modelo para receber o JSON do corpo da requisição
public class MensagemModel
{
    public string Texto { get; set; }
}