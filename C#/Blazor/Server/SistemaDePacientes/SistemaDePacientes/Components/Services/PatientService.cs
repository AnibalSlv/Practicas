using System.Diagnostics;
namespace SistemaDePacientes.Components.Services;
using SistemaDePacientes.Components.Modules;

public class PatientService : IPatientService
{
    public Queue<Patient> PatientQueueRed { get; set; } = new() { };
    public Queue<Patient> PatientQueueYellow { get; set; } = new() { };
    public Queue<Patient> PatientQueueGreen { get; set; } = new() { };

    // Agrega a la lista el objeto (el paciente)
    public void AddPatient(Patient patient)
    {
        if (patient.AttetionLevel.ToLower() == "red")
        {
            PatientQueueRed.Enqueue(patient);
        } else if (patient.AttetionLevel.ToLower() == "yellow")
        {
            PatientQueueYellow.Enqueue(patient);
        } else if (patient.AttetionLevel.ToLower() == "green")
        {
            PatientQueueGreen.Enqueue(patient);
        } 
    }

    public void DeletePatient()
    {
        if (PatientQueueRed.Any())
        {
            PatientQueueRed.Dequeue();
        } else if (PatientQueueYellow.Any())
        {
            PatientQueueYellow.Dequeue();
        } else if (PatientQueueGreen.Any())
        {
            PatientQueueGreen.Dequeue();
        }
    }

    // Actializa el estado del paciente
    /*
     * Verifica si el paciente existe verificando cada elemento de la lista y se detiene hasta encontrar a uno
     * Si no encuentra a uno entonces devuelve por defecto null y en el caso de encontrar a uno entonces
     * existing obtiene las propiedades del objeto que encontro y los reemplaza por los nuevos datos que se pasan
     * por el parametro de la funcion
     * public void UpdatePatient(Patient patient)
     * {
     *     var existing = PatientListRed.FirstOrDefault(p => p.Id == patient.Id);
     *     if (existing != null)
     *     {
     *         existing.Name = patient.Name;
     *         existing.LastName = patient.LastName;
     *         existing.Age = patient.Age;
     *         existing.AttetionLevel = patient.AttetionLevel;
     *     }
     * }
     */
}