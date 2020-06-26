using System;
using System.Collections.Generic;
using System.Text;
using CarBooking.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarBooking.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CarBooking.Models.Car> Car { get; set; }
        public DbSet<CarBooking.Models.Status> Status { get; set; }
        public DbSet<CarBooking.Models.CarBookingz> CarBookingz { get; set; }
    }
}
