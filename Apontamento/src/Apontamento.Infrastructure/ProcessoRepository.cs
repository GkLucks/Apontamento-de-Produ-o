using Apontamento.Domain.Aggregates;
using Apontamento.Domain.Interfaces;

namespace Apontamento.Infrastructure
{
    public class ProcessoRepository : IProcessoRepository
    {
        private readonly Dictionary<int, Processo> _processos = new();

        public void Save(Processo processo)
        {
            if (processo.Id == 0)
            {
                processo.Id = _processos.Count > 0 ? _processos.Keys.Max() + 1 : 1;
                processo.Status = StatusProcesso.Pendente;
            }
            _processos[processo.Id] = processo;
        } 
        public List<Processo> GetAll() => _processos.Values.ToList();
        public void Update(Processo processo) => _processos[processo.Id] = processo;
        public void Delete(Processo processo) => _processos.Remove(processo.Id);

    }

}