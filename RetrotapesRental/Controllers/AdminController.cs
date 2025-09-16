using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Retrotapes.DAL.Data;
using Retrotapes.DAL.Models;
using Retrotapes.WEB.ViewModels;

namespace Retrotapes.WEB.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly SakilaDbContext _sakilaDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(
            ApplicationDbContext appDbContext,
            SakilaDbContext sakilaDbContext,
            UserManager<ApplicationUser> userManager)
        {
            _appDbContext = appDbContext;
            _sakilaDbContext = sakilaDbContext;
            _userManager = userManager;
        }

        // List all staff and their mapped users
        public IActionResult StaffUsers()
        {
            var staffList = _sakilaDbContext.staff.ToList();
            var userList = _userManager.Users.ToList();

            var viewModel = staffList.Select(staff => new StaffUserViewModel
            {
                Staff = staff,
                User = userList.FirstOrDefault(u => u.StaffId == staff.StaffId)
            }).ToList();

            return View(viewModel); // Pass the view model to the view
        }

        // Link an Identity user to a staff record
        [HttpPost]
        public async Task<IActionResult> LinkUserToStaff(string userId, int staffId)
        {
            var mapping = new UserStaffMap
            {
                AspNetUserId = userId,
                StaffId = staffId
            };
            _appDbContext.UserStaffMaps.Add(mapping);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("StaffUsers");
        }

        // Unlink user and staff
        [HttpPost]
        public async Task<IActionResult> UnlinkUserFromStaff(string userId, int staffId)
        {
            var mapping = _appDbContext.UserStaffMaps
                .FirstOrDefault(m => m.AspNetUserId == userId && m.StaffId == staffId);
            if (mapping != null)
            {
                _appDbContext.UserStaffMaps.Remove(mapping);
                await _appDbContext.SaveChangesAsync();
            }
            return RedirectToAction("StaffUsers");
        }

        // Create new staff (simplified example)
        [HttpGet]
        public IActionResult CreateStaff()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff(Staff model)
        {
            if (ModelState.IsValid)
            {
                _sakilaDbContext.staff.Add(model);
                await _sakilaDbContext.SaveChangesAsync();
                return RedirectToAction("StaffUsers");
            }
            return View(model);
        }

        // Create a new Identity user (simplified)
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Optionally add to Admin role, etc.
                    return RedirectToAction("StaffUsers");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
