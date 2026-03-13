using Apontamento.Domain.Aggregates;
using Apontamento.Domain.Interfaces;


namespace Apontamento.Infrastructure
{
    public class OperadorRepository : IOperadorRepository
    {

        private readonly Dictionary<int, Operador> operadoresRegistrados = new();
 
        public void Save(Operador op)
        {
            if (op.Id == 0)
            {
                int newId = operadoresRegistrados.Count > 0 ? operadoresRegistrados.Keys.Max() + 1 : 1;
                op.Id = newId;
            }
            operadoresRegistrados[op.Id] = op;
        }

        public void Delete(Operador op) => operadoresRegistrados.Remove(op.Id);

        public List<Operador> GetAll() => operadoresRegistrados.Values.ToList();

        public void Update(Operador op) => operadoresRegistrados[op.Id] = op; 

    }

}