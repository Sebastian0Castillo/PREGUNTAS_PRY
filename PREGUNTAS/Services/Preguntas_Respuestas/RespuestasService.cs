using AutoMapper;
using PREGUNTAS.Datalayer.DB;
using PREGUNTAS.DataLayer.DB.Context;
using PREGUNTAS.DataLayer.DTO.Preguntas;
using PREGUNTAS.Interfaces.Preguntas_respuestas;
using Microsoft.AspNetCore.Mvc;
using PREGUNTAS.DataLayer.DTO.Respuestas;

namespace PREGUNTAS.Services.Preguntas_Respuestas
{
    public class RespuestasService : IRespuestasService
    {
        private readonly DB _Context;
        private readonly IMapper _maper;
        private readonly IConfiguration _config;

        public RespuestasService(IConfiguration config, DB context,IMapper mapper)
        { 
        _config = config;
        _Context = context;
        _maper = mapper;
        }

        public async Task<Respuesta?> GetRespuesta(int id)
        {
            Respuesta? output = await _Context.respuestas.FindAsync(id);

            return output;
        }

        public async Task<Respuesta?> CreateRespuesta(RegRespuestaDto regRespuesta)
        {
            Respuesta respuesta = _maper.Map<Respuesta>(regRespuesta);

            _Context.respuestas.Add(respuesta);
            await _Context.SaveChangesAsync();
            return respuesta;
        
        }

        public async Task<Respuesta?> UpdateRespuesta(RegRespuestaDto regRespuesta)
        {
            Respuesta respuesta = _maper.Map<Respuesta>(regRespuesta);
            _Context.respuestas.Update(respuesta);
            await _Context.SaveChangesAsync();
            return respuesta;

        }
        public async Task<Respuesta?> DeleteRespuesta(int id)
        {

            var result = await _Context.respuestas
            .FirstOrDefaultAsync(e => e.Id == id);

            if (result != null)
            {
                _Context.respuestas.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }

            return null;

        }

    }
}
