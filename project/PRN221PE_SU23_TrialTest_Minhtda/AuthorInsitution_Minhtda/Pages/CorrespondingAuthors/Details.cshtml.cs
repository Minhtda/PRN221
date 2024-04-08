using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace AuthorInsitution_Minhtda.Pages.CorrespondingAuthors
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObject.Models.AuthorInstitution2023DBContext _context;

        public DetailsModel(BusinessObject.Models.AuthorInstitution2023DBContext context)
        {
            _context = context;
        }

      public CorrespondingAuthor CorrespondingAuthor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CorrespondingAuthors == null)
            {
                return NotFound();
            }

            var correspondingauthor = await _context.CorrespondingAuthors.FirstOrDefaultAsync(m => m.AuthorId == id);
            if (correspondingauthor == null)
            {
                return NotFound();
            }
            else 
            {
                CorrespondingAuthor = correspondingauthor;
            }
            return Page();
        }
    }
}
