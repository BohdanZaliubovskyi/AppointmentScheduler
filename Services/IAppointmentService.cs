using AppointmentScheduling.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Services
{
    public interface IAppointmentService
    {
        List<DoctorVM> GetDoctorList();
        List<PatientVM> GetPatientList();
        Task<int> AdUpdate(AppointmentVM model);

        List<AppointmentVM> DoctorsEventsById(string doctorId);
        List<AppointmentVM> PatientsEventsById(string patientId);

        AppointmentVM GetById(int id);
        Task<int> Delete(int id);
        Task<int> ConfirmEvent(int id);
    }
}
