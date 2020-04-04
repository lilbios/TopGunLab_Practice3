using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TopGunLab_Practice3.Models.Enums;

namespace TopGunLab_Practice3.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExcpiryDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Measure Meausure { get; set; }
        public string Logo { get; set; } = "default_prod.png";
    }
}