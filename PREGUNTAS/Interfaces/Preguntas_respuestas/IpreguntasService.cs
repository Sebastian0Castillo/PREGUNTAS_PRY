using PREGUNTAS.Datalayer.DB;
using PREGUNTAS.DataLayer.DTO.Preguntas;

namespace PREGUNTAS.Interfaces.Preguntas_respuestas
{
    public interface IpreguntasService
    {
        public Task<Pregunta?> GetPreguntas(int id);

        public Task<Pregunta?> CreatePregunta(RegPreguntaDto regpregunta);

        public Task<Pregunta?> UpdatePregunta(RegPreguntaDto regPregunta);

        public Task<Pregunta?> DeletePregunta(int id);

    }
}
