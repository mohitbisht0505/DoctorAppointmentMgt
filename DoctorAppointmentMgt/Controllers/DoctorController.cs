using DoctorAppointmentMgt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointmentMgt.Controllers
{
    public class DoctorController : Controller
    {
        ApplicationDbContext db;
        List<Doctor> doctor;
        List<Speciality> speciality;
        
        public DoctorController(ApplicationDbContext db)
        {
            this.db = db;
            doctor = new List<Doctor>();
            speciality = new List<Speciality>();
        }

        public IActionResult Index()
        {
            var doctor = db.doctors.ToList();
            return View(doctor);
        }
        public IActionResult PatientDoctor()
        {

            var patientdoctor = db.doctors.ToList();

            return View(patientdoctor);
            
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor d)
        {
            var data=db.doctors.Add(d);
            if (data != null)
            {
                db.SaveChanges();
                return RedirectToAction("Index", "Doctor");
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var data = db.doctors.FirstOrDefault(x => x.DoctorId == id);
            if (data != null)
            {
                db.doctors.Remove(data);
                db.SaveChanges();
                return RedirectToAction("Index","Doctor");
            }
            else
            {
                return View(null);
            }
        }
        public IActionResult Edit(int id)
        {
            var data=db.doctors.FirstOrDefault(x=>x.DoctorId==id);
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
        public IActionResult Update(Doctor dc)
        {
            var data=db.doctors.FirstOrDefault(x=>x.DoctorId==dc.DoctorId);
            if(data!=null)
            {
                data.Name=dc.Name;
                data.Age = dc.Age;
                data.Experience = dc.Experience;
                data.Gender = dc.Gender;
                data.Fees = dc.Fees;
                data.Speciality = dc.Speciality;
                data.StartTime = dc.StartTime;
                data.EndTime = dc.EndTime;
                db.doctors.Update(data);
                db.SaveChanges();
                return RedirectToAction("Index", "Doctor");
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public IActionResult Search(string spname,string name)
         {
            
           if (name != null)
            {
                var sname = db.doctors.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
                if (sname != null)
                {
                    //TempData["searchData"] = sname;
                    return View("PatientDoctor", sname);
                }
                else
                {
                TempData["nameNotFound"] = "invalid name";
                    return View("PatientDoctor");

                }
            }
             else if (spname != null)
            {
                var specname = db.doctors.Where(x => x.Speciality==spname).ToList();
                if (specname!=null)
                {
                    return View("PatientDoctor", specname);                    
                }
                else {
                    var patientdoctorlist = db.doctors.ToList();
                    TempData["SpecialityNotFound"] = "invalid speciality";
                    return View("PatientDoctor", patientdoctorlist);
                }
            }
            else{
                var patientdoctorlist = db.doctors.ToList();
                TempData["NotFound"] = "please enter speciality name or doctor name";
                return View("PatientDoctor", patientdoctorlist);
            }



        }


    }
}
