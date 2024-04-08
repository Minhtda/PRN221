using BussinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieWeb.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly BussinessObject.Models.HospitalManagementDBContext _context;

        public RegisterModel(BussinessObject.Models.HospitalManagementDBContext context)
        {
            _context = context;
        }
        public string msg { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StaffAccount Account { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.StaffAccounts == null || Account == null)
            {
                return Page();
            }
            if (_context.StaffAccounts.Where(m => m.HraccountId == Account.HraccountId).FirstOrDefault() != null)
            {
                msg = "Invalid Account";
                return Page();
            }
            Account.StaffRole = 0;
            _context.StaffAccounts.Add(Account);
            await _context.SaveChangesAsync();
            msg = "Create account successfully";
            return Page();
        }
    }
}
