using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSIRI.Models
{
    [Table("Remates")]
    public class RematesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RemateId { get; set; }
        
        [Display(Name ="Productos")]
        public virtual Guid productoId { get; set; }

        [Required]
        [Display(Name ="Fecha incio")]
        public virtual DateTime fechaInicio { get; set; }

        [Required]
        [Display(Name ="Fecha fin")]
        public virtual DateTime fechaFin { get; set; }

        [Required]
        [Display(Name ="Precio base")]
        public virtual int precioBase { get; set; }

        [Required(ErrorMessage ="Debe ingresar una descripcion del remate")]
        [Display(Name ="Descripcion del remate")]
        public virtual string descripcionRemate { get; set; }

    }
}