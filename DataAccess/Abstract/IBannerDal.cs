using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //Dal'ların referansınu tutuyoruz. İnterface'i...
    public interface IBannerDal : IEntityRepository<Banner>
    {
        
    }
}