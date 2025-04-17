using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The_voice_of_geeta.DATA;
using System.Text;
using OfficeOpenXml; // for Excel export
using System.IO;

namespace The_voice_of_geeta.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly DataContext _context;


        public AdminController(DataContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            int activeUserCount = _context.Users.Count(u => u.IsActive); // Assuming your DbSet is called Users
            ViewBag.ActiveUsers = activeUserCount;

            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
        public async Task<IActionResult> ActiveUsers()
        {
            // Fetching active users from the database
            var activeUsers = await _context.Users
                .Where(u => u.IsActive) // Only active users
                .ToListAsync();

            // Passing the active users list to the view
            return View(activeUsers);
        }
        // Action to delete a user
        [HttpPost]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            // Optionally, you can also soft delete by setting IsActive = false, or simply delete
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            // Redirect back to the ActiveUsers page after deleting
            return RedirectToAction("ActiveUsers");
        }
        [HttpGet]
        public async Task<IActionResult> ExportToCsv()
        {
            var users = await _context.Users.ToListAsync();

            var csv = new StringBuilder();
            csv.AppendLine("Username,Email,Registration Date,Status");

            foreach (var user in users)
            {
                csv.AppendLine($"{user.Username},{user.Email},{user.CreatedAt:yyyy-MM-dd},{(user.IsActive ? "Active" : "Inactive")}");
            }

            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            return File(bytes, "text/csv", "ActiveUsers.csv");
        }

        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            var users = await _context.Users.ToListAsync();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Users");

                // Headers
                worksheet.Cells[1, 1].Value = "Username";
                worksheet.Cells[1, 2].Value = "Email";
                worksheet.Cells[1, 3].Value = "Registration Date";
                worksheet.Cells[1, 4].Value = "Status";

                // Data
                int row = 2;
                foreach (var user in users)
                {
                    worksheet.Cells[row, 1].Value = user.Username;
                    worksheet.Cells[row, 2].Value = user.Email;
                    worksheet.Cells[row, 3].Value = user.CreatedAt.ToString("yyyy-MM-dd");
                    worksheet.Cells[row, 4].Value = user.IsActive ? "Active" : "Inactive";
                    row++;
                }

                var stream = new MemoryStream(package.GetAsByteArray());
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ActiveUsers.xlsx");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ActiveUsers(string? search, string? status)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(u =>
                    u.Username.Contains(search) || u.Email.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                if (status == "active") query = query.Where(u => u.IsActive);
                else if (status == "inactive") query = query.Where(u => !u.IsActive);
            }

            var users = await query.ToListAsync();

            // Pass search state to view
            ViewBag.Search = search;
            ViewBag.Status = status;

            return View(users);
        }

    }
}
