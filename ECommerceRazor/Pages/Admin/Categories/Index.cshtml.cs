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
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> Categories { get; set; } = default!;

        public void OnGet()
        {
            // Cargar todas las categorias desde la base de datos
            Categories = _unitOfWork.Category.GetAll();
        }

        public async Task<IActionResult> OnPostDeleteAsync([FromBody] int id)
        {
            var category = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            
            if (category == null)
            {
                TempData["Error"] = "La categoria no fue encontrada";
                return RedirectToPage("Index");
                // return NotFound();
            }
            
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();

            TempData["Success"] = "Categoria eliminada con exito";

            return new JsonResult(new { success = true });
        }
    }
}
