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
    public class DetailsModel : PageModel
    {
        private readonly ASP_API.HospitalDBContext _context;

        public DetailsModel(ASP_API.HospitalDBContext context)
        {
            _context = context;
        }

      public Patient Patient { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FirstOrDefaultAsync(m => m.IDpat == id);
            if (patient == null)
            {
                return NotFound();
            }
            else 
            {
                Patient = patient;
            }
            return Page();
        }
    }
}
