using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieSiteAgainAgain.Data;
using movieSiteAgainAgain.Models;

namespace movieSiteAgainAgain.Controllers
{
    public class MovieController : Controller
    {
		private readonly ApplicationDbContext _dbcontext;
		public MovieController(ApplicationDbContext context)
		{
			_dbcontext = context;
		}
		[HttpPost]
		public IActionResult currentReview(int id, string name)
        {
			var userEmail = HttpContext.Session.GetString("userEmail");
			if (userEmail == null)
			{
				return RedirectToAction("Login", "Profile");
			}
			ViewBag.id=id;
			ViewBag.name=name;
            var state = _dbcontext.UserReviewMovies.FirstOrDefault(r => r.movieId == id && r.userEmail == userEmail);
			if (state != null)
			{
				ViewBag.error = "*your last Review will be Modified";
			}
            return View();
        }
        public IActionResult AddToFavorite(int id)
		{
			UserFavoriteMovief favoriteMovie = new UserFavoriteMovief();
			var userEmail = HttpContext.Session.GetString("userEmail");
			if (userEmail == null)
			{
				return RedirectToAction("Login", "Profile");
			}
			var currentuser = _dbcontext.Users.Find(userEmail);
			var state = _dbcontext.UserFavoriteMoviefs.FirstOrDefault(r => r.movieId == id && r.userEmail == currentuser.userEmail);
			if (state == null)
			{
				favoriteMovie.userEmail = currentuser.userEmail;
				favoriteMovie.movieId = id;
				_dbcontext.UserFavoriteMoviefs.Add(favoriteMovie);
			}
			else
			{
				_dbcontext.UserFavoriteMoviefs.Remove(state);
			}
			_dbcontext.SaveChanges();
			return RedirectToAction("moviesingle",new{id=id});
		}
		public IActionResult moviesingle(int? id)
        {
			var userEmail = HttpContext.Session.GetString("userEmail");
			if (userEmail == null)
			{
				return RedirectToAction("Login", "Profile");
			}
			Movie movie = new Movie();
            movie = _dbcontext.Movies.Find(id);
			UserRatedMovie userRateThisMovie = _dbcontext.UserRatedMovies.FirstOrDefault(r => r.movieId == id && r.userEmail == userEmail);
            UserReviewMovie reviewMovie = new UserReviewMovie();
            List<UserReviewMovie> state = _dbcontext.UserReviewMovies.Where(r => r.movieId == id).ToList();
			List<User> userInReview = new List<User>();

            foreach (var item in state)
			{
				User currentUser=_dbcontext.Users.Find(item.userEmail);
				userInReview.Add(currentUser);
			}
			TempData["userInReview"]=userInReview;
			TempData["Rvws"] = state;
			if(userRateThisMovie != null)
			{
				ViewBag.rate = userRateThisMovie.rate;
			}
			else
			{
				ViewBag.rate = 0;
			}
            List<ActorInMovie> actorsInMovie = _dbcontext.ActorInMovies.Where(x => x.movieId == id).ToList();
            TempData["AIM"] = actorsInMovie;
			return View(movie);
        }

		public IActionResult AddRate(int id,int rate)
		{
			var userEmail = HttpContext.Session.GetString("userEmail");
			if (userEmail == null)
			{
				return RedirectToAction("Login", "Profile");
			}
			UserRatedMovie rateMovie = new UserRatedMovie();
			var state = _dbcontext.UserRatedMovies.FirstOrDefault(r => r.movieId == id && r.userEmail == userEmail);
			if (state == null)
			{
				rateMovie.userEmail = userEmail;
				rateMovie.movieId = id;
				rateMovie.rate = rate;
				_dbcontext.UserRatedMovies.Add(rateMovie);
			}
			else
			{
				state.rate = rate; 
			}
			_dbcontext.SaveChanges();
			return RedirectToAction("moviesingle", new { id = id });
		}

		public IActionResult AddReview(int id,string review,string headReview)
		{
			var userEmail = HttpContext.Session.GetString("userEmail");
			if (userEmail == null)
			{
				return RedirectToAction("Login", "Profile");
			}
			UserReviewMovie reviewMovie = new UserReviewMovie();
			var state = _dbcontext.UserReviewMovies.FirstOrDefault(r => r.movieId == id && r.userEmail == userEmail);
			if (state == null)
			{
                reviewMovie.userEmail = userEmail;
				reviewMovie.movieId = id;
				reviewMovie.headReview = headReview;
                reviewMovie.movieReview = review;
				DateTime currentDate = DateTime.Now;
				reviewMovie.reviewDate = currentDate.ToString();
                _dbcontext.UserReviewMovies.Add(reviewMovie);
			}
			else
			{
				state.headReview = headReview;
				state.movieReview = review;
			}
			_dbcontext.SaveChanges();
			return RedirectToAction("moviesingle", new { id = id });
		}
		public IActionResult celebritysingle(int actId)
        {
			var userEmail = HttpContext.Session.GetString("userEmail");
			if (userEmail == null)
			{
				return RedirectToAction("Login", "Profile");
			}
			Actor act = _dbcontext.Actors.Find(actId);
			List<ActorInMovie> thisActorInMovies = _dbcontext.ActorInMovies.Where(x => x.actorId == actId).ToList();
			List<Movie> thisMovieList = new List<Movie>();
			foreach (var item in thisActorInMovies)
			{
				Movie currentMovie = _dbcontext.Movies.Find(item.movieId);
				thisMovieList.Add(currentMovie);
			}
			ViewBag.thisActorInMovies = thisActorInMovies;
			TempData["thisMovieList"] = thisMovieList;
			return View(act);
        }
    }
}
