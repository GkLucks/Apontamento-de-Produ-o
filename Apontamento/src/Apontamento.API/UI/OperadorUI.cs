using Apontamento.Domain.Aggregates;
using Apontamento.Domain.Interfaces;

namespace Apontamento.API
{
    public class OperadorUI
    {
        private readonly IOperadorRepository _repo;
        public OperadorUI(IOperadorRepository repo) => _repo = repo;

        public void MenuOperador()
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
            _repo.Save(new Operador { Nome = nome });
            Console.WriteLine("Operador salvo!");
            AguardarTecla();
        }

        private void ListarOperadores()
        {
            var lista = _repo.GetAll();
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

            var operadores = _repo.GetAll();
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
                        _repo.Update(operador);
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

        private void AguardarTecla()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


    }
}

