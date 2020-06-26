using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBooking.Data;
using CarBooking.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarBooking.Pages.Home
{
    [Authorize]

    public class DeleteModel : PageModel
    {
        private readonly CarBooking.Data.ApplicationDbContext _context;

        public DeleteModel(CarBooking.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarBookingz CarBookingz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarBookingz = await _context.CarBookingz
                .Include(c => c.ApplicationUser)
                .Include(c => c.Car)
                .Include(c => c.Status).FirstOrDefaultAsync(m => m.Id == id);

            if (CarBookingz == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarBookingz = await _context.CarBookingz.FindAsync(id);

            if (CarBookingz != null)
            {
                _context.CarBookingz.Remove(CarBookingz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
