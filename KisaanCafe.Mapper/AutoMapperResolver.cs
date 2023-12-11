using AutoMapper;
using KisaanCafe.Mapper;

    public class AutoMapperResolver : IMapperResolver
    {
        private readonly IMapper _mapper;

        public AutoMapperResolver(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Resolve<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public async Task<TDestination> ResolveAsync<TSource, TDestination>(TSource source)
            where TSource : class
            where TDestination : class
        {
            return await Task.Run<TDestination>(() => _mapper.Map<TSource, TDestination>(source)).ConfigureAwait(false);
        }
    }

