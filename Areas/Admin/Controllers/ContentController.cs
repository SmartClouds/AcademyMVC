using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademyMVC.Data;
using AcademyMVC.Entities;

namespace AcademyMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContentController(ApplicationDbContext context)
        {
            _context = context;
        }

     
        // GET: Admin/Content/Create
        public IActionResult Create(int categoryItemId,int categoryId)
        {
            Content content= new Content { CatItemId= categoryItemId, CategoryId = categoryId };
            return View(content);
        }

        // POST: Admin/Content/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,MyProperty,VideoLink,CatItemId,CategoryId")] Content content)
        {
            if (ModelState.IsValid)
            {
                content.categoryItem = await _context.CategoryItem.FindAsync(content.CatItemId);
                _context.Add(content);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "CategoryItem", new {catgoryId=content.CategoryId});
            }
            return View(content);
        }

        // GET: Admin/Content/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Content == null)
            {
                return NotFound();
            }

            var content = await _context.Content.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }
            return View(content);
        }

        // POST: Admin/Content/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,MyProperty,VideoLink")] Content content)
        {
            if (id != content.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(content);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentExists(content.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(content);
        }

        // GET: Admin/Content/Delete/5
      
        private bool ContentExists(int id)
        {
          return _context.Content.Any(e => e.Id == id);
        }
    }
}
