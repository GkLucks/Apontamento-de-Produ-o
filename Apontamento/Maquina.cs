using System;
namespace Apontamento {
public class Maquina : Base
{
    public string TipoProcessoSuportado { get; set; } = string.Empty;
    public bool Ativa { get; set; }

    // Construtor simples (apenas nome)
    public Maquina(string nome)
    {
        Nome = nome;
        TipoProcessoSuportado = string.Empty;
        Ativa = true;
    }

    // Construtor completo
    public Maquina(int id, string nome, string processo, bool ativa)
    {
        Id = id;
        Nome = nome;
        TipoProcessoSuportado = processo;
        Ativa = ativa;
    }
}
}