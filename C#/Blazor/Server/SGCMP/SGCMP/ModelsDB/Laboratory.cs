using System;
using System.Collections.Generic;

namespace SGCMP.ModelsDB;

public partial class Laboratory
{
    public int IdLaboratory { get; set; }

    public int? PkPatient { get; set; }

    public int? Leuc { get; set; }

    public int? Linf { get; set; }

    public int? Eos { get; set; }

    public int? Hgb { get; set; }

    public int? Hto { get; set; }

    public int? Plq { get; set; }

    public int? Glycemia { get; set; }

    public int? Urea { get; set; }

    public int? Creatinine { get; set; }

    public int? Hiv { get; set; }

    public int? Vdr { get; set; }

    public string? BloodGroup { get; set; }

    public int? PtP { get; set; }

    public int? PtC { get; set; }

    public int? PttP { get; set; }

    public int? PttC { get; set; }

    public virtual ICollection<Consult> Consults { get; set; } = new List<Consult>();

    public virtual Patient? PkPatientNavigation { get; set; }
}
