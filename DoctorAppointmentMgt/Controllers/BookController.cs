using DoctorAppointmentMgt.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentMgt.Controllers
{
    public class BookController : Controller
    {
        ApplicationDbContext db;
       // List<Appointment> appoinement;
        List<Doctor> doctor;
        List<Patient> patient;
        List<Book> book;

        //List<Speciality> speciality;
        public BookController(ApplicationDbContext db)
        {
            this.db = db;
            doctor = new List<Doctor>();
            patient = new List<Patient>();
            //appoinement = new List<Appointment>();
            book = new List<Book>();   

        }
        [HttpPost]
        public IActionResult Book(int id)
        {
            var list=db.doctors.FirstOrDefault(x=>x.DoctorId== id);
            if (list != null) {
                HttpContext.Session.SetString("name", list.Name);
                HttpContext.Session.SetString("speciality", list.Speciality);
                HttpContext.Session.SetString("startTime", list.StartTime);
                HttpContext.Session.SetString("endTime", list.EndTime);
                HttpContext.Session.SetString("fees", list.Fees.ToString());
                HttpContext.Session.GetString("patientName");
                return View();
                    }
            else
            {
                return View(null);
            }
        }
        



        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookApp(Book book)
        {

            return View();
        }

    }
}
