using AbbyWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Data
{// ESTA CLASE DEBE HEREDAR DE DBCONTEXT
    public class AppDBContext : DbContext
    {
        // LA PARTE QUE MENOS ENTIENDO SE CREA UN CONSTRUCTOR DE LA BASE DE DATOS, CON PARAMETRO DBContextOptions options, y SE LE PASA A DbContext con el 'base(options)'
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
// CON DBSET HACEMOS REFERENCIA A LA TABLA DE LA BASE DE DATOS (EL MODELO)
// DESPUES HAY QUE IR A PROGRAM.CS
        public DbSet<Category> Category { get; set; }
    }
}
