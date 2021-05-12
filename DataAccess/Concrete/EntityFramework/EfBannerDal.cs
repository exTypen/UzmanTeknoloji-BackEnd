using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    //EntityFramework Dal class
    public class EfBannerDal : EfEntityRepositoryBase<Banner, UzmanContext>, IBannerDal
    {
        
    }
}