using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PieseAuto.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PieseAuto.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly PieseAutoContext _context;

        // Proprietăți pentru a stoca datele care vor fi afișate pe pagina Privacy
        public int TotalStock { get; set; }
        public int TotalCategories { get; set; }
        public decimal TotalValue { get; set; }

        // Constructor pentru a injecta dependințele
        public PrivacyModel(ILogger<PrivacyModel> logger, PieseAutoContext context)
        {
            _logger = logger;
            _context = context;
        }

     
        public async Task OnGetAsync()
        {
            // total produse
            TotalStock = await _context.Book.SumAsync(b => b.Stock);

            // total categorii
            TotalCategories = await _context.Category.CountAsync();

            // calcul total (pret * stoc)
            TotalValue = await _context.Book.SumAsync(b => b.Price * b.Stock);
        }
    }
}
