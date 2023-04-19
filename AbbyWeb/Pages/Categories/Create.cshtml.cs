using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    // SI HUBIERA VARIAS PROPIEDADES, PARA NO TENER QUE PONER EN TODAS [BindProperty], SE PONDRIA AQUI ARRIBA [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly AppDBContext _context;
        // BINDPROPERTY BINDEA LA PROPIEDAD DEL TIRON SIN NECESIDAD DE ->
        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(AppDBContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
       public async Task<IActionResult> OnPost()// -> ESCRIBIR AQUI Category category
        {
            await _context.Category.AddAsync(Category);  // DE MODO QUE SOLO SE ESCRIBE AQUI EL NOMBRE DE LA PROPIEDAD
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
