using AutoMapper;
using PREGUNTAS.Datalayer.DB;
using PREGUNTAS.DataLayer.DTO.Preguntas;
using PREGUNTAS.DataLayer.DTO.Respuestas;
using System.Text;

namespace PREGUNTAS.Maps
{
    public class MapperMap : Profile
    {
        public MapperMap()
        {
            CreateMap<Pregunta, RegPreguntaDto>()
                .ReverseMap();

            CreateMap<Respuesta, RegRespuestaDto>()
                .ReverseMap();
        }
    }
}
