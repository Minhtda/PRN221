using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;

namespace Assignment_Tutorial.Pages.DoctorInformations
{
    public class DeleteModel : PageModel
    {
        private readonly BussinessObject.Models.HospitalManagementDBContext _context;

        public DeleteModel(BussinessObject.Models.HospitalManagementDBContext context)
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

            var doctorinformation = await _context.DoctorInformations.FirstOrDefaultAsync(m => m.DoctorId == id);

            if (doctorinformation == null)
            {
                return NotFound();
            }
            else 
            {
                DoctorInformation = doctorinformation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.DoctorInformations == null)
            {
                return NotFound();
            }
            var doctorinformation = await _context.DoctorInformations.FindAsync(id);

            if (doctorinformation != null)
            {
                DoctorInformation = doctorinformation;
                _context.DoctorInformations.Remove(DoctorInformation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
