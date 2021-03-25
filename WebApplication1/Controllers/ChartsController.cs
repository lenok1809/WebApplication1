using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly TourAgencyContext _context;

        public ChartsController(TourAgencyContext context)
        {
            _context = context;

        }
        [HttpGet("JsonData")]

        public JsonResult JsonData()
        {
            var countries = _context.Countries.Include(c => c.Cities).ToList();

            List<object> catCity = new List<object>();
            catCity.Add(new[] { "Країни", "Кількість міст" });
            foreach(var c in countries)
            {
                catCity.Add(new object[] { c.CountryName, c.Cities.Count() });

            }
            return new JsonResult(catCity);
        }


        [HttpGet("TouristVouchers")]

        public JsonResult TouristVouchers()
        {
            var tourists = _context.Tourists.Include(c => c.Vouchers).ToList();

            List<object> catVoucher = new List<object>();
            catVoucher.Add(new[] { "Туристи", "Кількість ваучерів" });
            foreach (var c in tourists)
            {
                catVoucher.Add(new object[] { c.LastName, c.Vouchers.Count() });

            }
            return new JsonResult(catVoucher);
        }
    }
}
