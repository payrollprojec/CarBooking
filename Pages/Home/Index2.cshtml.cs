using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBooking.Data;
using CarBooking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBooking.Pages.Home
{
    [Authorize]
    public class IndexModel2 : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel2(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public ApplicationUser ApplicationUser { get; private set; }
        public List<CarBookingz> CarBookings { get; private set; }

        public async Task OnGetAsync()
        {
            ApplicationUser = await _userManager.GetUserAsync(User);
            CarBookings = await _context.CarBookingz.Where(cb => cb.ApplicationUser == ApplicationUser).ToListAsync();
        }
    }
}