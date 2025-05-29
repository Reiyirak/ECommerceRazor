using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceRazor.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);

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

            var categoryBd = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == Category.Id);

            if (categoryBd == null)
            {
                return NotFound();
            }

            // Actualizamos los campos modificables
            categoryBd.Name = Category.Name;
            categoryBd.DisplayOrder = Category.DisplayOrder;

            // Guardar los cambios
            _unitOfWork.Save();

            TempData["Success"] = "Categoria editada con exito";

            return RedirectToPage("Index");
        }
    }
}
