using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_API;
using ASP_API.Models;

namespace ASP.NET_MVC.Pages.Tables_Proced
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
        public Proced Proced { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Proced == null || Proced == null)
            {
                return Page();
            }

            _context.Proced.Add(Proced);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
