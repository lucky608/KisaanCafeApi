using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
namespace KisaanCafe.Mapper
{
    public interface IMapperClient
    {
        Task<TDestination> MapAsync<TSource, TDestination>(TSource source) where TSource : class where TDestination : class;

        TDestination Map<TSource, TDestination>(TSource source) where TSource : class where TDestination : class;
       // IMapperClient? ThrowIfNull(string v);
    }
}