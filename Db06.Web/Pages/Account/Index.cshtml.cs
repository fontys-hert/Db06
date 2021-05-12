using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Db06.Web.Pages.Account
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            var account = new Domain.Account("Timo");
        }
    }
}
