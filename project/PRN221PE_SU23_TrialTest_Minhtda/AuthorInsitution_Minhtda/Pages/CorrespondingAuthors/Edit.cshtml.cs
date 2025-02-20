﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace AuthorInsitution_Minhtda.Pages.CorrespondingAuthors
{
    public class EditModel : PageModel
    {
        private readonly BusinessObject.Models.AuthorInstitution2023DBContext _context;

        public EditModel(BusinessObject.Models.AuthorInstitution2023DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CorrespondingAuthor CorrespondingAuthor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CorrespondingAuthors == null)
            {
                return NotFound();
            }

            var correspondingauthor =  await _context.CorrespondingAuthors.FirstOrDefaultAsync(m => m.AuthorId == id);
            if (correspondingauthor == null)
            {
                return NotFound();
            }
            CorrespondingAuthor = correspondingauthor;
           ViewData["InstitutionId"] = new SelectList(_context.InstitutionInformations, "InstitutionId", "InstitutionName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CorrespondingAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorrespondingAuthorExists(CorrespondingAuthor.AuthorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CorrespondingAuthorExists(string id)
        {
          return (_context.CorrespondingAuthors?.Any(e => e.AuthorId == id)).GetValueOrDefault();
        }
    }
}
