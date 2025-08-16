namespace BolsaEmpleoModel.DTO
{
    public class Ciudadanos
    {
        public int IdCiudadano {  get; set; }
        public int TipoDocumento { get; set; }
        public int Cedula { get; set; }        
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Profesion { get; set; }
        public decimal AspiracionSalarial { get; set; }
        public string? CorreoElectronico { get; set; }

        public Ciudadanos()
        {
            IdCiudadano = 0;
            TipoDocumento = 0;
            Cedula = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            FechaNacimiento = DateTime.Now;
            Profesion = string.Empty;
            AspiracionSalarial = 0;
            CorreoElectronico = string.Empty;
        }
    }
}
