using LocacaoGama.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoGama.Context
{
    public class DBContext : DbContext
   
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options){ }



        public DbSet<Modelo> Modelos { get; set; } = default!;

        public DbSet<Marca> Marcas { get; set; } = default!;

        public DbSet<Carro> Carros { get; set; } = default!;

        public DbSet<Cliente> Clientes { get; set; } = default!;

        public DbSet<Pedido> Pedidos { get; set; } = default!;

        public DbSet<Configuracao> Configuracao { get; set; } = default!;

    }
}
