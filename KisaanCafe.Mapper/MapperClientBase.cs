using KisaanCafe.Mapper;

public abstract class MapperClientBase : IMapperClient
{
        private readonly IMapperResolver _mapper;

        public MapperClientBase(IMapperResolver mapper)
        {
            _mapper = mapper.ThrowIfNull(nameof(mapper));
        }
        public abstract ExecutingContext GetExecutingContext();

        public async Task<TDestination> MapAsync<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class
        {
            return await MapInternalAsync(source, async (source) => await _mapper.ResolveAsync<TSource, TDestination>(source)).ConfigureAwait(false);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        where TSource : class
        where TDestination : class
        {
            return MapInternal(source, (source) => _mapper.Resolve<TSource, TDestination>(source));
        }

    private TDestination MapInternal<TSource, TDestination>(TSource source, Func<TSource, TDestination> mapper)
       where TSource : class
      where TDestination : class
    {
        var executingContext = GetExecutingContext();
        try
        {
            return mapper(source);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    private async Task<TDestination> MapInternalAsync<TSource, TDestination>(TSource source, Func<TSource, Task<TDestination>> mapper)
        where TSource : class
        where TDestination : class
    {
        var executingContext = GetExecutingContext();
        try
        {
            return await mapper(source).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}

