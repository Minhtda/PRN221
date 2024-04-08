using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using Repositories.Commons;
using Microsoft.Data.SqlClient;

namespace Assignment_Tutorial.Pages.DoctorInformations
{
    public class IndexModel : PageModel
    {
        private readonly BussinessObject.Models.HospitalManagementDBContext _context;
        private readonly IConfiguration _configuration;
        public IndexModel(IConfiguration configuration, BussinessObject.Models.HospitalManagementDBContext context)
        {
            _context = context;
            _configuration = configuration;
        }
        public string CurrentFilter { get; set; }
        public PaginatedList<DoctorInformation> DoctorInformation { get; set; } = default!;

        public async Task OnGetAsync(string searchString, string currentFilter, int? pageIndex)
        {
            if (_context.DoctorInformations != null)
            {
                if (searchString is not null)
                {
                    pageIndex = 1;
                }
                else
                {
                    searchString = currentFilter;
                }
                CurrentFilter = searchString;
                IQueryable<DoctorInformation> doctorInformationIQ = from d in _context.DoctorInformations.Include(d => d.Department) select d;
                if (!string.IsNullOrEmpty(searchString))
                {
                    doctorInformationIQ = doctorInformationIQ.Where(x => x.DoctorName.Contains(searchString));
                }
                var pageSize = _configuration.GetValue("PageSize", 4);
                DoctorInformation = await PaginatedList<DoctorInformation>.CreateAsync(doctorInformationIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            }
        }
    }
}
