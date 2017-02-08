using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarsDate.Models;
using StarsDate.Models.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StarsDate.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _enviroment;
        public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManagers, IHostingEnvironment envirnment)
        {
            _enviroment = envirnment;
            _userManager = userManagers;
            _context = context;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var profil = await _context.Profiles.SingleOrDefaultAsync(p => p.Id == id);
            if (profil == null)
            {
                return NotFound();
            }
         return View(profil);
        }


        public IActionResult Search(ProfileSearchVM model =  new ProfileSearchVM)
        {
            model.MinAge = 18;
            model.MaxAge = 35;
            model.MinHeight = 150;
            model.MaxHeight = 300;
            return View(model);
        }


        public IActionResult Search(ProfileSearchVM model)
        {
            List<ProfileSearchResultVM> result = new List<ProfileSearchResultVM>();
            if (ModelState.IsValid)
            {
                DateTime minDate = DateTime.Today.AddYears(-model.MaxAge);
                DateTime maxDate = DateTime.Today.AddYears(-model.MinAge);

                result = (from p in _context.Profiles
                          where p.Gender == model.Gender
                          && p.Height > model.MinAge && p.Height < model.MaxHeight
                          && p.BirthDate > minDate && p.BirthDate < maxDate
                          && (!model.NoSmoking || (model.NoSmoking && p.Smoking == SmokerType.non))
                          select new ProfileSearchResultVM
                          {
                              Description = p.Description,
                              Id = p.Id,
                              ProfilePicture = $"{p.User.Id}/{p.ProfilePicture}",
                              Gender = p.Gender,
                              Smoking = p.Smoking,
                              DisplayName = p.DisplayName,
                              Height = p.Height,
                              Age = calculateAge(p.BirthDate)

                          }).ToList();
            }
            return View("Result",result);
        }

        private int calculateAge(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }



        [HttpPost]
        public IActionResult Result(ProfileSearchResultVM model)
        {
            return View();
        }



        public async Task<IActionResult> Edit()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);

            var profil = await _context.Profiles.SingleOrDefaultAsync(p => p.Id == currentUser.ProfileId);
            return View(profil);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,DisplayName,BirthDate,Height,ProfilePicture,Description,Smoking,ProfilePictureFile")] Profile profile, IFormFile ProfilePictureFile)
        {
            
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await _userManager.GetUserAsync(User);

                if (ProfilePictureFile != null)
                {
                    string uploadPicture = Path.Combine(_enviroment.WebRootPath, "uploads");
                    Directory.CreateDirectory(Path.Combine(uploadPicture, currentUser.Id));

                    string fileName = Path.GetFileName(ProfilePictureFile.FileName);
                    
                    using (FileStream fs = new FileStream(Path.Combine(uploadPicture,currentUser.Id,fileName),FileMode.Create))
                    {
                        await ProfilePictureFile.CopyToAsync(fs);
                    }
                    profile.ProfilePicture = fileName;
                }

                    _context.Update(profile);
                    await _context.SaveChangesAsync();
               
            }
            return View(profile);
        }

       


    }
}
