using Microsoft.EntityFrameworkCore;
using CNDer.Models;

namespace CNDer.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
    : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servidor> Servidores { get; set; }
        public DbSet<Anexo> Anexos { get; set; }
        public DbSet<Objeto> Objetos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

    }
}