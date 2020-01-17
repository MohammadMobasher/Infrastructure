using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTO.Promotion.BankAnnualPromotion
{
    public class BankAnnualPromotionDTO
    {

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
