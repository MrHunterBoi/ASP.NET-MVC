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
    public class DeleteModel : PageModel
    {
        private readonly ASP_API.HospitalDBContext _context;

        public DeleteModel(ASP_API.HospitalDBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }
            var patient = await _context.Patient.FindAsync(id);

            if (patient != null)
            {
                Patient = patient;
                _context.Patient.Remove(Patient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
