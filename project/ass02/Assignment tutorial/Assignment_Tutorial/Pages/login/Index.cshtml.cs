using BussinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Repositories;

namespace Assignment_Tutorial.Pages.login
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public StaffAccount Account { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public string msg { get; set; }
        private readonly IStaffAccountRepository _staffAccountRepository;
        public IndexModel(IStaffAccountRepository staffAccountRepository)
        {
            _staffAccountRepository = staffAccountRepository;
        }
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                var acc = _staffAccountRepository.GetStaffAccountByEmail(Account.Hremail, Account.Hrpassword);

                if (acc is not null)
                {
                    return RedirectToPage("../DoctorInformations/Index");
                }
                else
                {
                    msg = "Invalid Account";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                
            }

            return Page();

        }
    }
}
