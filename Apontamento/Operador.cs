using System;
namespace Apontamento 
{
public class Operador : Base
{
    public string Usuario { get; set; } = string.Empty;
    //O que usar na senha ?
    public string Senha { get; set; } = string.Empty;
    //ativa e ativo são iguais ?
    public bool Ativa { get; set; }

    // Construtor sem parâmetros
    public Operador()
    {
    }

    // Construtor simples (apenas nome)
    public Operador(string nome)
    {
        Nome = nome;
        Usuario = string.Empty;
        Senha = string.Empty;
        Ativa = true;
    }

    // Construtor completo
    public Operador(int id, string nome, string senha, bool ativa)
    {
        Id = id;
        Nome = nome;
        Senha = senha;
        Ativa = ativa;
        Usuario = string.Empty;
    }
}
}
