using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace demoRazor.Pages
{
    public class exampleModel : PageModel
    {
        [BindProperty]
        public String Name { get; set; }
        public void OnGet()
        {
        }
    }
}
