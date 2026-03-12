namespace SGCMP.Components.Services;
using SGCMP.Components.Modules;

public interface IQueriePatientService
{
    List<QueriePatient> PatientList {get; set;}
    void UpdatePatient(QueriePatient patient);
    void AddPatient(QueriePatient patient);
}