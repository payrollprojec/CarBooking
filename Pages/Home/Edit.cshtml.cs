using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarBooking.Data;
using CarBooking.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarBooking.Pages.Home
{
    [Authorize]

    public class EditModel : PageModel
    {
        private readonly CarBooking.Data.ApplicationDbContext _context;

        public EditModel(CarBooking.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarBookingz CarBookingz { get; set; }
        public List<SelectListItem> Cars { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarBookingz = await _context.CarBookingz
                .Include(c => c.ApplicationUser)
                .Include(c => c.Status).FirstOrDefaultAsync(m => m.Id == id);

            if (CarBookingz == null)
            {
                return NotFound();
            }

            var Car = _context.Car.ToList();
            Cars = new List<SelectListItem>();
            foreach (var c in Car)
            {
                Cars.Add(new SelectListItem { Value = c.Id.ToString(), Text = c.Manufacturer + " - " + c.CarModel });
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var Car = await _context.Car.Where(c => c.Id == CarBookingz.CarId).SingleOrDefaultAsync();
            CarBookingz.TotalPrice = Car.DailyRate * ((CarBookingz.EndDate - CarBookingz.StartDate).Days + 1);
            CarBookingz.CreatedDate = DateTime.Now.Date;

            _context.Attach(CarBookingz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarBookingzExists(CarBookingz.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarBookingzExists(int id)
        {
            return _context.CarBookingz.Any(e => e.Id == id);
        }
    }
}
