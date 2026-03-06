using System;

namespace Apontamento
{
    public interface IDataManager
    {
        void SalvarOperador(Operador operador);
        void SalvarMaquina(Maquina maquina);
        List<Operador> ObterTodosOperadores();
        List<Maquina> ObterTodasMaquinas();
        
    }
}