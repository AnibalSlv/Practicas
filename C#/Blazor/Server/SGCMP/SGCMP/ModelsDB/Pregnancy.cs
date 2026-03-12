using System;
using System.Collections.Generic;

namespace SGCMP.ModelsDB;

public partial class Pregnancy
{
    public int IdPregnancy { get; set; }

    public int? PkPatient { get; set; }

    public int? NumberQueries { get; set; }

    public int? Deeds { get; set; }

    public string? Complications { get; set; }

    public string? Pes { get; set; }

    public string? CesareanOperation { get; set; }

    public string? Pan { get; set; }

    public int? Tan { get; set; }

    public int? Ccan { get; set; }

    public string? NeonatalComplications { get; set; }

    public virtual Patient? PkPatientNavigation { get; set; }
}
