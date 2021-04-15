using System.Collections.Generic;
using Business.Abstract;
using Business.Constant.Message;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        private ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(),Messages.CardGetAll);
        }

        public IResult Add(Card business)
        {
            _cardDal.Add(business);
            return new SuccessResult(Messages.CardAdded);


        }

        public IResult Delete(Card business)
        {
            _cardDal.Delete(business);
            return new SuccessResult(Messages.CardDeleted);

        }

        public IDataResult<Card> GetById(int id)
        {

            return new SuccessDataResult<Card>(_cardDal.Get(c => c.CustomerId == id), Messages.CardGetById);
        }
    }
}