using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication1
{
    public partial class Hotel
    {
        public Hotel()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        [Display(Name = "Назва готелю")]
        public string HotelName { get; set; }
        [Display(Name = "Зірки")]
        public int Stars { get; set; }
        [Display(Name = "ID міста")]
        public int CityId { get; set; }
        [Display(Name = "Тип номеру")]
        public string RoomType { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
