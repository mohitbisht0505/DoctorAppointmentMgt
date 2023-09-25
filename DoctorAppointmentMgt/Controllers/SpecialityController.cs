using DoctorAppointmentMgt.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentMgt.Controllers
{
    public class SpecialityController : Controller
    {
        ApplicationDbContext db;
        List<Speciality> specialities;
        public SpecialityController(ApplicationDbContext db)
        {
            this.db = db;
            specialities = new List<Speciality>();
        }
        public IActionResult Index()
        {
            specialities = db.specialities.ToList();
            
            return View(specialities);
        }
        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Speciality pl)
        {
            //Add to DB
            db.specialities.Add(pl);
            db.SaveChanges();
            return RedirectToAction("Index", "Speciality");
        }

    }
}
