using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_API;
using ASP_API.Models;

namespace ASP.NET_MVC.Pages.Tables_Patient
{
    public class IndexModel : PageModel
    {
        private readonly ASP_API.HospitalDBContext _context;

        public IndexModel(ASP_API.HospitalDBContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Patient != null)
            {
                Patient = await _context.Patient.ToListAsync();
            }
        }
    }
}
