using System.Collections.Generic;
using Apontamento.Domain.Aggregates;
using Apontamento.Domain.Interfaces;

namespace Apontamento.Infrastructure
{
    public class DataManager : IDataManager
    {
        
        private Dictionary<string, Operador> operadoresRegistrados = new();
        private Dictionary<string, Maquina> maquinasRegistradas = new();

        void IDataManager.SalvarOperador(Operador operador)
        {
            operadoresRegistrados[operador.Nome] = operador;
        }

        void IDataManager.SalvarMaquina(Maquina maquina)
        {
            maquinasRegistradas[maquina.Nome] = maquina;
        }

        void IDataManager.ExcluirOperador(Operador operador)
        {
            operadoresRegistrados.Remove(operador.Nome);
        }
        
        
        List<Operador> IDataManager.ObterTodosOperadores()
        {
            return new List<Operador>(operadoresRegistrados.Values);
        }

        List<Maquina> IDataManager.ObterTodasMaquinas()
        {
            return new List<Maquina>(maquinasRegistradas.Values);
        }

    }
}