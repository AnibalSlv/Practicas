using System;
using System.Collections.Generic;

namespace SGCMP.ModelsDB;

public partial class Consult
{
    public int IdConsult { get; set; }

    public string? ReasonConsult { get; set; }

    public int? PkPatient { get; set; }

    public int? PkCondition { get; set; }

    public int? PkDiagnosis { get; set; }

    public int? PkPhysicalExam { get; set; }

    public int? PkLaboratory { get; set; }

    public string? Date { get; set; }

    public virtual Codition? PkConditionNavigation { get; set; }

    public virtual Diagnosis? PkDiagnosisNavigation { get; set; }

    public virtual Laboratory? PkLaboratoryNavigation { get; set; }

    public virtual Patient? PkPatientNavigation { get; set; }

    public virtual PhysicalExam? PkPhysicalExamNavigation { get; set; }
}
