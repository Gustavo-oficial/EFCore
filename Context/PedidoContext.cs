using Microsoft.EntityFrameworkCore;
using ORM.EFCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM.EFCore
{
    public class PedidoContext : DbContext
    {
        public DbSet<PedidoItem> PedidoItem { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=loja;User ID=sa;Password=sa132");

            base.OnConfiguring(optionsBuilder);
        }
    }
}

