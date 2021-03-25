using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication1
{
    public partial class Manager
    {
        public Manager()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }
        [Display(Name = "І'мя")]
        public string FirstName { get; set; }
        [Display(Name = "По-батькові")]
        public string SurName { get; set; }
        [Display(Name = "Пошта")]
        public string Email { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
