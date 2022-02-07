using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identityfromscrathc.Pages
{
    [Authorize(Policy = "MustBelongToHRDepartment")]
    public class HrDepartmentModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
