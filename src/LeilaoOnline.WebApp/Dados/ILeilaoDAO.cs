using LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDAO
    {
        void Alterar(Leilao leilao);
        Leilao BurcarPorId(int id);
        IEnumerable<Categoria> BuscarCategorias();
        IEnumerable<Leilao> BuscarLeiloes();
        void Excluir(Leilao leilao);
        void Incluir(Leilao leilao);
    }
}