using AutoMapper;
using PREGUNTAS.Datalayer.DB;
using PREGUNTAS.DataLayer.DB.Context;
using PREGUNTAS.DataLayer.DTO.Preguntas;
using PREGUNTAS.Interfaces.Preguntas_respuestas;
using Microsoft.AspNetCore.Mvc;

namespace PREGUNTAS.Services.Preguntas_Respuestas
{
    public class PreguntasService : IpreguntasService
    {
        private readonly DB _Context;
        private readonly IMapper _maper;
        private readonly IConfiguration _config;

        public PreguntasService(IConfiguration config, DB context,IMapper mapper)
        { 
        _config = config;
        _Context = context;
        _maper = mapper;
        }

        public async Task<Pregunta?> GetPreguntas(int id)
        {
            Pregunta? output = await _Context.preguntas.FindAsync(id);

            return output;
        }

        public async Task<Pregunta?> CreatePregunta(RegPreguntaDto regPregunta)
        {
            Pregunta pregunta = _maper.Map<Pregunta>(regPregunta);

            _Context.preguntas.Add(pregunta);
            await _Context.SaveChangesAsync();
            return pregunta;
        
        }

        public async Task<Pregunta?> UpdatePregunta(RegPreguntaDto regPregunta)
        {
            Pregunta pregunta = _maper.Map<Pregunta>(regPregunta);
            _Context.preguntas.Update(pregunta);
            await _Context.SaveChangesAsync();
            return pregunta;

        }
        public async Task<Pregunta?> DeletePregunta(int id)
        {

            var result = await _Context.preguntas
            .FirstOrDefaultAsync(e => e.Id == id);

            if (result != null)
            {
                _Context.preguntas.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }

            return null;

        }

    }
}
