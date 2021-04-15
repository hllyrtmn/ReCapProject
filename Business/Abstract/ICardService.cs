using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICardService
    {
        IDataResult<List<Card>> GetAll();
        IResult Add(Card business);
        IResult Delete(Card business);
        IDataResult<Card> GetById(int id);
    }
}