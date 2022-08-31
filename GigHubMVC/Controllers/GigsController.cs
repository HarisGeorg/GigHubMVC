using GigHubMVC.Models;
using GigHubMVC.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHubMVC.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Gigs

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            //var artistId = User.Identity.GetUserId();
            //var artist = _context.Users.Single(u => u.Id == artistId);  //den xriazetai SignleOrDefault giati exo sigoura Id opote den kindinevo na min to vro kai na skasei
            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            var gig = new Gig()
            {
                //Artist = artist,
                ArtistId = User.Identity.GetUserId(),
                DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                Venue = viewModel.Venue,
                //Genre = genre
                GenreId = viewModel.Genre
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}