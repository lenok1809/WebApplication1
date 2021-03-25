using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication1
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        [Display(Name = "Назва країни")]
        public string CountryName { get; set; }
        [Display(Name = "Інформація про візу")]
        public string InfoVisa { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
