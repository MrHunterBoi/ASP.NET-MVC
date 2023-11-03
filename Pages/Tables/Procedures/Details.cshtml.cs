using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_API;
using ASP_API.Utils;

namespace ASP.NET_MVC.Pages.Tables_Proced
{
    public class DetailsModel : PageModel
    {
        private readonly ASP_API.HospitalDBContext _context;

        public DetailsModel(ASP_API.HospitalDBContext context)
        {
            _context = context;
        }

      public ProcedFull Proced { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Proced == null)
            {
                return NotFound();
            }

            var proced = await _context.Proced.FirstOrDefaultAsync(m => m.IDproc == id);
            if (proced == null)
            {
                return NotFound();
            }
            else 
            {
                var equipment = await _context.Equipment.FindAsync(proced.Equipment_ID);
                var medicine = await _context.Medicine.FindAsync(proced.Medicine_ID);
                var patient = await _context.Patient.FindAsync(proced.Patient_ID);
                var staff = await _context.Staff.FindAsync(proced.Staff_ID);

                ProcedFull procedFull = new ProcedFull(proced);
                procedFull.Equipment = equipment;
                procedFull.Medicine = medicine;
                procedFull.Patient = patient;
                procedFull.Staff = staff;

                Proced = procedFull;
            }
            return Page();
        }
    }
}
