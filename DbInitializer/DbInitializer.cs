using AppointmentScheduling.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void Initialize()
        {
            try
            {
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate(); //automatically push all the migrations
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            if (_db.Roles.Any(x => x.Name == Utility.Helper.Admin)) 
                return;

            _roleManager.CreateAsync(new IdentityRole(Utility.Helper.Admin)).GetAwaiter().GetResult();
            if (!_db.Roles.Any(x => x.Name == Utility.Helper.Doctor))
                _roleManager.CreateAsync(new IdentityRole(Utility.Helper.Doctor)).GetAwaiter().GetResult();
            if (!_db.Roles.Any(x => x.Name == Utility.Helper.Patient))
                _roleManager.CreateAsync(new IdentityRole(Utility.Helper.Patient)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                Name = "Root Admin"
            }, 
            "Adm1n@").GetAwaiter().GetResult();

            ApplicationUser user = _db.Users.FirstOrDefault(u => u.Email == "admin@gmail.com");
            _userManager.AddToRoleAsync(user, Utility.Helper.Admin).GetAwaiter().GetResult();
        }
    }
}
