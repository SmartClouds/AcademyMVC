using AcademyMVC.Data;
using AcademyMVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademyMVC.Controllers
{
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int categoryItemId)
        {
            Content content = await (from item in _context.Content
                                     where item.categoryItem.ID == categoryItemId
                                     select new Content
                                     {
                                         Title = item.Title,
                                         VideoLink = item.VideoLink,
                                         MyProperty = item.MyProperty
                                     }).FirstOrDefaultAsync();
           
            return View(content);
        }
    }
}
