using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASP.NetWebApi.Model
{
    public class Laptop
    {
        [Required]
        public int LaptopId { get; set; }
        [Required]
        public string LaptopBrand { get; set; }
        [Required]
        [MaxLength(15)]
        public string LaptopModel { get; set; }
        [Required]
        public long LaptopPrice { get; set; }
        [Required]
        [Range(0,5)]
        public int Ratings { get; set; }

    }
}
