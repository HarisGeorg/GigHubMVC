using GigHubMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHubMVC.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }     //sti vasi tha paei ena genre id opote to byte moy arkei. Edo tha kataxoriso to epilegmeno Genre
        public ICollection<Genre> Genres { get; set; }  //tha fortosei to dropdown pou tha epilekso to genre

    }
}