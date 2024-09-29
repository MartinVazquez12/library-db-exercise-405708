using System.ComponentModel.DataAnnotations;

namespace LibreriaWebAPI.Model
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        [MaxLength(50)]
        public string DescripcionAutor { get; set; }

        //Lista usada para la relacion
        public List<Libro> Libros { get; set; }
    }
}

