namespace SistemaDePacientes.Components.Services;
using SistemaDePacientes.Components.Modules;

public interface IPatientService
{
    Queue<Patient> PatientQueueRed { get; set; }
    Queue<Patient> PatientQueueYellow { get; set; }
    Queue<Patient> PatientQueueGreen { get; set; }
    void AddPatient(Patient patient);
    // XXX void UpdatePatient(Patient patient);
    void DeletePatient();
}