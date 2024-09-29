using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaWebAPI.Model
{
    public class Libro
    {
        [Key]
        public string ISBN { get; set; }

        [MaxLength(50)]
        public string Titulo { get; set; }

        //ForeignKey
        [ForeignKey("AutorId")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        public DateTime Fecha_publicacion { get; set; }

        //ForeignKey
        [ForeignKey("GeneroId")]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
