using System.Reflection;
using SimpleWebApp.BusinessLogic.Abstract;

namespace SimpleWebApp.BusinessLogic
{
    public class MyMapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
        {
            if (source == null)
            {
                return default(TDestination);
            }

            const BindingFlags publicInstanceFlags = BindingFlags.Instance | BindingFlags.Public;
            TDestination destination = new TDestination();
            PropertyInfo[] sourceProperties = source.GetType().GetProperties(publicInstanceFlags);           

            foreach (var sourceProperty in sourceProperties)
            {
                if (!sourceProperty.CanRead)
                {
                    continue;
                }

                PropertyInfo destProperty = destination.GetType().GetProperty(sourceProperty.Name, publicInstanceFlags);

                if (destProperty != null && destProperty.PropertyType == sourceProperty.PropertyType)
                {
                    destProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }

            return destination;
        }
    }
}
