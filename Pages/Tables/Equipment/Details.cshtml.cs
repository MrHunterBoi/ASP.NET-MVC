using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_API;
using ASP_API.Models;

namespace ASP.NET_MVC.Pages.Tables_Equipment
{
    public class DetailsModel : PageModel
    {
        private readonly ASP_API.HospitalDBContext _context;

        public DetailsModel(ASP_API.HospitalDBContext context)
        {
            _context = context;
        }

      public Equipment Equipment { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment.FirstOrDefaultAsync(m => m.IDeq == id);
            if (equipment == null)
            {
                return NotFound();
            }
            else 
            {
                Equipment = equipment;
            }
            return Page();
        }
    }
}
