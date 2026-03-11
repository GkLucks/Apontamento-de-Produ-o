using Apontamento.Domain.Aggregates;
using Apontamento.Domain.Interfaces;


namespace Apontamento.Infrastructure
{
    public class OperadorRepository : IOperadorRepository
    {

        private readonly Dictionary<string, Operador> operadoresRegistrados = new();
 
        public void Save(Operador op) => operadoresRegistrados[op.Nome] = op;

        public void Delete(Operador op) => operadoresRegistrados.Remove(op.Nome);

        public List<Operador> GetAll() => operadoresRegistrados.Values.ToList();

    }

}