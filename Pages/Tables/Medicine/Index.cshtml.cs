using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_API;
using ASP_API.Models;

namespace ASP.NET_MVC.Pages.Tables_Medicine
{
    public class IndexModel : PageModel
    {
        private readonly ASP_API.HospitalDBContext _context;

        public IndexModel(ASP_API.HospitalDBContext context)
        {
            _context = context;
        }

        public IList<Medicine> Medicine { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Medicine != null)
            {
                Medicine = await _context.Medicine.ToListAsync();
            }
        }
    }
}
