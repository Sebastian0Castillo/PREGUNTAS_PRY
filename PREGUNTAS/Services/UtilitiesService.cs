using PREGUNTAS.Interfaces;
//using PREGUNTAS.Utilities;

namespace PREGUNTAS.Services
{
    public class UtilitiesService : IUtilitiesService
    {
        //private ResponsesUtilities? _responses;

        private Dictionary<Type, object> _properties;

        public UtilitiesService()
        {
            _properties = new Dictionary<Type, object>
            {
                //{ typeof(ResponsesUtilities), _responses }
            };
        }

        public void Init<TSource>()
        {

            foreach (var type in _properties.Keys)
            {
                if (typeof(TSource) == type)
                {
                    if (_properties[type] == null)
                    {
                        _properties[type] = Activator.CreateInstance(type);
                    }
                }
            }
        }

        public TSource Use<TSource>()
        {
            TSource output = default(TSource);

            foreach (var type in _properties.Keys)
            {
                if (typeof(TSource) == type)
                {
                    if (_properties[type] == null)
                    {
                        throw new InvalidOperationException("La instancia " + type.Name + " No se ha inicializado");
                    }

                    output = (TSource)_properties[type];
                }
            }
            return output;
        }
    }
}
