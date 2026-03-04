namespace Apontamento {
public class Operador : Base
{
    public string Usuario { get; set; }
    //O que usar na senha ?
    public string Senha {get; set;}
    //ativa e ativo são iguais ?
    public bool Ativa { get; set; }

    // Construtor opcional
    public Operador(int id, string nome, string senha, bool ativa)
    {
        Id = id;
        Nome = nome;
        Senha = senha;
        Ativa = ativa;
    }
}
}
