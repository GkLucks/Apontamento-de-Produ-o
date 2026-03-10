using Apontamento.Domain.Common;

namespace Apontamento.Domain.Aggregates
{
public class Processo : Base
{
    public double ProductionTimeEstimate {get; set;} 

    public DateOnly DeliveryDate {get; set;}

    public string ProcessType {get; set;} = String.Empty;
       
    public enum Status
        {
            Pendente,
            EmExecução,
            Finalizado
        }   
}
}