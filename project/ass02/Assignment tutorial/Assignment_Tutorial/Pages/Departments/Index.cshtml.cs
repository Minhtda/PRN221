using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using Repositories.Commons;

namespace Assignment_Tutorial.Pages.Departments
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
        public PaginatedList<Department> Department { get; set; } = default!;
        public async Task OnGetAsync(string searchString, string currentFilter, int? pageIndex)
        {
            if (_context.Departments != null)
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
                IQueryable<Department> departmentIQ = from d in _context.Departments select d;
                if (!string.IsNullOrEmpty(searchString))
                {
                    departmentIQ = departmentIQ.Where(x => x.DepartmentName.Contains(searchString));
                }
                var pageSize = _configuration.GetValue("PageSize", 4);
                Department = await PaginatedList<Department>.CreateAsync(departmentIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            }
        }
    }
}
