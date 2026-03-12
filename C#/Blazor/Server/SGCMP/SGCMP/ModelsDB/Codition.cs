using System;
using System.Collections.Generic;

namespace SGCMP.ModelsDB;

public partial class Codition
{
    public int IdConditions { get; set; }

    public int? PkPatient { get; set; }

    public string? Skin { get; set; }

    public string? Head { get; set; }

    public string? Eyes { get; set; }

    public string? Orl { get; set; }

    public string? Neck { get; set; }

    public string? Ganglia { get; set; }

    public string? CP { get; set; }

    public string? Abdomen { get; set; }

    public string? Genitals { get; set; }

    public string? Limb { get; set; }

    public string? Pulmonological { get; set; }

    public virtual ICollection<Consult> Consults { get; set; } = new List<Consult>();

    public virtual Patient? PkPatientNavigation { get; set; }
}
