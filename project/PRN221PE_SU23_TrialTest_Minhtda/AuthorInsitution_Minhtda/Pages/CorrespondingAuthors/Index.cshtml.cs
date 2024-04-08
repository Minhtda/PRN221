using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repositories.Commons;

namespace AuthorInsitution_Minhtda.Pages.CorrespondingAuthors
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.Models.AuthorInstitution2023DBContext _context;
        private readonly IConfiguration _configuration;
        public IndexModel(IConfiguration configuration, BusinessObject.Models.AuthorInstitution2023DBContext context)
        {
            _context = context;
            _configuration = configuration;
        }
        public string CurrentFilter { get; set; }
        public string CurrentFilterSkill { get; set; }
        public PaginatedList<CorrespondingAuthor> CorrespondingAuthors { get; set; } = default!;

        public async Task OnGetAsync(string searchString, string currentFilter, string searchStringSkill, string currentFilterSkill, int? pageIndex)
        {
            if (_context.CorrespondingAuthors != null)
            {
                if (searchString is not null || searchStringSkill is not null)
                {
                    pageIndex = 1;
                }
                else
                {
                    if (searchString is null)
                    {
                        searchString = currentFilter;
                    }
                    if (searchStringSkill is null)
                    {
                        searchStringSkill = currentFilterSkill;
                    }

                }
                CurrentFilter = searchString;
                CurrentFilterSkill = searchStringSkill;
                IQueryable<CorrespondingAuthor> doctorInformationIQ = from d in _context.CorrespondingAuthors.Include(d => d.Institution) select d;
                if (!string.IsNullOrEmpty(searchString))
                {
                    doctorInformationIQ = doctorInformationIQ.Where(x => x.AuthorName.Contains(searchString));
                }
                if (!string.IsNullOrEmpty(searchStringSkill))
                {
                    doctorInformationIQ = doctorInformationIQ.Where(x => x.Skills.Contains(searchStringSkill));
                }
                var pageSize = _configuration.GetValue("PageSize", 4);
                CorrespondingAuthors = await PaginatedList<CorrespondingAuthor>.CreateAsync(doctorInformationIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            }
        }
    }
}
