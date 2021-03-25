using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication1
{
    public partial class Voucher
    {
        public int Id { get; set; }
        [Display(Name = "Назва туру")]
        public int TourId { get; set; }
        [Display(Name = "ID туриста")]
        public int TouristId { get; set; }
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }
        [Display(Name = "Дата купівлі")]
        public DateTime BuyDate { get; set; }
        [Display(Name = "Дата початку туру")]
        public DateTime StartDate { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual Tourist Tourist { get; set; }
    }
}
