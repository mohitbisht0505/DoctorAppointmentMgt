using DoctorAppointmentMgt.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentMgt.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDbContext db;
        Patient patient;
        Doctor doctor;
        
        public LoginController(ApplicationDbContext db)
        {
            this.db = db;
            patient = new Patient();
            doctor= new Doctor();

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            var checkEmail=db.patients.FirstOrDefault(x => x.Email == email&& x.Password==password);
            
            //var checkPassword = db.patients.FirstOrDefault(x => x.Password == password);
            if (checkEmail != null)
            {
                if (checkEmail.Email == "bishtmohit094@gmail.com" && checkEmail.Password == "Mohit@123")
                {
                    TempData["error"] = "you're an Admin please select Admin login";

                    return View("Login");
                }

                else
                {
                    HttpContext.Session.SetString("patientName", checkEmail.Name);
                    HttpContext.Session.SetString("patientMobile", checkEmail.PhoneNo.ToString());
                    HttpContext.Session.SetString("patientEmail", checkEmail.Email);


                    //TempData["PatientName"] = checkEmail.Name;
                    return RedirectToAction("Index", "Home");
                }



            }

            else 
            {
                TempData["invalid"] = "Invalid email or password";
                return View();

            }

        }
        public IActionResult AdminLogin() {
            TempData["admin"] = "Admin";
            return View("Login");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminLogin(string email,string password) { 
        var data=db.patients.FirstOrDefault(patient => patient.Email == email && patient.Password == password);
            if (data != null)
            {
                if (data.Email == "bishtmohit094@gmail.com" && data.Password == "Mohit@123")
                {
                    //TempData["name"] = data.Name;
                    HttpContext.Session.SetString("adminName", data.Name);
                    return RedirectToAction("Index", "Patient");
                }
                else
                {
                    return View(null);
                }
                
            }
            else
            {
                return View(null);
            }
        }
        public  IActionResult LogOut()
        {
            HttpContext.Session.Clear();


            return View("Login");
            //var AdminName = TempData["name"];
            //var removePatient = TempData["PatientName"];
            //if (removePatient != null)
            //{
            //    TempData.Remove("removePatient");
            //    return RedirectToAction("Login", "Login");
            //}
            //else if (AdminName != null)
            //{
            //    TempData.Remove("AdminName");
            //    return RedirectToAction("Login", "Login");

            //}


        }
        

    }
}
