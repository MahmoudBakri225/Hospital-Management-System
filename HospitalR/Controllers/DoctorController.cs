using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        private readonly SampleDataDoctor sampleData;

        private static List<Reservation> reservations = new List<Reservation>();

        public DoctorController()
        {
            sampleData = new SampleDataDoctor();
        }

        public IActionResult Index()
        {
            var doctors = sampleData.doctors.ToList();
            return View(doctors);
        }

        public IActionResult CompleteAppointment(string name)
        {
            var doctor = sampleData.doctors.SingleOrDefault(d => d.Name == name);
            return View(doctor);
        }

        [HttpPost]
        public IActionResult CompleteAppointment(string DrName, DateTime appointmentDate, TimeSpan appointmentTime)
        {
            reservations.Add(new Reservation { DoctorName = DrName, AppointmentDate = appointmentDate, AppointmentTime = appointmentTime });
            return RedirectToAction("Index");
        }

        public IActionResult ReservationsManagement()
        {
            return View(reservations);
        }
    }
}
