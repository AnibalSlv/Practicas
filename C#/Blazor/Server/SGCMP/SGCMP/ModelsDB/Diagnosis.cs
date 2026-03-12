using System;
using System.Collections.Generic;

namespace SGCMP.ModelsDB;

public partial class Diagnosis
{
    public int IdDiagnosis { get; set; }

    public int? PkPatient { get; set; }

    public string? _1 { get; set; }

    public string? _2 { get; set; }

    public string? _3 { get; set; }

    public string? _4 { get; set; }

    public string? SurgicalRisk { get; set; }

    public string? Observations { get; set; }

    public virtual ICollection<Consult> Consults { get; set; } = new List<Consult>();

    public virtual Patient? PkPatientNavigation { get; set; }
}
