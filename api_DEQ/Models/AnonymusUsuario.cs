namespace api_DEQ.Models
{
    public class AnonymusUsuario
    {
        public int IdUsuario { get; set; }
        public string? UsuarioName { get; set; }
        public string Contrasenia { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdCliente { get; set; }
    }
}
