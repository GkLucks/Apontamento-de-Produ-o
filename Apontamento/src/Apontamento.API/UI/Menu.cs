
using Apontamento.Domain.Aggregates;
using Apontamento.Domain.Interfaces;
using System.Linq;

namespace Apontamento.API
{
    public class Menu
    {
        //private readonly IDataManager _dataManager;
        private readonly IOperadorRepository _operadorRepo;
        private readonly IMaquinaRepository _maquinaRepo;

        public Menu(IOperadorRepository operadorRepo, IMaquinaRepository maquinaRepo)
        {
            _operadorRepo = operadorRepo;
            _maquinaRepo = maquinaRepo;
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
                    MenuOperadores();
                    break;
                case 2:
                    MenuMaquina();
                    break;
                case 3:
                    MenuProcesso();
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

        private void MenuOperadores()
        {
            bool voltar = false;
            while (!voltar)
            {
        
            Console.Clear();
            Console.WriteLine("--- MENU: OPERADORES ---");
            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Excluir");
            Console.WriteLine("0. Voltar ao Menu Principal");
            Console.Write("Escolha: ");

            if (int.TryParse(Console.ReadLine(), out int subOpcao))
            {
                switch (subOpcao)
                {
                    case 1:
                        CadastrarOperador();
                        break;
                    case 2:
                        ListarOperadores();
                        break;
                    case 3:
                        ExcluirOperador();
                        break;
                    case 0:
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Thread.Sleep(1000);
                        break;
                }
            }
            }
        }

        public void CadastrarOperador()
                {
                    Console.Write("Nome do Operador: ");
                    string nome = Console.ReadLine()!;
                    _operadorRepo.Save(new Operador { Nome = nome });
                    Console.WriteLine("Operador salvo!");
                    AguardarTecla();
                }

        public void ListarOperadores()
        {
                var lista = _operadorRepo.GetAll();
                Console.WriteLine("-- Lista de Operadores --");
                foreach (var op in lista) Console.WriteLine($"- {op.Nome}");
                AguardarTecla();
        }

        public void ExcluirOperador()
        {
            Console.Clear();
            Console.WriteLine("--- EXCLUIR OPERADOR ---");

            // 1. Listar o que tem
            var operadores = _operadorRepo.GetAll();
            if (operadores.Count == 0)
            {
                Console.WriteLine("Nenhum operador cadastrado.");
                AguardarTecla();
                return;
            }

            foreach (var op in operadores)
            {
                Console.WriteLine($"- Nome: {op.Nome}");
            }

            Console.Write("\nDigite o NOME exato do operador que deseja excluir: ");
            string nomeParaExcluir = Console.ReadLine()!;

            // 2. Encontrar o operador
            var operador = operadores.FirstOrDefault(o => o.Nome == nomeParaExcluir);
            if (operador != null)
            {
                // 3. Confirmar
                Console.Write($"\nTEM CERTEZA que deseja excluir '{nomeParaExcluir}'? (S/N): ");
                string confirmacao = Console.ReadLine()?.ToUpper()!;

                if (confirmacao == "S")
                {
                    _operadorRepo.Delete(operador);
                    Console.WriteLine("\nOperador removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nOperação cancelada.");
                }
            }
            else
            {
                Console.WriteLine("\nErro: Esse nome não foi encontrado na lista.");
            }
            AguardarTecla();
        }

        private void MenuMaquina()
        {
            bool voltar = false;
            while (!voltar)
            {
        
            Console.Clear();
            Console.WriteLine("--- MENU: Maquina ---");
            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Excluir");
            Console.WriteLine("0. Voltar ao Menu Principal");
            Console.Write("Escolha: ");

            if (int.TryParse(Console.ReadLine(), out int subOpcao))
            {
                switch (subOpcao)
                {
                    case 1:
                        CadastrarMaquina();
                        break;
                    case 2:
                        ListarMaquina();
                        break;
                    case 3:
                        ExcluirMaquina();
                        break;
                    case 0:
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Thread.Sleep(1000);
                        break;
                }
            }
            }
        }

        public void CadastrarMaquina()
        {
            Console.Write("Nome da Máquina: ");
            string nomeMaquina = Console.ReadLine()!;
            _maquinaRepo.Save(new Maquina { Nome = nomeMaquina });
            Console.WriteLine("Máquina salva!");
            AguardarTecla();
        }

        public void ListarMaquina()
        {
            var listaMaquinas = _maquinaRepo.GetAll();
            Console.WriteLine("-- Lista de Máquinas --");
            foreach (var maq in listaMaquinas) Console.WriteLine($"- {maq.Nome}");
            AguardarTecla();
        }

        public void ExcluirMaquina()
        {
            //Ter uma condicional para se houver processo ativo, não excluir a máquina
            // Na verdade é melhor deixar a máquina inativa ou fora de linha
        }

        public void MenuProcesso()
        {
            Console.Clear();
            Console.WriteLine("EM CONSTRUÇÃO, VOLTE NAS FUTURAS ATUALIZAÇÕES");
            AguardarTecla();

        }

        private void AguardarTecla()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


    }
    
}