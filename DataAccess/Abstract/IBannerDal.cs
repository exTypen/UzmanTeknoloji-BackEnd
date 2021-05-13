using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //Dal'ların referansını tutuyoruz. İnterface'i...
    public interface IBannerDal : IEntityRepository<Banner>
    {
        
    }
}