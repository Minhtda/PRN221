using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;

namespace AuthorInsitution_Minhtda.Pages.CorrespondingAuthors
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.Models.AuthorInstitution2023DBContext _context;

        public CreateModel(BusinessObject.Models.AuthorInstitution2023DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InstitutionId"] = new SelectList(_context.InstitutionInformations, "InstitutionId", "InstitutionName");
            return Page();
        }

        [BindProperty]
        public CorrespondingAuthor CorrespondingAuthor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.CorrespondingAuthors == null || CorrespondingAuthor == null)
            {
                ViewData["InstitutionId"] = new SelectList(_context.InstitutionInformations, "InstitutionId", "InstitutionName");

                return Page();
            }
            if (CorrespondingAuthor.AuthorBirthday.Year>2023||1901>CorrespondingAuthor.AuthorBirthday.Year)
            {
                ViewData["InstitutionId"] = new SelectList(_context.InstitutionInformations, "InstitutionId", "InstitutionName");
                return Page();
            }
            if (CorrespondingAuthor.AuthorName.Length<6|| CorrespondingAuthor.AuthorName.Length>100)
            {
                ViewData["InstitutionId"] = new SelectList(_context.InstitutionInformations, "InstitutionId", "InstitutionName");
                return Page();
            }
            _context.CorrespondingAuthors.Add(CorrespondingAuthor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
