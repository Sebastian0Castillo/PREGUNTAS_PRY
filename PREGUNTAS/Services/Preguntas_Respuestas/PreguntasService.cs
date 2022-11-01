using PREGUNTAS.DataLayer.DB.Entities.Preguntas_Respuestas;
using PREGUNTAS.DataLayer.DB.Context;
using PREGUNTAS.Interfaces.Preguntas_respuestas;

namespace PREGUNTAS.Services.Preguntas_Respuestas
{
    public class PreguntasService : IpreguntasService
    {
        private readonly DB _Context;
        private readonly IConfiguration _config;

        public PreguntasService(IConfiguration config, DB context)
        { 
        _config = config;
        _Context = context;
        
        }

        public async Task<Preguntas?> GetPreguntas(int id)
        {
            Preguntas? output = await _Context.preguntas.FindAsync(id);

            return output;
        }
      

    }
}
