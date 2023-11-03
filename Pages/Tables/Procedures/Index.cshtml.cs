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
    public class IndexModel : PageModel
    {
        private readonly ASP_API.HospitalDBContext _context;

        public IndexModel(ASP_API.HospitalDBContext context)
        {
            _context = context;
        }

        public IList<ProcedFull> Proced { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Proced != null)
            {
                var proceds = await _context.Proced.ToListAsync();

                List<ProcedFull> procedFulls = new List<ProcedFull>();

                foreach (var proced in proceds)
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

                    procedFulls.Add(procedFull);
                }

                Proced = procedFulls;
            }
        }
    }
}
