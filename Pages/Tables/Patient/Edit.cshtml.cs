using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_API;
using ASP_API.Models;

namespace ASP.NET_MVC.Pages.Tables_Patient
{
    public class EditModel : PageModel
    {
        private readonly ASP_API.HospitalDBContext _context;

        public EditModel(ASP_API.HospitalDBContext context)
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

            var patient =  await _context.Patient.FirstOrDefaultAsync(m => m.IDpat == id);
            if (patient == null)
            {
                return NotFound();
            }
            Patient = patient;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(Patient.IDpat))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PatientExists(int id)
        {
          return (_context.Patient?.Any(e => e.IDpat == id)).GetValueOrDefault();
        }
    }
}
