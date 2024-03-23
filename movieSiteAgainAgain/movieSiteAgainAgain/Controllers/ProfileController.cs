using Microsoft.AspNetCore.Mvc;
using movieSiteAgainAgain.Data;
using movieSiteAgainAgain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using Microsoft.AspNetCore.Authentication;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Extensions.Options;

namespace movieSiteAgainAgain.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IWebHostEnvironment _environment;
        public ProfileController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _dbcontext = context;
            _environment = environment;
        }
        public IActionResult userfavoritelist()
        {
            var userEmail = HttpContext.Session.GetString("userEmail");
            if (userEmail == null)
            {
                return RedirectToAction("Login", "Profile");
            }
            var currentuser = _dbcontext.Users.Find(userEmail);
            List<UserFavoriteMovief> UFM = _dbcontext.UserFavoriteMoviefs.Where(x => x.userEmail == userEmail).ToList();
            List<Movie> favoriteMovies = new List<Movie>();
            foreach (var item in UFM)
            {
                Movie movie = _dbcontext.Movies.Find(item.movieId);
                favoriteMovies.Add(movie);
            }
            TempData["userAcount"] = currentuser;
            return View(favoriteMovies);
        }
        public IActionResult userrate()
        {
            var userEmail = HttpContext.Session.GetString("userEmail");
            if (userEmail == null)
            {
                return RedirectToAction("Login", "Profile");
            }
            var currentuser = _dbcontext.Users.Find(userEmail);
            List<UserRatedMovie> URM = _dbcontext.UserRatedMovies.Where(x => x.userEmail == userEmail).ToList();
            List<Movie> ratedMovies = new List<Movie>();
            foreach (var item in URM)
            {
                Movie movie = _dbcontext.Movies.Find(item.movieId);
                ratedMovies.Add(movie);
            }
            TempData["rates"] = URM;
            TempData["userAcount"] = currentuser;
            return View(ratedMovies);
        }
        public IActionResult Profile()
        {
            var userEmail = HttpContext.Session.GetString("userEmail");
            if (userEmail == null)
            {
                return RedirectToAction("Login", "Profile");
            }
            var currentuser = _dbcontext.Users.Find(userEmail);
            if(currentuser == null)
            {
				return RedirectToAction("Login", "Profile");
			}
            return View(currentuser);
        }

        public IActionResult userTopTen()
        {
			var userEmail = HttpContext.Session.GetString("userEmail");
			if (userEmail == null)
			{
				return RedirectToAction("Login", "Profile");
			}
			var currentuser = _dbcontext.Users.Find(userEmail);
			List<UserRatedMovie> URM = _dbcontext.UserRatedMovies.Where(x => x.userEmail == userEmail).ToList();
            List<Movie> ratedMovies = new List<Movie>();
			foreach (var item in URM)
			{
				Movie movie = _dbcontext.Movies.Find(item.movieId);
				ratedMovies.Add(movie);
			}
            TempData["rates"] = URM;
			TempData["userAcount"] = currentuser;
			return View(ratedMovies);
        }
			public IActionResult Reviews()
        {
            var userEmail = HttpContext.Session.GetString("userEmail");
            if (userEmail == null)
            {
                return RedirectToAction("Login", "Profile");
            }
            var currentuser = _dbcontext.Users.Find(userEmail);
            List<UserReviewMovie> URSM = _dbcontext.UserReviewMovies.Where(x => x.userEmail == userEmail).ToList();
            List<Movie> reviedMovies = new List<Movie>();
            foreach (var item in URSM)
            {
                Movie movie = _dbcontext.Movies.Find(item.movieId);
                reviedMovies.Add(movie);
            }
            TempData["reviewdMovies"] = reviedMovies;
            TempData["userAcount"] = currentuser;
            return View(URSM);
        }
        public IActionResult changeAvatar()
        {
            var userEmail = HttpContext.Session.GetString("userEmail");
            if (userEmail == null)
            {
                return RedirectToAction("Login", "Profile");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> changeAvatarDatabase(IFormFile img_file)
        {
            var userEmail = HttpContext.Session.GetString("userEmail");
            if (userEmail == null)
            {
                return RedirectToAction("Login", "Profile");
            }
            string path = Path.Combine(_environment.WebRootPath, "userimage");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (img_file != null)
            {
                path = Path.Combine(path, img_file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await img_file.CopyToAsync(stream);
                }
            }
            var currentuser = _dbcontext.Users.Find(userEmail);
            currentuser.userAvatar = img_file.FileName;
            _dbcontext.SaveChanges();
            return RedirectToAction("Profile");
        }
        [HttpPost]
       
        public IActionResult ChangeInformation(string userAccountName, string newPassword)
        {
            var userEmail = HttpContext.Session.GetString("userEmail");
            if (userEmail == null)
            {
                return RedirectToAction("Login", "Profile");
            }
            var currentuser = _dbcontext.Users.Find(userEmail);
            if (userAccountName == null && newPassword == null)
            {
                return RedirectToAction("Profile");
            }
            else if (userAccountName == null)
            {
                currentuser.password = newPassword;
            }
            else if (newPassword == null)
            {
                currentuser.userAccountName = userAccountName;
            }
            else
            {
                currentuser.userAccountName = userAccountName;
                currentuser.password = newPassword;
            }
            _dbcontext.SaveChanges();
            return RedirectToAction("Profile");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterModel());
        }
        [HttpPost]
        public IActionResult Register(RegisterModel current)
        {
            if (ModelState.IsValid)
            {
                User currentUser = new User();
                currentUser.userEmail = current.userEmail;
                currentUser.password = current.password;
                currentUser.userAccountName = current.userAccountName;
                currentUser.userAvatar = "default.png";
                _dbcontext.Users.Add(currentUser);
                _dbcontext.SaveChanges();
                return RedirectToAction("Login", "Profile");
            }
            return View(current);
        }
        public IActionResult RemoveAccount()
        {
			var userEmail = HttpContext.Session.GetString("userEmail");
			var currentuser = _dbcontext.Users.Find(userEmail);
			if (userEmail == null)
			{
				return RedirectToAction("Login", "Profile");
			}
            _dbcontext.Remove(currentuser);
            _dbcontext.SaveChanges();
			return RedirectToAction("Login");
        }
        public IActionResult Search(string? search)
        {
            List<Movie> mov = _dbcontext.Movies.Where(x => x.movieName.ToLower() == search.ToLower()).ToList();
            var userEmail = HttpContext.Session.GetString("userEmail");
			if (userEmail == null)
			{
				return RedirectToAction("Login", "Profile");
			}
            ViewBag.searchName=search;
			var currentuser = _dbcontext.Users.Find(userEmail);
			TempData["userAcount"] = currentuser;
			return View(mov);
		}
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Profile");
		}
		[HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {   
            if (ModelState.IsValid)
            {
               var user=  _dbcontext.Users.FirstOrDefault(u => u.userEmail == model.userEmail);
				if (user !=null && user.password == model.password) 
                {
					HttpContext.Session.SetString("userEmail", user.userEmail);
					return RedirectToAction("Index", "Home");
                }
                else
                {
                        return RedirectToAction("Login");
                }
            }
            return View(model);
        }
        





























	}
}

