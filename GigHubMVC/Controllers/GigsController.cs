using GigHubMVC.Models;
using GigHubMVC.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();

            return View(gigs);
        }

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
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            //var artistId = User.Identity.GetUserId();
            //var artist = _context.Users.Single(u => u.Id == artistId);  //den xriazetai SignleOrDefault giati exo sigoura Id opote den kindinevo na min to vro kai na skasei
            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);


            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();    //Ksanafortono ta Genres oste otan paei na fortoseo to Create View na ta exei gia tin DropDown
                return View("Create", viewModel);               //fortonei to view Create.schtml stelnontas tou to viewModel
            }

            var gig = new Gig()
            {
                //Artist = artist,
                ArtistId = User.Identity.GetUserId(),
                //DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),     To steila sto GigFormViewModel
                DateTime = viewModel.GetGetTime(),
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