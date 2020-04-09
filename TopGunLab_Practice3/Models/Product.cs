using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TopGunLab_Practice3.Models.Enums;

namespace TopGunLab_Practice3.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Required field")]
        public decimal Count { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public string ProductionDate { get; set; } = DateTime.Now.ToShortDateString();

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required field")]
        public DateTime ExcpiryDate { get; set; }


        [Required(ErrorMessage = "Required field")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DefaultValue(false)]
        public Measure Measure { get; set; }

        public string Logo { get; set; } 
    }
}