namespace LibreriaWebAPI.Dtos.DtoLibro
{
    public class DtoLibroPost
    {
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public DateTime Fecha_publicacion { get; set; }
        public int GeneroId { get; set; }
    }
}
