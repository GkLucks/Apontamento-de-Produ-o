namespace Apontamento
{
    public class Menu : IMenu
    {
        private readonly IDataManager _dataManager;

        public Menu(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void ShowMenu()
        {
            Console.WriteLine("=== Menu ===");
            Console.WriteLine("1. Cadastrar Operador");
            Console.WriteLine("2. Cadastrar Máquina");
            Console.WriteLine("3. Listar Operadores");
            Console.WriteLine("4. Listar Máquinas");
            Console.WriteLine("5. Sair");
        }

        public void ProcessarOpcao(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    Console.Write("Nome do Operador: ");
                    string nome = Console.ReadLine()!;
                    _dataManager.SalvarOperador(new Operador { Nome = nome });
                    Console.WriteLine("Operador salvo!");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Write("Nome da Máquina: ");
                    string nomeMaquina = Console.ReadLine();
                    _dataManager.SalvarMaquina(new Maquina { Nome = nomeMaquina });
                    Console.WriteLine("Máquina salva!");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 3:
                    var lista = _dataManager.ObterTodosOperadores();
                    Console.WriteLine("-- Lista de Operadores --");
                    foreach (var op in lista) Console.WriteLine($"- {op.Nome}");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 4:
                    var listaMaquinas = _dataManager.ObterTodasMaquinas();
                    Console.WriteLine("-- Lista de Máquinas --");
                    foreach (var maq in listaMaquinas) Console.WriteLine($"- {maq.Nome}");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 5:
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