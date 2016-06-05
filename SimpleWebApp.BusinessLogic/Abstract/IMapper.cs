namespace SimpleWebApp.BusinessLogic.Abstract
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source) where TDestination : new();
    }
}
