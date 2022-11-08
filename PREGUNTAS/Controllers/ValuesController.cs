using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PREGUNTAS.Datalayer.DB;
using PREGUNTAS.DataLayer.DTO.Preguntas;
using PREGUNTAS.DataLayer.DTO.Respuestas;
using PREGUNTAS.Interfaces.Preguntas_respuestas;

namespace PREGUNTAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IpreguntasService _preguntasService;
        private readonly IRespuestasService _respuestasService;
        private readonly IMapper _map;

        public ValuesController(IpreguntasService preguntasServices, IMapper mapper, IRespuestasService respuestasServices)
        {
            _preguntasService = preguntasServices;
            _respuestasService = respuestasServices;
            _map = mapper;
        }


        [HttpGet("Pregunta/{id}")]
        public async Task<Pregunta?> Get(int id)
        {
            return await _preguntasService.GetPreguntas(id);
        }

        [HttpPost("addPregunta")]

        public async Task<Pregunta?> create(RegPreguntaDto pregunta)
        {
            //Pregunta Mainpregunta = _map.Map<Pregunta>(pregunta);

            return await _preguntasService.CreatePregunta(pregunta);
        }

        [HttpPut("UpdatePregunta")]

        public async Task<Pregunta?> put(RegPreguntaDto pregunta)
        {
            return await _preguntasService.UpdatePregunta(pregunta);
        }

        [HttpDelete("Pregunta/{id:int}")]

        public async Task<Pregunta?> Delete(int id)
        {
            var DeletePregunta = await _preguntasService.GetPreguntas(id);

            return await _preguntasService.DeletePregunta(id);
        }


        //Respuestas

        [HttpGet("Respuesta/{id}")]
        public async Task<Respuesta?> obtener(int id)
        {
            return await _respuestasService.GetRespuesta(id);
        }

        [HttpPost("addRespuesta")]

        public async Task<Respuesta?> crear(RegRespuestaDto respuesta)
        {
            Respuesta Mainrespuesta = _map.Map<Respuesta>(respuesta);

            return await _respuestasService.CreateRespuesta(respuesta);
        }

        [HttpPut("UpdateRespuesta")]

        public async Task<Respuesta?> actualizar(RegRespuestaDto respuesta)
        {
            return await _respuestasService.UpdateRespuesta(respuesta);
        }

        [HttpDelete("Respuesta/{id:int}")]

        public async Task<Respuesta?> Eliminar(int id)
        {
            var DeleteRespuesta = await _respuestasService.GetRespuesta(id);

            return await _respuestasService.DeleteRespuesta(id);
        }

    }
}
