using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;

namespace Assignment_Tutorial.Pages.DoctorInformations
{
    public class EditModel : PageModel
    {
        private readonly BussinessObject.Models.HospitalManagementDBContext _context;

        public EditModel(BussinessObject.Models.HospitalManagementDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DoctorInformation DoctorInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.DoctorInformations == null)
            {
                return NotFound();
            }

            var doctorinformation =  await _context.DoctorInformations.FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctorinformation == null)
            {
                return NotFound();
            }
            DoctorInformation = doctorinformation;
           ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
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

            _context.Attach(DoctorInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorInformationExists(DoctorInformation.DoctorId))
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

        private bool DoctorInformationExists(string id)
        {
          return (_context.DoctorInformations?.Any(e => e.DoctorId == id)).GetValueOrDefault();
        }
    }
}
