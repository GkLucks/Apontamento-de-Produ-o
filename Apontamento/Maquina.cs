using System;
namespace Apontamento {
public class Maquina : Base
{
    public string TipoProcessoSuportado { get; set; }
    public bool Ativa { get; set; }

    public Maquina() { }

    // Construtor opcional para facilitar a criação
    public Maquina(int id, string nome, string processo, bool ativa)
    {
        Id = id;
        Nome = nome;
        TipoProcessoSuportado = processo;
        Ativa = ativa;
    }
}
}