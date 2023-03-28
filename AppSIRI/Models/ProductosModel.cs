using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSIRI.Models
{
    [Table("Productos")]
    public partial class ProductosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid productoId{ get; set; }

        [Required(ErrorMessage ="El campo nombre producto es obligatorio")]
        [MinLength(3, ErrorMessage ="El campo debe tener al menos 3 caracteres")]
        public virtual string nombreProducto { get; set; }

        [MinLength(5, ErrorMessage ="El campo debe tener al menos 5 caracteres")]
        public virtual string descripcionProducto { get; set; }

        [Display(Name ="Persona")]
        public Guid persona { get; set; }

    }
}