using System.ComponentModel.DataAnnotations;
using Apontamento.Domain.Aggregates;
using Apontamento.Domain.Interfaces;

namespace Apontamento.API
{
    public class ProcessoUI
    {
        private readonly IProcessoRepository _proc;
        public ProcessoUI(IProcessoRepository proc) => _proc = proc;

        public void MenuProcesso()
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("--- MENU: Processo ---");
                Console.WriteLine("1. Criar Processo");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Excluir");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha: ");

                if(int.TryParse(Console.ReadLine(), out int subOpcao)
                {
                    switch (subOpcao)
                    {
                        case 1:
                        CadastrarProcesso();
                        break;
                        case 2:
                        ListarProcessos();
                        break;
                        case 3:
                        ExcluirProcesso();
                        break;
                        default:
                            Console.WriteLine("Opção inválida");
                            Thread.Sleep(1000);
                            break;

                    }
                }
            }
        }
        private void CadastrarProcesso()
        {
            Console.Clear();
            Console.WriteLine("--- NOVO PROCESSO ---");

            Console.WriteLine("Nome do Processo (Ex: OP-001): ");
            string nome = Console.ReadLine()!;

            Console.Write("Tipo de Processo (Exe, Exe): ");
            string tipo = Console.ReadLine()!;

            Console.Write("Tempo Estimado (em horas, ex: 2,5): ");
            if (!double.TryParse(Console.ReadLine(), out double tempo)) tempo = 1.0;
            
            Console.Write("Data de Entrega (dd/mm/aaaa): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime entrega)) entrega = DateTime.Now.AddDays(7);

            var novoProcesso = new Processo(nome, tempo, entrega, tipo);
            _proc.Save(novoProcesso);

            Console.WriteLine("\nProcesso cadastrado com sucesso!");
        }

        private void ListarProcessos()
        {
            var lista = _proc.GetAll();
            Console.WriteLine("-- Lista dos Processos --");
            foreach (var pro in lista)
            {
                Console.WriteLine($"ID: {pro.Id} | Nome: {pro.Nome} | Status: {(pro.Ativa ? "Ativo" : "Inativo")}");
            }
            AguardarTecla();
        }

        private void ExcluirOperador()
        {
            Console.Clear();
            Console.WriteLine("--- DESATIVAR PROCESSO ---");

            var processos = _proc.GetAll();
            if (processos.Count == 0)
            {
                Console.WriteLine("Nenhum processo cadastrado.");
                AguardarTecla();
                return;
            }

            foreach (var pro in processos)
            {
                Console.WriteLine($"ID: {pro.Id} | Nome: {pro.Nome} | Status: {(pro.Ativa ? "Ativo" : "Inativo")}");
            }

            Console.Write("\nDigite o ID exato do processo que deseja desativar: ");

            if (int.TryParse(Console.ReadLine(), out int idParaDesativar))
            {
                var processo = processos.FirstOrDefault(p => p.Id == idParaDesativar);
                if (processo != null)
                {
                    Console.Write($"\nTEM CERTEZA que deseja excluir '{idParaDesativar}'? (S/N): ");
                    string confirmacao = Console.ReadLine()?.ToUpper()!;

                    if (confirmacao == "S")
                    {
                        _proc.Update(processo);
                        Console.WriteLine("\nProcesso desativado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("\nOperação cancelada.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nErro: Esse processo não foi encontrado na lista.");
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









}