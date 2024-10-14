using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Datos
{
    public class AlmacenContext : DbContext
    {
        public AlmacenContext()
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Entidades.Categoria> Categorias { get; set; }
        //public DbSet<Grupo> Grupos { get; set; }
        //public DbSet<Permiso> Permisos { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<PedidoEstado> PedidosEstados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=HWNOTE163490\SQLEXPRESS;Initial Catalog=Almacen;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-KHKJ2OC;Initial Catalog=Almacen;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        }
    }
}
