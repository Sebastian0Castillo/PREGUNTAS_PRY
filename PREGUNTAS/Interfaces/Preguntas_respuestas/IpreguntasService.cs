using PREGUNTAS.DataLayer.DB.Entities.Preguntas_Respuestas;

namespace PREGUNTAS.Interfaces.Preguntas_respuestas
{
    public interface IpreguntasService
    {
        public Task<Preguntas?> GetPreguntas(int id);
    }
}
