using Apontamento.Domain.Interfaces;

namespace Apontamento.API
{
    public interface IMenu
    {
        void ShowMenu();
        void ProcessarOpcao(int opcao);

    }
}