using GigHubMVC.Dtos;
using GigHubMVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHubMVC.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)     //([FromBody] int gidId)  apo to body tis formas tha rthei to Id pou einai int
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
            {
                return BadRequest("The attendance already exists");
            }

            var attendance = new Attendance()
            {
                GigId = dto.GigId,
                AttendeeId = User.Identity.GetUserId()
                
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
