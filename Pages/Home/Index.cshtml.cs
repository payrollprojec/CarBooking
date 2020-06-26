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

namespace CarBooking.Pages.Home
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
        public IList<CarBookingz> CarBookingz { get;set; }

        public async Task OnGetAsync()
        {
            ApplicationUser = await _userManager.GetUserAsync(User);
            CarBookingz = await _context.CarBookingz
                .Include(c => c.ApplicationUser)
                .Include(c => c.Car)
                .Include(c => c.Status)
                .Where(c => c.ApplicationUser == ApplicationUser)
                .ToListAsync();
        }
    }
}
