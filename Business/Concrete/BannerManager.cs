using System;
using System.Collections.Generic;
using System.IO;
using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class BannerManager : IBannerService
    {
        private IBannerDal _bannerDal;

        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

        public IDataResult<List<Banner>> GetAll()
        {
            return new SuccessDataResult<List<Banner>>(_bannerDal.GetAll());
        }

        public IResult Add(IFormFile file,Banner banner)
        {
            banner.ImagePath = FileHelper.Add(file);
            banner.CreateDate = DateTime.Now;
            banner.Active = true;
            _bannerDal.Add(banner);
            return new SuccessResult();
        }

        public IResult Delete(Banner banner)
        {
            _bannerDal.Delete(banner);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, Banner banner)
        {
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) +
                          _bannerDal.Get(b => b.Id == banner.Id).ImagePath;
            
            banner.ImagePath = FileHelper.Update(oldPath, file);
            banner.CreateDate = DateTime.Now;
            banner.Active = true;
            _bannerDal.Update(banner);
            return new SuccessResult();
        }
    }
}