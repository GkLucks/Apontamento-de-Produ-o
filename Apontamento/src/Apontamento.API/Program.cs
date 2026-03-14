using Apontamento.Domain.Interfaces;
using Apontamento.API;
using Apontamento.Infrastructure;

IOperadorRepository opRepo = new OperadorRepository();
IMaquinaRepository maqRepo = new MaquinaRepository();
Menu menu = new Menu(opRepo, maqRepo);

bool continuar = true;

while (continuar)
{
    
    Console.Clear();
    menu.ShowMenu();

    Console.Write("\nEscolha uma opção: ");
    string entrada = Console.ReadLine() ?? "";

    if (int.TryParse(entrada, out int opcao))
    {
        menu.ProcessarOpcao(opcao);

        if(opcao != 4)
        {
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
    else
    {
        Console.WriteLine("Por favor, digite um número válido.");
        Thread.Sleep(1000);
    }
}