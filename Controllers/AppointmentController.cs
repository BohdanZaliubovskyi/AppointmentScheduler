using AppointmentScheduling.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduling.Utility;
using Microsoft.AspNetCore.Authorization;

namespace AppointmentScheduling.Controllers
{
    [Authorize/*(Roles = Helper.Admin)/*We can also choose roles here for specific users*/] // hide calendar control from unauthorized user
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        //[Authorize(Roles = Helper.Admin)]
        public IActionResult Index()
        {
            ViewBag.DoctorList = _appointmentService.GetDoctorList();
            ViewBag.Duration = Helper.GetTimeDropDown();
            ViewBag.PatientList = _appointmentService.GetPatientList();

            return View();
        }
    }
}
