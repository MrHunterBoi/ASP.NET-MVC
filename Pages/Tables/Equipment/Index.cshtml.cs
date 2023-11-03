using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_API;
using ASP_API.Models;
using System.Text.Json;

namespace ASP.NET_MVC.Pages.Tables_Equipment
{
    public class IndexModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly ASP_API.HospitalDBContext _context;

        public IndexModel(ASP_API.HospitalDBContext context)
        {
            _context = context;
        }

        public IList<Equipment> Equipment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Equipment != null)
            {
                Equipment = await _context.Equipment.ToListAsync();
            }
        }
    }
}
