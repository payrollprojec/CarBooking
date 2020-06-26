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
using Microsoft.AspNetCore.Identity;

namespace CarBooking.Pages.Bookings
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly CarBooking.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(CarBooking.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ApplicationUser ApplicationUser { get; private set; }
        public IList<CarBookingz> CarBookingz { get; set; }
        [BindProperty]
        public string SelectedAction { get; set; }
        [BindProperty]
        public int SelectedId { get; set; }
        public async Task OnGetAsync()
        {
            ApplicationUser = await _userManager.GetUserAsync(User);
            CarBookingz = await _context.CarBookingz
                .Include(c => c.ApplicationUser)
                .Include(c => c.Car)
                .Include(c => c.Status)
                .ToListAsync();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            int StatusId = await _context.Status.Where(s => s.Name == SelectedAction).Select(s => s.Id).SingleOrDefaultAsync();
            var CarBoo = await _context.CarBookingz.Where(cb => cb.Id == SelectedId).SingleOrDefaultAsync();
            if (CarBoo == null) return NotFound();
            CarBoo.StatusId = StatusId;
            _context.CarBookingz.Update(CarBoo);
            await _context.SaveChangesAsync();
            return Redirect("/Bookings/Index");
        }
    }
}
