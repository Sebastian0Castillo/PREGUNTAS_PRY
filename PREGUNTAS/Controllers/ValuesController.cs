using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PREGUNTAS.DataLayer.DB.Entities.Preguntas_Respuestas;
using PREGUNTAS.Interfaces.Preguntas_respuestas;

namespace PREGUNTAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly  IpreguntasService _preguntasService;

        ValuesController(IpreguntasService preguntasServices)
        {
            _preguntasService = preguntasServices;
        }

        [HttpPost("getpregunta")]
        public async Task<Preguntas?> Get(int id)
        {
            return await _preguntasService.GetPreguntas(id);
        }
    }
}
