using System;
using System.Collections.Generic;

namespace SGCMP.ModelsDB;

public partial class PhysicalExam
{
    public int IdPhysicalExam { get; set; }

    public int? PkPatient { get; set; }

    public int? Fc { get; set; }

    public int? Fr { get; set; }

    public int? TA { get; set; }

    public int? Seo2 { get; set; }

    public int? Weight { get; set; }

    public int? Size { get; set; }

    public int? Cc { get; set; }

    public int? Ct { get; set; }

    public int? Ca { get; set; }

    public int? Cbi { get; set; }

    public int? Imc { get; set; }

    public int? PE { get; set; }

    public int? TE { get; set; }

    public int? CcE { get; set; }

    public int? CbiE { get; set; }

    public int? ImcE { get; set; }

    public virtual ICollection<Consult> Consults { get; set; } = new List<Consult>();

    public virtual Patient? PkPatientNavigation { get; set; }
}
