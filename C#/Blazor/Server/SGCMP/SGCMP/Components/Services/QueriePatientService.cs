namespace SGCMP.Components.Services;
using SGCMP.Components.Modules;

public class QueriePatientService : IQueriePatientService
{
    public List<QueriePatient> PatientList { get; set; } = new()
    {
        new QueriePatient("Carajito1", 1, "Un hueco en el pulmon", "si", 0, new DateTime(2025, 10, 20), 30, "pago movil"),
        new QueriePatient("Carlitos Juan Casas Azul", 19, "Gripe", "Roberto Buena Vista Azul", 4122453127, new DateTime(2024, 12, 29), 30, "Seguro"),
        new QueriePatient("Carlitos Juan Casas Azul", 19, "Gripe", "Roberto Buena Vista Azul", 4122453127, new DateTime(2024, 12, 29), 30, "Seguro"),
        new QueriePatient("Carlitos Juan Casas Azul", 19, "Gripe", "Roberto Buena Vista Azul", 4122453127, new DateTime(2024, 12, 29), 30, "Seguro"),
        new QueriePatient("Carlitos Juan Casas Azul", 19, "Gripe", "Roberto Buena Vista Azul", 4122453127, new DateTime(2024, 12, 29), 30, "Seguro"),
        new QueriePatient("Carlitos Juan Casas Azul", 19, "Gripe", "Roberto Buena Vista Azul", 4122453127, new DateTime(2024, 12, 29), 30, "Seguro"),
    };

    public void AddPatient(QueriePatient patient){}
    public void UpdatePatient(QueriePatient patient){}
}