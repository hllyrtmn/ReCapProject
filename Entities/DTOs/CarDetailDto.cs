using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string ColorName { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
