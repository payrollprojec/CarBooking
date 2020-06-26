using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarBooking.Data;
using CarBooking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarBooking.Pages.Home
{
    [Authorize]
    [IgnoreAntiforgeryToken(Order = 1001)]

    public class CreateModel : PageModel
    {
        private readonly CarBooking.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(CarBooking.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public string Start { get; set; }
        [BindProperty]

        public string Stop { get; set; }
        public List<SelectListItem> Cars { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            //ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            //ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id");
            var Car = _context.Car.ToList();
            Cars = new List<SelectListItem>();
            foreach (var c in Car)
            {
                Cars.Add(new SelectListItem { Value = c.Id.ToString(), Text = c.Manufacturer + " - " + c.CarModel });
            }
            ApplicationUser = await _userManager.GetUserAsync(User);
            return Page();
        }

        [BindProperty]
        public CarBookingz CarBookingz { get; set; }
        public string Manufacturer { get; private set; }
        public string CarModel { get; private set; }
        public ApplicationUser ApplicationUser { get; private set; }
        public Car Car { get; private set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("CarBookingz.ApplicationUser");
            ModelState.Remove("CarBookingz.Car");
            if (!ModelState.IsValid)
            {
                var Car = _context.Car.ToList();
                Cars = new List<SelectListItem>();
                foreach (var c in Car)
                {
                    Cars.Add(new SelectListItem { Value = c.Id.ToString(), Text = c.Manufacturer + " - " + c.CarModel });
                }
                ApplicationUser = await _userManager.GetUserAsync(User);
                return Page();
            }
            int pending = await _context.Status.Where(s => s.Name == "Pending").Select(s => s.Id).SingleOrDefaultAsync();
            Car = await _context.Car.Where(c => c.Id == CarBookingz.CarId).SingleOrDefaultAsync();
            CarBookingz.StatusId = pending;
            CarBookingz.CreatedDate = DateTime.Now.Date;
            CarBookingz.TotalPrice = Car.DailyRate * ((CarBookingz.EndDate - CarBookingz.StartDate).Days + 1);
            _context.CarBookingz.Add(CarBookingz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public class AvailCar
        {
            public int Id{ get; set; }
            public string Name { get; set; }
        }

    }
}
