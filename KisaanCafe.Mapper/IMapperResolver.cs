using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
namespace KisaanCafe.Mapper
{

    public interface IMapperResolver
    {
        TDestination Resolve<TSource, TDestination>(TSource source) where TSource : class where TDestination : class;

        Task<TDestination> ResolveAsync<TSource, TDestination>(TSource source) where TSource : class where TDestination : class;
    }
}
