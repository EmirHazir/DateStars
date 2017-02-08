using StarsDate.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarsDate.Models
{
    public enum SmokerType
    {
        sometimes,
        regular,
        non
    }
    public enum Gender
    {
        female,
        male
    }


    public class Profile
    {
        public int Id { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Profil Adı")]
        public string DisplayName { get; set; }

        public DateTime BirthDate { get; set; }

        [Display(Name = "Boy(cm)")]
        public int Height { get; set; }

        [Display(Name ="Profil Fotografı")]
        public string ProfilePicture { get; set; }

        public string Description { get; set; }

        public SmokerType Smoking { get; set; }

        public ApplicationUser User { get; set; }
    }
}
