using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    // SI HUBIERA VARIAS PROPIEDADES, PARA NO TENER QUE PONER EN TODAS [BindProperty], SE PONDRIA AQUI ARRIBA [BindProperties]
    public class EditModel : PageModel
    {
        private readonly AppDBContext _context;
        // BINDPROPERTY BINDEA LA PROPIEDAD DEL TIRON SIN NECESIDAD DE ->
        [BindProperty]
        public Category Category { get; set; }

        public EditModel(AppDBContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            Category = _context.Category.Find(id);
            //Category = _context.Category.FirstOrDefault(u=>u.Id == id);
            //Category = _context.Category.SingleOrDefault(obj=>obj.Id == id); // FORMAS DE HACER LO MISMO QUE EL PRIMERO
            //Category = _context.Category.Where(u=>u.Id == id).FirstOrDefault();
        }
       public async Task<IActionResult> OnPost()// -> ESCRIBIR AQUI Category category
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(String.Empty /*Se puede añadir Category.Name y el error aparecerá debajo del input*/, "DisplayOrder can not exactly match the Name");
            }

            if(ModelState.IsValid)
            {
                _context.Category.Update(Category);  // DE MODO QUE SOLO SE ESCRIBE AQUI EL NOMBRE DE LA PROPIEDAD
                await _context.SaveChangesAsync();
                TempData["success"] = "Category updated succesfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
