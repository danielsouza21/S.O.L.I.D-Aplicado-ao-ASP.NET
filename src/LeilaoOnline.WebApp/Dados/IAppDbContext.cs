using LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LeilaoOnline.WebApp.Dados
{
    public interface IAppDbContext
    {
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Leilao> Leiloes { get; set; }
    }
}