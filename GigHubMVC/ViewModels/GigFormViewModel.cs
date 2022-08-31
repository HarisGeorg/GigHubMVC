using GigHubMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHubMVC.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }     //sti vasi tha paei ena genre id opote to byte moy arkei. Edo tha kataxoriso to epilegmeno Genre

        public ICollection<Genre> Genres { get; set; }  //tha fortosei to dropdown pou tha epilekso to genre

        public DateTime GetGetTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}