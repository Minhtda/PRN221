using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Models;

namespace Assignment_Tutorial.Pages.DoctorInformations
{
    public class CreateModel : PageModel
    {
        private readonly BussinessObject.Models.HospitalManagementDBContext _context;

        public CreateModel(BussinessObject.Models.HospitalManagementDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return Page();
        }

        [BindProperty]
        public DoctorInformation DoctorInformation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.DoctorInformations == null || DoctorInformation == null)
            {
                return Page();
            }

            _context.DoctorInformations.Add(DoctorInformation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
