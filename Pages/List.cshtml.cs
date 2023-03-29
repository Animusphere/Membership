using ApplicationMember.Data.DBContext;
using ApplicationMember.Data.Handlers.ExportPdf;
using ApplicationMember.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationMember.Pages
{
    public class ListModel : PageModel
    {
        private readonly DatabaseContext _context;
        private readonly IExporterHandler _exporter;
        public ListModel(DatabaseContext context, IExporterHandler exporter)
        {
            _context = context;
            _exporter = exporter;
        }

        public List<DataModel> memberList = new List<DataModel>();
        public async Task<IActionResult> OnGetAsync()
        {
            memberList = await _context.Users.ToListAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(long id)
        {
            var itemToDelete = await _context.Users.FindAsync(id);
            if (itemToDelete != null)
            {
                _context.Users.Remove(itemToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostExportAsync()
        {
            var data = await _context.Users.ToListAsync(); 
            if (data.Count >0)
            {
                return _exporter.GeneratePdf(data);
            }
            else return RedirectToPage();
        }
    }
}
