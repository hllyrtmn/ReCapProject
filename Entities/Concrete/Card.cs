using Core.Entities;

namespace Entities.Concrete
{
    public class Card : IEntity
    {
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string CustomerName { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
        public decimal Balance { get; set; }


    }
}