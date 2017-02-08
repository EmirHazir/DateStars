using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarsDate.Models
{
    public class ProfileSearchVM
    {

        [Display(Name = "I'mlooking for a")]
        public Gender Gender { get; set; }
        [Display(Name = "Age from")]
        public int MinAge { get; set; }
        [Display(Name = "to")]
        public int MaxAge { get; set; }
        [Display(Name = "Height from")]
        public int MinHeight { get; set; }
        [Display(Name = "to")]
        public int MaxHeight { get; set; }
        [Display(Name = "Only non-smokers")]
        public bool NoSmoking { get; set; }

    }


}
