using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        // SE CREA EL CONTEXTO EN ESTA CLASE HACIENDO REFERENCIA A LA CLASE DONDE SI QUE ESTÁ LINKADA LA DB
        private readonly AppDBContext _dbContext; // *
        public IEnumerable<Category> Categories { get; set; }
        // EN EL CONSTRUCTOR DE ESTA CLASE 'ctor' SE PASA POR PARAMETRO LA CLASE DONDE ESTA EL CONTEXT DE LA DB Y SE IGUALA A LA PROPIEDAD ANTERIOR
        public IndexModel(AppDBContext dbContext) // CONSTRUCTOR
        {
            _dbContext = dbContext;
        }

        //AL CARGAR LA PAGINA EL COLLECTION IENUMERABLE SE IGUALA A LA TABLA DE LA BASE DE DATOS DONDE SE VA A TRABAJAR
        public void OnGet()
        {
            Categories = _dbContext.Category;
        }
    }
}
