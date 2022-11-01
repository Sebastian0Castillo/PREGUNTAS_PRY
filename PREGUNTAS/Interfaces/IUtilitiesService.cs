

namespace PREGUNTAS.Interfaces
{
    public interface IUtilitiesService
    {
        public void Init<Tsource>();

        public TSource Use<TSource>();
    }
}
