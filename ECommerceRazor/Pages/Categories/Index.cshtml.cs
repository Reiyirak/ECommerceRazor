using ECommerce.DataAccess.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Cargar todas las categorias desde la base de datos
            Categories = await _context.Categories
                .OrderBy(c => c.DisplayOrder) // Ordenar por orden de visualizacion
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync([FromBody] int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                TempData["Error"] = "La categoria no fue encontrada";
                return RedirectToPage("Index");
                // return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Categoria eliminada con exito";

            return new JsonResult(new { success = true });
        }
    }
}
