
using Apontamento.Domain.Aggregates;
using Apontamento.Domain.Interfaces;

namespace Apontamento.API
{
    public class Menu
    {
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

        private void CadastrarOperador()
        {
            Console.Write("Nome do Operador: ");
            string nome = Console.ReadLine()!;
            _operadorRepo.Save(new Operador { Nome = nome });
            Console.WriteLine("Operador salvo!");
            AguardarTecla();
        }

        private void ListarOperadores()
        {
            var lista = _operadorRepo.GetAll();
            Console.WriteLine("-- Lista de Operadores --");
            foreach (var op in lista)
            {
                Console.WriteLine($"ID: {op.Id} | Nome: {op.Nome} | Status: {(op.Ativa ? "Ativo" : "Inativo")}");
            }
            AguardarTecla();
        }

        private void ExcluirOperador()
        {
            Console.Clear();
            Console.WriteLine("--- DESATIVAR OPERADOR ---");

            var operadores = _operadorRepo.GetAll();
            if (operadores.Count == 0)
            {
                Console.WriteLine("Nenhum operador cadastrado.");
                AguardarTecla();
                return;
            }

            foreach (var op in operadores)
            {
                Console.WriteLine($"ID: {op.Id} | Nome: {op.Nome} | Status: {(op.Ativa ? "Ativo" : "Inativo")}");
            }

            Console.Write("\nDigite o ID exato do operador que deseja desativar: ");

            if (int.TryParse(Console.ReadLine(), out int idParaDesativar))
            {
                var operador = operadores.FirstOrDefault(o => o.Id == idParaDesativar);
                if (operador != null)
                {
                    Console.Write($"\nTEM CERTEZA que deseja excluir '{idParaDesativar}'? (S/N): ");
                    string confirmacao = Console.ReadLine()?.ToUpper()!;

                    if (confirmacao == "S")
                    {
                        _operadorRepo.Update(operador);
                        Console.WriteLine("\nOperador desativado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("\nOperação cancelada.");
                    }
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

        private void CadastrarMaquina()
        {
            Console.Write("Nome da Máquina: ");
            string nomeMaquina = Console.ReadLine()!;
            _maquinaRepo.Save(new Maquina { Nome = nomeMaquina });
            Console.WriteLine("Máquina salva!");
            AguardarTecla();
        }

        private void ListarMaquina()
        {
            var listaMaquinas = _maquinaRepo.GetAll();
            Console.WriteLine("-- Lista de Máquinas --");
            foreach (var maq in listaMaquinas)
            {
                Console.WriteLine($"ID: {maq.Id} | Nome: {maq.Nome} | Status: {(maq.Ativa ? "Ativa" : "Inativa")}");
            }
            AguardarTecla();
        }

        private void ExcluirMaquina()
        {
            Console.Clear();
            Console.WriteLine("--- DESATIVAR MÁQUINA ---");

            var maquinas = _maquinaRepo.GetAll();
            if (maquinas.Count == 0)
            {
                Console.WriteLine("Nenhuma máquina cadastrada.");
                AguardarTecla();
                return;
            }

            foreach (var maq in maquinas)
            {
                Console.WriteLine($"ID: {maq.Id} | Nome: {maq.Nome} ({(maq.Ativa ? "Ativa" : "Inativa")})");
            }

            Console.Write("\nDigite o ID da máquina que deseja desativar: ");

            if (int.TryParse(Console.ReadLine(), out int idEscolhido))
            {
                var maquina = maquinas.FirstOrDefault(m => m.Id == idEscolhido);
                if (maquina != null)
                {
                    Console.Write($"\nTEM CERTEZA que deseja desativar '{maquina.Nome}'? (S/N): ");
                    string confirmacao = Console.ReadLine()?.ToUpper()!;

                    if (confirmacao == "S")
                    {
                        maquina.Ativa = false;
                        _maquinaRepo.Update(maquina);
                        Console.WriteLine("\nMáquina desativada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("\nOperação cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("\nErro: ID não encontrado na lista.");
                }
            }
            else
            {
                Console.WriteLine("\nEntrada inválida. Por favor, digite um número válido.");
            }
            AguardarTecla();
        }

        private void MenuProcesso()
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