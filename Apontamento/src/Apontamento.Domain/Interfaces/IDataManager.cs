using System;
using System.Collections.Generic;
using Apontamento.Domain.Aggregates;

namespace Apontamento.Domain.Interfaces
{
    public interface IDataManager
    {
        void SalvarOperador(Operador operador);
        void SalvarMaquina(Maquina maquina);
        void ExcluirOperador(Operador operador);
        List<Operador> ObterTodosOperadores();
        List<Maquina> ObterTodasMaquinas();
        
    }
}