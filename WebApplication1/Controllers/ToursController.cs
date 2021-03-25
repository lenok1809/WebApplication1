using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class ToursController : Controller
    {
        private readonly TourAgencyContext _context;

        public ToursController(TourAgencyContext context)
        {
            _context = context;
        }

        // GET: Tours
        public async Task<IActionResult> Index(int? id, string name)
        {
            if (id == null)
                return RedirectToAction("Hotels", "Index");

            ViewBag.HotelId = id;
            ViewBag.HotelName = name;
            var toursByHotel = _context.Tours.Where(c => c.HotelId == id).Include(c => c.Hotel);
           
            return View(await toursByHotel.ToListAsync());
        }

        // GET: Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .Include(t => t.Hotel)
                .Include(t => t.Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tour == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Vouchers", new { id = tour.Id, name = tour.TourName });
        }

        // GET: Tours/Create
        public IActionResult Create(int hotelId)
        {
            
            ViewBag.HotelId = hotelId;
            ViewBag.HotelName = _context.Hotels.Where(c => c.Id == hotelId).FirstOrDefault().HotelName;
            ViewData["ManegerId"] = new SelectList(_context.Managers, "Id", "Id");
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int hotelId ,[Bind("Id,TourName,TourDuration,ManegerId,HotelId")] Tour tour)
        {
            
            tour.HotelId = hotelId;

            if (ModelState.IsValid)
            {
                _context.Add(tour);
               // tour.Manager = _context.Managers.Find(tour.ManagerId);
               // tour.Hotel = _context.Hotels.Find(tour.HotelId);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Tours", new { id = hotelId, name = _context.Hotels.Where(c => c.Id == hotelId).FirstOrDefault().HotelName });
            }
            // ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "CountryName", city.CountryId);
            //return View(city);
            return RedirectToAction("Index", "Tours", new { id = hotelId, name = _context.Hotels.Where(c => c.Id == hotelId).FirstOrDefault().HotelName });
        }

        // GET: Tours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "HotelName", tour.HotelId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Email", tour.ManagerId);
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TourName,TourDuration,ManagerId,HotelId")] Tour tour)
        {
            if (id != tour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourExists(tour.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "HotelName", tour.HotelId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Email", tour.ManagerId);
            return View(tour);
        }

        // GET: Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .Include(t => t.Hotel)
                .Include(t => t.Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourExists(int id)
        {
            return _context.Tours.Any(e => e.Id == id);
        }
    }
}
