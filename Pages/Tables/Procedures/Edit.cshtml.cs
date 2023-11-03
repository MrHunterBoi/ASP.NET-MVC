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

namespace ASP.NET_MVC.Pages.Tables_Proced
{
    public class EditModel : PageModel
    {
        private readonly ASP_API.HospitalDBContext _context;

        public EditModel(ASP_API.HospitalDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proced Proced { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Proced == null)
            {
                return NotFound();
            }

            var proced =  await _context.Proced.FirstOrDefaultAsync(m => m.IDproc == id);
            if (proced == null)
            {
                return NotFound();
            }
            Proced = proced;
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

            _context.Attach(Proced).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedExists(Proced.IDproc))
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

        private bool ProcedExists(int id)
        {
          return (_context.Proced?.Any(e => e.IDproc == id)).GetValueOrDefault();
        }
    }
}
