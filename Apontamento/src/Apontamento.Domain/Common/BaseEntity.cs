//Campos comuns que vou utilizar nas classes
namespace Apontamento.Domain.Common {
public abstract class Base
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}
}