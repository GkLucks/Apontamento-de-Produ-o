using Apontamento.Domain.Aggregates;
using Apontamento.Domain.Interfaces;


namespace Apontamento.Infrastructure
{
    public class MaquinaRepository : IMaquinaRepository
    {
        private readonly Dictionary<string, Maquina> maquinasRegistradas = new(); 
        public void Save(Maquina maquina) => maquinasRegistradas[maquina.Nome] = maquina;

        public void Delete(Maquina maquina) => maquinasRegistradas.Remove(maquina.Nome);
        
        public List<Maquina> GetAll() => maquinasRegistradas.Values.ToList();

    }

}