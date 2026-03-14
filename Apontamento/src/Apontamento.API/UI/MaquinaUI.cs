using Apontamento.Domain.Aggregates;
using Apontamento.Domain.Interfaces;
using Apontamento.Infrastructure;

namespace Apontamento.API
{
    public class MaquinaUI
    {
        private readonly IMaquinaRepository _maq;
        public MaquinaUI(MaquinaRepository maq) => _maq = maq;

        public void MenuMaquina()
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
            _maq.Save(new Maquina { Nome = nomeMaquina });
            Console.WriteLine("Máquina salva!");
            AguardarTecla();
        }

        private void ListarMaquina()
        {
            var listaMaquinas = _maq.GetAll();
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

            var maquinas = _maq.GetAll();
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
                        _maq.Update(maquina);
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

        private void AguardarTecla()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


    }
}