using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarsDate.Models
{
    public class ProfileSearchResultVM
    {
        public int Id { get; set; }

        public Gender Gender { get; set; }

        [Display(Name ="Görünen Ad")]
        public string DisplayName { get; set; }

        public int Age { get; set; }

        [Display(Name = "Boy (cm)")]
        public int Height { get; set; }

        public string Description { get; set; }
        [Display(Name = "Profil fotografı")]
        public string ProfilePicture  { get; set; }

        public SmokerType Smoking { get; set; }

    }
}
