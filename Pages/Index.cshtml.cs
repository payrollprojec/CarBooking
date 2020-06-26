﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarBooking.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CarBooking.Data.ApplicationDbContext _context;

        public IndexModel(CarBooking.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
        }
    }
}
