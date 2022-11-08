using PREGUNTAS.Datalayer.DB;
using PREGUNTAS.DataLayer.DTO.Respuestas;

namespace PREGUNTAS.Interfaces.Preguntas_respuestas
{
    public interface IRespuestasService
    {
        public Task<Respuesta?> GetRespuesta(int id);

        public Task<Respuesta?> CreateRespuesta(RegRespuestaDto regpregunta);

        public Task<Respuesta?> UpdateRespuesta(RegRespuestaDto regPregunta);

        public Task<Respuesta?> DeleteRespuesta(int id);


    }
}
