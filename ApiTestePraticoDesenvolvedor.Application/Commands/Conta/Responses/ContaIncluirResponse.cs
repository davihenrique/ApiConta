using System.Text.Json.Serialization;
using ApiConta.Application.Commands.Conta.Enum;

namespace ApiConta.Application.Commands.Conta.Responses;
public class ContaIncluirResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? Id { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public StatusConta Status { get; set; }

    public required IEnumerable<string> Mensagens { get; set; }
}
