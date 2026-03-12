namespace SGCMP.Components.Services;
using SGCMP.ModelsDB;

public interface IOperationDbServices
{
    Task<List<Patient>> GetPatients();
    Task<Patient?> GetPatientById(int id);
    Task CreatePatientAsync(Patient patient);
    Task DeletePatientAsync(Patient patient);
    Task UpdatePatientAsync(Patient patient);
    
    Task<List<AntecedentPerson>> GetAntecedentPersons(int id);
    Task CreateAntecedentPersonAsync(AntecedentPerson antecedentPerson);
    Task DeleteAntecedentPersonAsync(AntecedentPerson antecedentPerson);
    Task UpdateAntecedentPersonAsync(AntecedentPerson antecedentPerson);
    
    Task<List<Codition>> GetCoditions(int id);
    Task CreateCoditionAsync(Codition codition);
    Task DeleteCoditionAsync(Codition codition);
    Task UpdateCoditionAsync(Codition codition);
    
    Task<List<Diagnosis>> GetDiagnosis(int id);
    Task CreateDiagnosisAsync(Diagnosis diagnosis);
    Task DeleteDiagnosisAsync(Diagnosis diagnosis);
    Task UpdateDiagnosisAsync(Diagnosis diagnosis);
    
    Task<List<FamilyHistory>> GetFamilyHistories(int id);
    Task CreateFamilyHistoryAsync(FamilyHistory familyHistory);
    Task DeleteFamilyHistoryAsync(FamilyHistory familyHistory);
    Task UpdateFamilyHistoryAsync(FamilyHistory familyHistory);
    
    Task<List<Laboratory>> GetLaboratories(int id);
    Task CreateLaboratoryAsync(Laboratory laboratory);
    Task DeleteLaboratoryAsync(Laboratory laboratory);
    Task UpdateLaboratoryAsync(Laboratory laboratory);
    
    Task<List<PersonDatum>> GetPersonData(int id);
    Task CreatePersonDataAsync(PersonDatum person);
    Task DeletePersonDataAsync(PersonDatum person);
    Task UpdatePersonDataAsync(PersonDatum person);
    
    Task<List<PhysicalExam>> GetPhysicalExams(int id);
    Task CreatePhysicalExamAsync(PhysicalExam physicalExam);
    Task DeletePhysicalExamAsync(PhysicalExam physicalExam);
    Task UpdatePhysicalExamAsync(PhysicalExam physicalExam);
    
    Task<List<Pregnancy>> GetPregnancy(int id);
    Task CreatePregnancyAsync(Pregnancy pregnancy);
    Task DeletePregnancyAsync(Pregnancy pregnancy);
    Task UpdatePregnancyAsync(Pregnancy pregnancy);

    Task<List<Consult>> GetConsult(int id);
    Task CreateConsultAsync(Consult consult);
    Task DeleteConsultAsync(Consult consult);
    Task UpdateConsultAsync(Consult consult);
    Task<Consult> GetConsultById(int id);
}