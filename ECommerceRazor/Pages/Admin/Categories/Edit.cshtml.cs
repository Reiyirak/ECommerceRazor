using ECommerce.DataAccess.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceRazor.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = await _context.Categories.FindAsync(id);

            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var categoryBd = await _context.Categories.FindAsync(Category.Id);

            if (categoryBd == null)
            {
                return NotFound();
            }

            // Actualizamos los campos modificables
            categoryBd.Name = Category.Name;
            categoryBd.DisplayOrder = Category.DisplayOrder;

            // Guardar los cambios
            await _context.SaveChangesAsync();

            TempData["Success"] = "Categoria editada con exito";

            return RedirectToPage("Index");
        }
    }
}
