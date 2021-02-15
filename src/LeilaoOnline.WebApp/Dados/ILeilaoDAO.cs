using LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDAO : ICommand<Leilao>, IQuery<Leilao>
    {
        public IEnumerable<Categoria> BuscarCategorias();
    }
}