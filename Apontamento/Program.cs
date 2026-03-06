namespace Apontamento
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IDataManager dataManager = new DataManager();
            IMenu menu = new Menu(dataManager);

        bool continuar = true;

         while (continuar)
    {
        Console.Clear(); 
        menu.ShowMenu();
        
        Console.Write("\nEscolha uma opção: ");
        string entrada = Console.ReadLine();

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