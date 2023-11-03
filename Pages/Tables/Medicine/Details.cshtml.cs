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
    public class DetailsModel : PageModel
    {
        private readonly ASP_API.HospitalDBContext _context;

        public DetailsModel(ASP_API.HospitalDBContext context)
        {
            _context = context;
        }

      public Medicine Medicine { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Medicine == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicine.FirstOrDefaultAsync(m => m.IDmed == id);
            if (medicine == null)
            {
                return NotFound();
            }
            else 
            {
                Medicine = medicine;
            }
            return Page();
        }
    }
}
