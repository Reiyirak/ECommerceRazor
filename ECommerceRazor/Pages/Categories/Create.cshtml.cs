using ECommerceRazor.Data;
using ECommerceRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECommerceRazor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
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
            bool nombreExiste = _context.Categories.Any(c => c.Name == Category.Name);

            if (nombreExiste)
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

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            // Usar TempData para mostrar el mensaje en la pagina de Index
            TempData["Success"] = "Categoria creada con exito";

            return RedirectToPage("Index");
        }
    }
}
