using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PieseAuto.Data;
using PieseAuto.Models;

namespace PieseAuto.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly PieseAuto.Data.PieseAutoContext _context;

        public IndexModel(PieseAuto.Data.PieseAutoContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
