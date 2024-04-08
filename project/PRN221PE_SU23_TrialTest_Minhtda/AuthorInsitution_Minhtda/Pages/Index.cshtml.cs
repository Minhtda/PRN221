using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace AuthorInsitution_Minhtda.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public MemberAccount Account { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public string msg { get; set; }
        private readonly BusinessObject.Models.AuthorInstitution2023DBContext _context;
        public IndexModel(BusinessObject.Models.AuthorInstitution2023DBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                var acc = _context.MemberAccounts.FirstOrDefault(x => x.EmailAddress == Account.EmailAddress && x.MemberPassword == Account.MemberPassword);

                if (acc is not null)
                {
                    if (acc.MemberRole == 1)
                    {
                        return RedirectToPage("./CorrespondingAuthors/Index");
                    }
                }
                msg = "Invalid Account";
                return Page();
                
            }
            catch (Exception ex)
            {

            }

            return Page();

        }
    }
}
