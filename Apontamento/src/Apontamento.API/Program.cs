using Apontamento.Domain.Interfaces;
using Apontamento.API;
using Apontamento.Infrastructure;

namespace Apontamento.API
{
    class Program
    {
        static void Main(string[] args)
        {

            IOperadorRepository opRepo = new OperadorRepository();
            IMaquinaRepository maqRepo = new MaquinaRepository();

            Menu menu = new Menu(opRepo, maqRepo);

            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                menu.ShowMenu();

                Console.Write("\nEscolha uma opção: ");
                string entrada = Console.ReadLine()!;

                if (int.TryParse(entrada, out int opcao))
                {
                    menu.ProcessarOpcao(opcao);
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                    Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                }
            }

        }

    }

}