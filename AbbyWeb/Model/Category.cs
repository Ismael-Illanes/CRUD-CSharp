using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Model
{
    public class Category
    {
        [Key] // CLAVE PRINCIPAL
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Display Order")] // ASI PUEDES MODIFICAR COMO APARECERÁ REFERENCIADO ESTA PROPIEDAD
        [Range(0,100,ErrorMessage ="Display must be in a range of 0 - 100")]
        public int DisplayOrder { get; set; }   
    }
}
