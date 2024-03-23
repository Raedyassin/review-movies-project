using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using movieSiteAgainAgain.Data;
using movieSiteAgainAgain.Models;
using System.Diagnostics;

namespace movieSiteAgainAgain.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbcontext;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			_logger = logger;
            _dbcontext = context;

        }
		public IActionResult Index()
		{
			var userEmail = HttpContext.Session.GetString("userEmail");
			if (userEmail == null)
			{
				return RedirectToAction("Login", "Profile");
			}
			if (string.IsNullOrEmpty(userEmail) )
			{
				return RedirectToAction("Login","Profile");
			}
			List<Movie> movies = _dbcontext.Movies.ToList();
			return View(movies);
		}
        



        

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}