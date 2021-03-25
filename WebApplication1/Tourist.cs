using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication1
{
    public partial class Tourist
    {
        public Tourist()
        {
            Vouchers = new HashSet<Voucher>();
        }

        public int Id { get; set; }
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }
        [Display(Name = "І'мя")]
        public string FirstName { get; set; }
        [Display(Name = "По-батькові")]
        public string SurName { get; set; }
        [Display(Name = "дата народження")]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Пошта")]
        public string Address { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
