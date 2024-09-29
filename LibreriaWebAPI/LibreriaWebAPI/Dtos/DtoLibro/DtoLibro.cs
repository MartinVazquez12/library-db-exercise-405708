namespace LibreriaWebAPI.Dtos.DtoLibro
{
    public class DtoLibro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AutorId { get; set; }
        public DateTime Fecha_publicacion { get; set; }
       
        public string Genero { get; set; }
        public int GeneroId { get; set; } 
    }
}
