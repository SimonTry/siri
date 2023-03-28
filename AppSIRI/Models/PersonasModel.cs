using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSIRI.Models
{
    [Table("Personas")]
    public partial class PersonasModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id
        {
            get;
            set;
        }
        [Required(ErrorMessage = "El campo Primer nombre es obligatorio")]
        [Display(Name = "Primer nombre")]
        public string firstName { get; set; }


        [Display(Name = "Segundo nombre")]
        public string secondName { get; set; }
        [Required(ErrorMessage = "El campo Primer apellido es obligatorio")]
        [Display(Name = "Primer apellido")]
        public string firstLastName { get; set; }

        [Required(ErrorMessage = "El campo Segundo apellido es obligatorio")]
        [Display(Name = "Segundo apellido")]
        public string secondLastName { get; set; }

        [Required(ErrorMessage = "El campo cedula es obligatorio")]
        [MaxLength(10, ErrorMessage = "Se admiten hasta 10 caracteres")]
        [MinLength(1, ErrorMessage = "Se necesita al menos un caracter")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Cedula solo admite numeros")]
        public string identification { get; set; }

        [Display(Name = "Usuario")]
        public Guid User { get; set; }


    }
}