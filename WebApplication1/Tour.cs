using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication1
{
    public partial class Tour
    {
        public Tour()
        {
            Vouchers = new HashSet<Voucher>();
        }

        public int Id { get; set; }
        [Display(Name = "Назва туру")]
        public string TourName { get; set; }
        [Display(Name = "Час туру")]
        public int TourDuration { get; set; }
        [Display(Name = "ID менеджера")]
        public int ManagerId { get; set; }
        [Display(Name = "ID готелю")]
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
