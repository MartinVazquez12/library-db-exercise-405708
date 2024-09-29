
using System.ComponentModel.DataAnnotations;

namespace LibreriaWebAPI.Model
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; }

        [MaxLength(50)]
        public string DescripcionGenero{ get; set; }

        //Lista usada para la relacion
        public List<Libro> Libros { get; set; }
    }
}

