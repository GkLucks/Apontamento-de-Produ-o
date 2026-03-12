using Apontamento.Domain.Aggregates;
using Apontamento.Domain.Interfaces;
using System.Linq;


namespace Apontamento.Infrastructure
{
    public class MaquinaRepository : IMaquinaRepository
    {
        private readonly Dictionary<int, Maquina> maquinasRegistradas = new(); 
        public void Save(Maquina maquina)
        {
            if (maquina.Id == 0)
            {
                int newId = maquinasRegistradas.Count > 0 ? maquinasRegistradas.Keys.Max() + 1 : 1;
                maquina.Id = newId;
            }
            maquinasRegistradas[maquina.Id] = maquina;
        }

        public void Delete(Maquina maquina) => maquinasRegistradas.Remove(maquina.Id);
        
        public List<Maquina> GetAll() => maquinasRegistradas.Values.ToList();

        public void Update(Maquina maquina) => maquinasRegistradas[maquina.Id] = maquina;

    }

}