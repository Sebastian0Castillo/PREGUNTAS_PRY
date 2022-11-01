using AutoMapper;
using System.Text;

namespace PREGUNTAS.Maps
{
    public class MapperMap : Profile
    {
        public MapperMap()
        {

                    byte[] salt = Encoding.ASCII.GetBytes(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Appsettings:UserSaltKey").Value);

        }
    }
}
