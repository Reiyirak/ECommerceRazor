using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECommerceRazor.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty] public Category Category { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validacion personalizada: comprobar si el nombre ya existe
            // bool nombreExiste = _dbCategory.Categories.Any(c => c.Name == Category.Name);
            //
            // if (nombreExiste)
            // {
            //     ModelState.AddModelError("Category.Name", "El nombre ya existe. Por favor elige otro.");
            //     return Page();
            // }

            // Validacion personalizada: comprobar si el nombre ya existe V2.0 con Repository
            if (_unitOfWork.Category.NameExists(Category.Name))
            {
                ModelState.AddModelError("Category.Name", "El nombre ya existe. Por favor elige otro.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Asignar la fecha de creacion
            Category.CreationDate = DateTime.Now;

            _unitOfWork.Category.Add(Category);
            _unitOfWork.Save();

            // Usar TempData para mostrar el mensaje en la pagina de Index
            TempData["Success"] = "Categoria creada con exito";

            return RedirectToPage("Index");
        }
    }
}