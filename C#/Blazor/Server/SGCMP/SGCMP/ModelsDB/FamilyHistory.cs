using System;
using System.Collections.Generic;

namespace SGCMP.ModelsDB;

public partial class FamilyHistory
{
    public int IdFamilyHistory { get; set; }

    public int? PkPatient { get; set; }

    public string? Mother { get; set; }

    public string? Father { get; set; }

    public string? Brothers { get; set; }

    public string? Grandparents { get; set; }

    public virtual Patient? PkPatientNavigation { get; set; }
}
