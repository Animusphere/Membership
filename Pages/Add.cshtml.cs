using ApplicationMember.Data.DBContext;
using ApplicationMember.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Onboarding.Handlers.Image;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ApplicationMember.Pages
{
    public class AddModel : PageModel
    {
        private readonly DatabaseContext _context;
        private readonly IImageHandler _image;
        public AddModel(DatabaseContext context,IImageHandler image)
        {
            _context = context;
            _image = image;
        }


        [BindProperty]
        public DataModel member { get; set; }
        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var path = _image.UploadImage(ImageFile);
                member.Path = path;
            }
            _context.Users.Add(member);
           await _context.SaveChangesAsync();
           return RedirectToPage("./list");
        }
    }
}
