namespace PREGUNTAS.DataLayer.DTO.Respuestas
{
    public class RegRespuestaDto
    {
        public int Id { get; set; }
        public string? descripcion_respuesta { get; set; }
         = String.Empty;

        public int id_pregunta { get; set ; }
    }
}
