using Food.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Food.ViewModels
{
    public class RestaurantEditModel
    {
        [Display(Name="Restaurant Name")]
        [Required, MaxLength(80)]
        public string Name { get; set; }
        [Required]
        public PriceType Price { get; set; }
    }
}
