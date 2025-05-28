using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceRazor.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository _dbCategory;

        public IndexModel(ICategoryRepository dbCategory)
        {
            _dbCategory = dbCategory;
        }

        public IEnumerable<Category> Categories { get; set; } = default!;

        public void OnGet()
        {
            // Cargar todas las categorias desde la base de datos
            Categories = _dbCategory.GetAll();
        }

        public async Task<IActionResult> OnPostDeleteAsync([FromBody] int id)
        {
            // var category = await _dbCategory.Categories.FindAsync(id);
            //
            // if (category == null)
            // {
            //     TempData["Error"] = "La categoria no fue encontrada";
            //     return RedirectToPage("Index");
            //     // return NotFound();
            // }
            //
            // _dbCategory.Categories.Remove(category);
            // await _dbCategory.SaveChangesAsync();

            TempData["Success"] = "Categoria eliminada con exito";

            return new JsonResult(new { success = true });
        }
    }
}
