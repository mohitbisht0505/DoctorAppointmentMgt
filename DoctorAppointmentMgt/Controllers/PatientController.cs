using DoctorAppointmentMgt.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentMgt.Controllers
{
    public class PatientController : Controller
    {
        ApplicationDbContext db;
        List<Patient> patients;
        public PatientController(ApplicationDbContext db)
        {
            this.db = db;
            patients = new List<Patient>();
        }
        public IActionResult Index()
         {

            patients = db.patients.ToList();
            return View(patients);
            
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient pt)
        {
            db.patients.Add(pt);
            db.SaveChanges();
            

            return RedirectToAction("Index","Patient");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnDelete(int id)
        {

            var del = db.patients.FirstOrDefault(x => x.PatientId == id);
            if (del != null)
            {
                db.patients.Remove(del);
                db.SaveChanges();

                return RedirectToAction("index", "Patient");
            }
            else
            {
                return View(null);
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id)
        {
            var data = db.patients.FirstOrDefault(x => x.PatientId == id);
            if (data != null)
            {
                
                return View(data);
            }
            else
            {
                return View(null);
            }
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Patient p)
        {
            var listUp=db.patients.FirstOrDefault(x=>x.PatientId==p.PatientId);
            if (listUp!=null)
            {
                listUp.Name = p.Name;
                listUp.Age=p.Age;
                listUp.Address = p.Address;
                listUp.Gender = p.Gender;
                listUp.PhoneNo = p.PhoneNo;
                listUp.Email = p.Email;
                listUp.Password = p.Password;
                db.patients.Update(listUp);
                db.SaveChanges();
                return RedirectToAction("Index","Patient");

            }
            else
            {
                return View(null);
            }
            
        }

        }
        
    }


