using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSIRI.Models
{
    [Table("Pujas")]
    public class RematePorUsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid PujaId { get; set; }

        [Display(Name ="Remate")]
        public Guid RemateIdFk { get; set; }

        [Display(Name ="Usuario")]
        public Guid UserIdFk { get; set; }

        [Required]
        [Display(Name = "Valor puja")]
        public int valorPuja { get; set; }
    }
}