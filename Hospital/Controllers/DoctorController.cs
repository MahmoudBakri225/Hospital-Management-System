using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        SampleDataDoctor sampleData = new SampleDataDoctor();
        public IActionResult Index()
        {
            var r = sampleData.doctors.ToList();
            return View(r);
        }
        public IActionResult CompleteAppointment(string Name)
        {
            var doctor = sampleData.doctors.Single(p => p.Name == Name);

            return View(doctor);
        }
    }
}
