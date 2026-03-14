
using Apontamento.Domain.Aggregates;
using Apontamento.Domain.Interfaces;

namespace Apontamento.API
{
    public class Menu
    {
        private readonly IOperadorRepository _operadorRepo;
        private readonly IMaquinaRepository _maquinaRepo;

        private readonly OperadorUI _operadorUI;
        private readonly MaquinaUI _maquinaUI;
        private readonly ProcessoUI _processoUI;

        public Menu(OperadorUI opUI, MaquinaUI maqUI, ProcessoUI proUI)
        {
            _operadorUI = opUI;
            _maquinaUI = maqUI;
            _processoUI = proUI;
        }

        public void ShowMenu()
        {
            Console.WriteLine("=== Menu Principal===");
            Console.WriteLine("1. Operador");
            Console.WriteLine("2. Máquina");
            Console.WriteLine("3. Processo Ativo");
            Console.WriteLine("4. Sair");
        }

        public void ProcessarOpcao(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    _operadorUI.MenuOperador();
                    break;
                case 2:
                    _maquinaUI.MenuMaquina();
                    break;
                case 3:
                    _processoUI.MenuProcesso();
                    break;
                case 4:
                    Console.WriteLine("Saindo do programa...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }


    }

}