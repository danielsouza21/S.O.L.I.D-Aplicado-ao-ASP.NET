using LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace LeilaoOnline.WebApp.Dados.EfCore
{
    //DAO -> DataAcessObject
    public class LeilaoDAO : ILeilaoDAO
    {
        AppDbContext _context;

        public LeilaoDAO()
        {
            _context = new AppDbContext();  //Sem injeção de dependência
        }

        public IEnumerable<Categoria> BuscarCategorias()
        {
            return _context.Categorias.ToList();
        }

        public Leilao BurcarPorId(int id)
        {
            return _context.Leiloes.First(l => l.Id == id);
        }

        public IEnumerable<Leilao> BuscarLeiloes()
        {
            return _context.Leiloes.Include(l => l.Categoria).ToList();
            //.Include -> Carregamento adiantado de outra tabela (Join)
        }

        public void Incluir(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        public void Alterar(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        public void Excluir(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
