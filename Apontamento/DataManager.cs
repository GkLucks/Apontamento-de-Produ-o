namespace Apontamento
{
    public class DataManager : IDataManager
    {
        
        public Dictionary<string, Operador> operadoresRegistrados = new();
        public Dictionary<string, Maquina> maquinasRegistradas = new();

        void IDataManager.SalvarOperador(Operador operador)
        {
            operadoresRegistrados[operador.Nome] = operador;
        }

        void IDataManager.SalvarMaquina(Maquina maquina)
        {
            maquinasRegistradas[maquina.Nome] = maquina;
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