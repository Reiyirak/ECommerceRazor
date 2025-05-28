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
        private readonly ICategoryRepository _dbCategory;

        public CreateModel(ICategoryRepository dbCategory)
        {
            _dbCategory = dbCategory;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

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

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Asignar la fecha de creacion
            Category.CreationDate = DateTime.Now;

            _dbCategory.Add(Category);
            _dbCategory.Save();

            // Usar TempData para mostrar el mensaje en la pagina de Index
            TempData["Success"] = "Categoria creada con exito";

            return RedirectToPage("Index");
        }
    }
}
