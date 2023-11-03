using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_API;
using ASP_API.Models;

namespace ASP.NET_MVC.Pages.Tables_Equipment
{
    public class CreateModel : PageModel
    {
        private readonly ASP_API.HospitalDBContext _context;

        public CreateModel(ASP_API.HospitalDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Equipment Equipment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Equipment == null || Equipment == null)
            {
                return Page();
            }

            _context.Equipment.Add(Equipment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
