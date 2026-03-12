using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SGCMP.ModelsDB;

public partial class PatientDbContext : DbContext
{
    public PatientDbContext()
    {
    }

    public PatientDbContext(DbContextOptions<PatientDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AntecedentPerson> AntecedentPeople { get; set; }

    public virtual DbSet<Codition> Coditions { get; set; }

    public virtual DbSet<Consult> Consults { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<FamilyHistory> FamilyHistories { get; set; }

    public virtual DbSet<Laboratory> Laboratories { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PersonDatum> PersonData { get; set; }

    public virtual DbSet<PhysicalExam> PhysicalExams { get; set; }

    public virtual DbSet<Pregnancy> Pregnancies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=patientDB.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AntecedentPerson>(entity =>
        {
            entity.HasKey(e => e.IdAntecedentPerson);

            entity.ToTable("antecedent_person");

            entity.Property(e => e.IdAntecedentPerson).HasColumnName("id_antecedent_person");
            entity.Property(e => e.Allergy).HasColumnName("allergy");
            entity.Property(e => e.AsthmaLastCrisis).HasColumnName("asthma_last_crisis");
            entity.Property(e => e.AsthmaTreatment).HasColumnName("asthma_treatment");
            entity.Property(e => e.DiabetesMedicine).HasColumnName("diabetes_medicine");
            entity.Property(e => e.HospitalizationExplanation).HasColumnName("hospitalization_explanation");
            entity.Property(e => e.HtaTreatment).HasColumnName("hta_treatment");
            entity.Property(e => e.NephropathyTreatment).HasColumnName("nephropathy_treatment");
            entity.Property(e => e.PkPatient).HasColumnName("pk_patient");
            entity.Property(e => e.SurgicalExplanation).HasColumnName("surgical_explanation");

            entity.HasOne(d => d.PkPatientNavigation).WithMany(p => p.AntecedentPeople).HasForeignKey(d => d.PkPatient);
        });

        modelBuilder.Entity<Codition>(entity =>
        {
            entity.HasKey(e => e.IdConditions);

            entity.ToTable("coditions");

            entity.Property(e => e.IdConditions).HasColumnName("id_conditions");
            entity.Property(e => e.Abdomen).HasColumnName("abdomen");
            entity.Property(e => e.CP).HasColumnName("c_p");
            entity.Property(e => e.Eyes).HasColumnName("eyes");
            entity.Property(e => e.Ganglia).HasColumnName("ganglia");
            entity.Property(e => e.Genitals).HasColumnName("genitals");
            entity.Property(e => e.Head).HasColumnName("head");
            entity.Property(e => e.Limb).HasColumnName("limb");
            entity.Property(e => e.Neck).HasColumnName("neck");
            entity.Property(e => e.Orl).HasColumnName("orl");
            entity.Property(e => e.PkPatient).HasColumnName("pk_patient");
            entity.Property(e => e.Pulmonological).HasColumnName("pulmonological");
            entity.Property(e => e.Skin).HasColumnName("skin");

            entity.HasOne(d => d.PkPatientNavigation).WithMany(p => p.Coditions).HasForeignKey(d => d.PkPatient);
        });

        modelBuilder.Entity<Consult>(entity =>
        {
            entity.HasKey(e => e.IdConsult);

            entity.ToTable("consults");

            entity.Property(e => e.IdConsult).HasColumnName("id_consult");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.PkCondition).HasColumnName("pk_condition");
            entity.Property(e => e.PkDiagnosis).HasColumnName("pk_diagnosis");
            entity.Property(e => e.PkLaboratory).HasColumnName("pk_laboratory");
            entity.Property(e => e.PkPatient).HasColumnName("pk_patient");
            entity.Property(e => e.PkPhysicalExam).HasColumnName("pk_physical_exam");
            entity.Property(e => e.ReasonConsult).HasColumnName("reason_consult");

            entity.HasOne(d => d.PkConditionNavigation).WithMany(p => p.Consults).HasForeignKey(d => d.PkCondition);

            entity.HasOne(d => d.PkDiagnosisNavigation).WithMany(p => p.Consults).HasForeignKey(d => d.PkDiagnosis);

            entity.HasOne(d => d.PkLaboratoryNavigation).WithMany(p => p.Consults).HasForeignKey(d => d.PkLaboratory);

            entity.HasOne(d => d.PkPatientNavigation).WithMany(p => p.Consults).HasForeignKey(d => d.PkPatient);

            entity.HasOne(d => d.PkPhysicalExamNavigation).WithMany(p => p.Consults).HasForeignKey(d => d.PkPhysicalExam);
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => e.IdDiagnosis);

            entity.ToTable("diagnosis");

            entity.Property(e => e.IdDiagnosis).HasColumnName("id_diagnosis");
            entity.Property(e => e.Observations).HasColumnName("observations");
            entity.Property(e => e.PkPatient).HasColumnName("pk_patient");
            entity.Property(e => e.SurgicalRisk).HasColumnName("surgical_risk");
            entity.Property(e => e._1).HasColumnName("1");
            entity.Property(e => e._2).HasColumnName("2");
            entity.Property(e => e._3).HasColumnName("3");
            entity.Property(e => e._4).HasColumnName("4");

            entity.HasOne(d => d.PkPatientNavigation).WithMany(p => p.Diagnoses).HasForeignKey(d => d.PkPatient);
        });

        modelBuilder.Entity<FamilyHistory>(entity =>
        {
            entity.HasKey(e => e.IdFamilyHistory);

            entity.ToTable("family_history");

            entity.Property(e => e.IdFamilyHistory).HasColumnName("id_family_history");
            entity.Property(e => e.Brothers).HasColumnName("brothers");
            entity.Property(e => e.Father).HasColumnName("father");
            entity.Property(e => e.Grandparents).HasColumnName("grandparents");
            entity.Property(e => e.Mother).HasColumnName("mother");
            entity.Property(e => e.PkPatient).HasColumnName("pk_patient");

            entity.HasOne(d => d.PkPatientNavigation).WithMany(p => p.FamilyHistories).HasForeignKey(d => d.PkPatient);
        });

        modelBuilder.Entity<Laboratory>(entity =>
        {
            entity.HasKey(e => e.IdLaboratory);

            entity.ToTable("laboratory");

            entity.Property(e => e.IdLaboratory).HasColumnName("id_laboratory");
            entity.Property(e => e.BloodGroup).HasColumnName("blood_group");
            entity.Property(e => e.Creatinine).HasColumnName("creatinine");
            entity.Property(e => e.Eos).HasColumnName("eos");
            entity.Property(e => e.Glycemia).HasColumnName("glycemia");
            entity.Property(e => e.Hgb).HasColumnName("hgb");
            entity.Property(e => e.Hiv).HasColumnName("hiv");
            entity.Property(e => e.Hto).HasColumnName("hto");
            entity.Property(e => e.Leuc).HasColumnName("leuc");
            entity.Property(e => e.Linf).HasColumnName("linf");
            entity.Property(e => e.PkPatient).HasColumnName("pk_patient");
            entity.Property(e => e.Plq).HasColumnName("plq");
            entity.Property(e => e.PtC).HasColumnName("pt_c");
            entity.Property(e => e.PtP).HasColumnName("pt_p");
            entity.Property(e => e.PttC).HasColumnName("ptt_c");
            entity.Property(e => e.PttP).HasColumnName("ptt_p");
            entity.Property(e => e.Urea).HasColumnName("urea");
            entity.Property(e => e.Vdr).HasColumnName("vdr");

            entity.HasOne(d => d.PkPatientNavigation).WithMany(p => p.Laboratories).HasForeignKey(d => d.PkPatient);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.IdPatient);

            entity.ToTable("patient");

            entity.Property(e => e.IdPatient).HasColumnName("id_patient");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.SecondLastName).HasColumnName("second_last_name");
            entity.Property(e => e.SecondName).HasColumnName("second_name");
        });

        modelBuilder.Entity<PersonDatum>(entity =>
        {
            entity.HasKey(e => e.IdPersonData);

            entity.ToTable("person_data");

            entity.Property(e => e.IdPersonData).HasColumnName("id_person_data");
            entity.Property(e => e.NameRepresentative).HasColumnName("name_representative");
            entity.Property(e => e.Nutrition).HasColumnName("nutrition");
            entity.Property(e => e.ObservationSocial).HasColumnName("observation_social");
            entity.Property(e => e.PkPatient).HasColumnName("pk_patient");
            entity.Property(e => e.Relationship).HasColumnName("relationship");
            entity.Property(e => e.StatusEconomic).HasColumnName("status_economic");
            entity.Property(e => e.TelephoneNumber).HasColumnName("telephone_number");

            entity.HasOne(d => d.PkPatientNavigation).WithMany(p => p.PersonData).HasForeignKey(d => d.PkPatient);
        });

        modelBuilder.Entity<PhysicalExam>(entity =>
        {
            entity.HasKey(e => e.IdPhysicalExam);

            entity.ToTable("physical_exam");

            entity.Property(e => e.IdPhysicalExam).HasColumnName("id_physical_exam");
            entity.Property(e => e.Ca).HasColumnName("ca");
            entity.Property(e => e.Cbi).HasColumnName("cbi");
            entity.Property(e => e.CbiE).HasColumnName("cbi_e");
            entity.Property(e => e.Cc).HasColumnName("cc");
            entity.Property(e => e.CcE).HasColumnName("cc_e");
            entity.Property(e => e.Ct).HasColumnName("ct");
            entity.Property(e => e.Fc).HasColumnName("fc");
            entity.Property(e => e.Fr).HasColumnName("fr");
            entity.Property(e => e.Imc).HasColumnName("imc");
            entity.Property(e => e.ImcE).HasColumnName("imc_e");
            entity.Property(e => e.PE).HasColumnName("p_e");
            entity.Property(e => e.PkPatient).HasColumnName("pk_patient");
            entity.Property(e => e.Seo2).HasColumnName("seo2");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.TA).HasColumnName("t_a");
            entity.Property(e => e.TE).HasColumnName("t_e");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.PkPatientNavigation).WithMany(p => p.PhysicalExams).HasForeignKey(d => d.PkPatient);
        });

        modelBuilder.Entity<Pregnancy>(entity =>
        {
            entity.HasKey(e => e.IdPregnancy);

            entity.ToTable("pregnancy");

            entity.Property(e => e.IdPregnancy).HasColumnName("id_pregnancy");
            entity.Property(e => e.Ccan).HasColumnName("ccan");
            entity.Property(e => e.CesareanOperation).HasColumnName("cesarean_operation");
            entity.Property(e => e.Complications).HasColumnName("complications");
            entity.Property(e => e.Deeds).HasColumnName("deeds");
            entity.Property(e => e.NeonatalComplications).HasColumnName("neonatal_complications");
            entity.Property(e => e.NumberQueries).HasColumnName("number_queries");
            entity.Property(e => e.Pan).HasColumnName("pan");
            entity.Property(e => e.Pes).HasColumnName("pes");
            entity.Property(e => e.PkPatient).HasColumnName("pk_patient");
            entity.Property(e => e.Tan).HasColumnName("tan");

            entity.HasOne(d => d.PkPatientNavigation).WithMany(p => p.Pregnancies).HasForeignKey(d => d.PkPatient);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
