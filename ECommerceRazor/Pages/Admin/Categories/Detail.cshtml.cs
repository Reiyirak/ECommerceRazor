using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceRazor.Pages.Admin.Categories
{
    public class DetailModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
    }
}
