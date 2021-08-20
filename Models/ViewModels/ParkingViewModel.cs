using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ParkingViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre",
            Order = 1,
            Prompt = "Introduce el Nombre",
            Description = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descripción",
            Order = 2,
            Prompt = "Introduce la Descripción",
            Description = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Fecha de Creación",
            Order = 3,
            Prompt = "Introduce la Fecha de Creación",
            Description = "Fecha de Creación")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; }
    }
}
