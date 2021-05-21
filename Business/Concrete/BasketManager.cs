using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class BasketManager : IBasketService
    {
        private IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public IDataResult<List<Basket>> GetAll()
        {
            return new SuccessDataResult<List<Basket>>(_basketDal.GetAll());
        }

        public IDataResult<Basket> Get(int id)
        {
            return new SuccessDataResult<Basket>(_basketDal.Get(b => b.Id == id));
        }

        public IResult Add(Basket entity)
        {
            _basketDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Basket entity)
        {
            _basketDal.Delete(entity);
            return new SuccessResult(Messages.BasketDeleted);
        }

        public IResult Update(Basket entity)
        {
            _basketDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<List<BasketDto>> GetAllDetailsByUser(int userId)
        {
            return new SuccessDataResult<List<BasketDto>>(_basketDal.GetAllBasketDetails(b => b.UserId == userId));
        }

        public IResult DeleteByUser(int userId)
        {
            var baskets = _basketDal.GetAll(b => b.UserId == userId);
            foreach (var basket in baskets)
            {
                _basketDal.Delete(basket);
            }

            return new SuccessResult();
        }
    }
}