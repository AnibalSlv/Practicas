using System;
using System.Collections.Generic;

namespace SGCMP.ModelsDB;

public partial class Patient
{
    public int IdPatient { get; set; }

    public string? Name { get; set; }

    public string? SecondName { get; set; }

    public string? LastName { get; set; }

    public string? SecondLastName { get; set; }

    public virtual ICollection<AntecedentPerson> AntecedentPeople { get; set; } = new List<AntecedentPerson>();

    public virtual ICollection<Codition> Coditions { get; set; } = new List<Codition>();

    public virtual ICollection<Consult> Consults { get; set; } = new List<Consult>();

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

    public virtual ICollection<FamilyHistory> FamilyHistories { get; set; } = new List<FamilyHistory>();

    public virtual ICollection<Laboratory> Laboratories { get; set; } = new List<Laboratory>();

    public virtual ICollection<PersonDatum> PersonData { get; set; } = new List<PersonDatum>();

    public virtual ICollection<PhysicalExam> PhysicalExams { get; set; } = new List<PhysicalExam>();

    public virtual ICollection<Pregnancy> Pregnancies { get; set; } = new List<Pregnancy>();
}
