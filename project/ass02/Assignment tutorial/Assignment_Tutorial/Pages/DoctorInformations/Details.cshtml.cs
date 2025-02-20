﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;

namespace Assignment_Tutorial.Pages.DoctorInformations
{
    public class DetailsModel : PageModel
    {
        private readonly BussinessObject.Models.HospitalManagementDBContext _context;

        public DetailsModel(BussinessObject.Models.HospitalManagementDBContext context)
        {
            _context = context;
        }

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
    }
}
