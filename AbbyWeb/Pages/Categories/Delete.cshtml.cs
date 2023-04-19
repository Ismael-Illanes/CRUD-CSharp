using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Pages.Categories
{
    // SI HUBIERA VARIAS PROPIEDADES, PARA NO TENER QUE PONER EN TODAS [BindProperty], SE PONDRIA AQUI ARRIBA [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly AppDBContext _context;
        // BINDPROPERTY BINDEA LA PROPIEDAD DEL TIRON SIN NECESIDAD DE ->
        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(AppDBContext context)
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
            var categoryFromDb = _context.Category.Find(Category.Id);
                if(categoryFromDb != null) 
                {
                _context.Category.Remove(categoryFromDb);
                    await _context.SaveChangesAsync();
                TempData["success"] = "Category removed successfully.";
                return RedirectToPage("Index");
                }
            
            return Page();
        }
    }
}
