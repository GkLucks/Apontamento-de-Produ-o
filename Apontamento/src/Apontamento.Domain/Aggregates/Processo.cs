using Apontamento.Domain.Common;


namespace Apontamento.Domain.Aggregates
{
    public enum StatusProcesso
    {
        Pendente,
        EmExecucao,
        Finalizado
    }
    public class Processo : BaseEntity
    {
        public double TempoEstimadoProducao {get; set;}
        public DateTime DataEntrega {get; set;}
        public string TipoProcesso {get; set;} = string.Empty;
        public StatusProcesso Status {get; set;} = StatusProcesso.Pendente;
        public Processo() {}
        public Processo(string nome, double tempo, DateTime entrega, string tipo)
        {
            Nome = nome;
            TempoEstimadoProducao = tempo;
            DataEntrega = entrega;
            TipoProcesso = tipo;
            Status = StatusProcesso.Pendente;
        }



    }



}