//Campos comuns que vou utilizar nas classes
namespace Apontamento.Domain.Common {
public abstract class BaseEntity
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}
}