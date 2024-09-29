using LibreriaWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LibreriaWebAPI.Context
{
    public class LibroDbContext : DbContext
    {
        public LibroDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Libro> libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //INSERTS

            modelBuilder.Entity<Genero>().HasData(
                 new Genero { IdGenero = 1, DescripcionGenero = "terror" },
                 new Genero { IdGenero = 2, DescripcionGenero = "policia"},
                 new Genero { IdGenero = 3, DescripcionGenero = "historia" },
                 new Genero { IdGenero = 4, DescripcionGenero = "romantico" },
                 new Genero { IdGenero = 5, DescripcionGenero = "ficcion" }
                 );
      
            modelBuilder.Entity<Autor>().HasData(
                new Autor { IdAutor = 1, DescripcionAutor = "Garcia Marquez" },
                new Autor { IdAutor = 2, DescripcionAutor = "JK Rowling" },
                new Autor { IdAutor = 3, DescripcionAutor = "Stephen King" },
                new Autor { IdAutor = 4, DescripcionAutor = "William Shakespeare" },
                new Autor { IdAutor = 5, DescripcionAutor = "Cervantes" }
                );

            //Establesco las relaciones correctamente
            modelBuilder.Entity<Libro>().HasOne(l=>l.Genero)
                                        .WithMany(g=>g.Libros)
                                        .HasForeignKey(l => l.GeneroId);

            modelBuilder.Entity<Libro>().HasOne(l => l.Autor)
                                        .WithMany(a => a.Libros)
                                        .HasForeignKey(l => l.AutorId);


        }
    }
}
