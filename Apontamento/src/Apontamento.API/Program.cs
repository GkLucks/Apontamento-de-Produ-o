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
        if (opcao == 4) 
        { 
           menu.ProcessarOpcao(opcao); 
        }

        menu.ProcessarOpcao(opcao);
        
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Por favor, digite um número válido.");
        Thread.Sleep(1000);
    }
}