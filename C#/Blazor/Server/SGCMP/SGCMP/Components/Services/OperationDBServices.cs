using SGCMP.Components.Layout.DetailPatient;

namespace SGCMP.Components.Services;

using SGCMP.ModelsDB;

// Importante esto para que puedas crear el _dbFactory y poder hacer las conexiones
using Microsoft.EntityFrameworkCore;

public class OperationDbServices : IOperationDbServices
{
    //Nota: Siempre deves de usar await si vas a usar el context
    
    // Importante haber utilizado este comando:
    // dotnet ef dbcontext scaffold "Data Source=TuBaseDeDatos.db" Microsoft.EntityFrameworkCore.Sqlite -o ModelsDb
    // ademas de haber descargado los nuget, el archivo que usaras es el que termina con "Context"

    // Esta variable guardará la "fábrica" que configuramos en Program.cs
    private readonly IDbContextFactory<PatientDbContext> _dbFactory;

    public OperationDbServices(IDbContextFactory<PatientDbContext> dbFactory) // Esto es el metodo constructor recuerda
    {
        _dbFactory = dbFactory;
    }

    // ----------------------------------------------- Patients ----------------------------------------------
    public async Task<List<Patient>> GetPatients()
    {
        // using asegura que la conexion se cierre y se limpie al terminar
        // .CreateDbContext crea una conexion al archivo .db (en este caso PatientDbContext)
        using var context = _dbFactory.CreateDbContext();

        // Se coloca Patients porque es lo que esta en mi Db
        return await context.Patients.ToListAsync();
    }
    
    public async Task<Patient?> GetPatientById(int id)
    {
        using var context = _dbFactory.CreateDbContext();

        return await context.Patients
            .FirstOrDefaultAsync(p => p.IdPatient == id);
    }

    public async Task CreatePatientAsync(Patient patient)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Patients.Add(patient);

        // SaveChangesAsync ejecuta en "INSERT INTO" en el archivo SQLite
        await context.SaveChangesAsync();
    }

    public async Task DeletePatientAsync(Patient pantient)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Patients.Remove(pantient);

        await context.SaveChangesAsync();
    }

    public async Task UpdatePatientAsync(Patient patient)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Patients.Update(patient);

        await context.SaveChangesAsync();
    }

    // ----------------------------------------------- Antecedents Person ----------------------------------------------
    //FIXED -------------------------------------------------------------------------------------------------

    public async Task<List<AntecedentPerson>> GetAntecedentPersons(int id)
    {
        using var context = _dbFactory.CreateDbContext();

        return await context.AntecedentPeople.Where(a => a.PkPatient == id).ToListAsync();
    }

    public async Task CreateAntecedentPersonAsync(AntecedentPerson antecedentPerson)
    {
        using var context = _dbFactory.CreateDbContext();

        context.AntecedentPeople.Add(antecedentPerson);

        await context.SaveChangesAsync();
    }

    public async Task DeleteAntecedentPersonAsync(AntecedentPerson antecedentPerson)
    {
        using var context = _dbFactory.CreateDbContext();

        context.AntecedentPeople.Remove(antecedentPerson);

        await context.SaveChangesAsync();
    }

    public async Task UpdateAntecedentPersonAsync(AntecedentPerson antecedentPerson)
    {
        using var context = _dbFactory.CreateDbContext();

        context.AntecedentPeople.Update(antecedentPerson);

        await context.SaveChangesAsync();
    }

    // ----------------------------------------------- Conditions ----------------------------------------------

    public async Task<List<Codition>> GetCoditions(int id)
    {
        using var context = _dbFactory.CreateDbContext();

        return await context.Coditions.Where(c => c.PkPatient == id).ToListAsync();
    }

    public async Task CreateCoditionAsync(Codition codition)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Coditions.Add(codition);

        await context.SaveChangesAsync();
    }

    public async Task DeleteCoditionAsync(Codition codition)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Coditions.Remove(codition);

        await context.SaveChangesAsync();
    }

    public async Task UpdateCoditionAsync(Codition codition)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Coditions.Update(codition);

        await context.SaveChangesAsync();
    }
    
    // ----------------------------------------------- Diagnosis ----------------------------------------------

    public async Task<List<Diagnosis>> GetDiagnosis(int id)
    {
        using var context = _dbFactory.CreateDbContext();

        return await context.Diagnoses.Where(d => d.PkPatient == id).ToListAsync();
    }

    public async Task CreateDiagnosisAsync(Diagnosis diagnosis)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Diagnoses.Add(diagnosis);

        await context.SaveChangesAsync();
    }

    public async Task DeleteDiagnosisAsync(Diagnosis diagnosis)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Diagnoses.Remove(diagnosis);

        await context.SaveChangesAsync();
    }

    public async Task UpdateDiagnosisAsync(Diagnosis diagnosis)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Diagnoses.Update(diagnosis);

        await context.SaveChangesAsync();
    }
    
    // ----------------------------------------------- Family History ----------------------------------------------

    public async Task<List<FamilyHistory>> GetFamilyHistories(int id)
    {
        using var context = _dbFactory.CreateDbContext();

        return await context.FamilyHistories.Where(f => f.PkPatient == id).ToListAsync();
    }

    public async Task CreateFamilyHistoryAsync(FamilyHistory familyHistory)
    {
        using var context = _dbFactory.CreateDbContext();

        context.FamilyHistories.Add(familyHistory);

        await context.SaveChangesAsync();
    }

    public async Task DeleteFamilyHistoryAsync(FamilyHistory familyHistory)
    {
        using var context = _dbFactory.CreateDbContext();

        context.FamilyHistories.Remove(familyHistory);

        await context.SaveChangesAsync();
    }

    public async Task UpdateFamilyHistoryAsync(FamilyHistory familyHistory)
    {
        using var context = _dbFactory.CreateDbContext();

        context.FamilyHistories.Update(familyHistory);

        await context.SaveChangesAsync();
    }
    
    // ----------------------------------------------- Laboratory ----------------------------------------------

    public async Task<List<Laboratory>> GetLaboratories(int id)
    {
        using var context = _dbFactory.CreateDbContext();

        return await context.Laboratories.Where(l => l.PkPatient == id).ToListAsync();     
    }

    public async Task CreateLaboratoryAsync(Laboratory laboratory)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Laboratories.Add(laboratory);

        await context.SaveChangesAsync();
    }

    public async Task DeleteLaboratoryAsync(Laboratory laboratory)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Laboratories.Remove(laboratory);

        await context.SaveChangesAsync();
    }

    public async Task UpdateLaboratoryAsync(Laboratory laboratory)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Laboratories.Update(laboratory);

        await context.SaveChangesAsync();
    }
    
    // ----------------------------------------------- Person Data ----------------------------------------------

    public async Task<List<PersonDatum>> GetPersonData(int id)
    {
        using var context = _dbFactory.CreateDbContext();

        return await context.PersonData.Where(p => p.PkPatient == id).ToListAsync();   
    }

    public async Task CreatePersonDataAsync(PersonDatum person)
    {
        using var context = _dbFactory.CreateDbContext();

        context.PersonData.Add(person);

        await context.SaveChangesAsync();
    }

    public async Task DeletePersonDataAsync(PersonDatum person)
    {
        using var context = _dbFactory.CreateDbContext();

        context.PersonData.Remove(person);

        await context.SaveChangesAsync();
    }

    public async Task UpdatePersonDataAsync(PersonDatum person)
    {
        using var context = _dbFactory.CreateDbContext();

        context.PersonData.Update(person);

        await context.SaveChangesAsync();
    }
    
    // ----------------------------------------------- Physical Exam ----------------------------------------------

    public async Task<List<PhysicalExam>> GetPhysicalExams(int id)
    {
        using var context = _dbFactory.CreateDbContext();

        return await context.PhysicalExams.Where(p => p.PkPatient == id).ToListAsync();
    }

    public async Task CreatePhysicalExamAsync(PhysicalExam physicalExam)
    {
        using var context = _dbFactory.CreateDbContext();

        context.PhysicalExams.Add(physicalExam);

        await context.SaveChangesAsync();
    }
    
    public async Task DeletePhysicalExamAsync(PhysicalExam physicalExam)
    {
        using var context = _dbFactory.CreateDbContext();

        context.PhysicalExams.Remove(physicalExam);

        await context.SaveChangesAsync();
    }

    public async Task UpdatePhysicalExamAsync(PhysicalExam physicalExam)
    {
        using var context = _dbFactory.CreateDbContext();

        context.PhysicalExams.Update(physicalExam);

        await context.SaveChangesAsync();
    }
    
    // ----------------------------------------------- Pregnancy ----------------------------------------------

    public async Task<List<Pregnancy>> GetPregnancy(int id)
    {
        using var context = _dbFactory.CreateDbContext();

        return await context.Pregnancies.Where(p => p.PkPatient == id).ToListAsync();
    }

    public async Task CreatePregnancyAsync(Pregnancy pregnancy)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Pregnancies.Add(pregnancy);

        await context.SaveChangesAsync();
    }

    public async Task DeletePregnancyAsync(Pregnancy pregnancy)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Pregnancies.Remove(pregnancy);

        await context.SaveChangesAsync();
    }

    public async Task UpdatePregnancyAsync(Pregnancy pregnancy)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Pregnancies.Update(pregnancy);

        await context.SaveChangesAsync();
    }
    
    //-------------------------------------- Consultas ------------------------------------------

    public async Task<List<Consult>> GetConsult(int id)
    {
        using var context = _dbFactory.CreateDbContext();

        return await context.Consults
            .Where(c => c.PkPatient == id)
            //Esto permite acceder a las propiedades de la tabla diagnotico (importante el Navigation (son 2 diferentes)
            .Include(c => c.PkDiagnosisNavigation)
            .ToListAsync();
    }

    public async Task CreateConsultAsync(Consult consult)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Consults.Add(consult);

        await context.SaveChangesAsync();
    }

    public async Task DeleteConsultAsync(Consult consult)
    {
        using var context = _dbFactory.CreateDbContext();

        context.Consults.Remove(consult);

        await context.SaveChangesAsync();
    }

    public async Task UpdateConsultAsync(Consult consult)
    {
        using var context = _dbFactory.CreateDbContext();
        
        context.Consults.Update(consult);

        await context.SaveChangesAsync();
    }
    
    public async Task<Consult> GetConsultById(int idConsult) // <-- Debe decir Task<Consult>, NO void
    {
        using var context = _dbFactory.CreateDbContext();
    
        // Es vital usar Include para que los datos relacionados no lleguen nulos
        return await context.Consults
            .Include(c => c.PkLaboratoryNavigation)
            .Include(c => c.PkPhysicalExamNavigation)
            .Include(c => c.PkConditionNavigation)
            .Include(c => c.PkDiagnosisNavigation)
            .FirstOrDefaultAsync(c => c.IdConsult == idConsult);
    }
}