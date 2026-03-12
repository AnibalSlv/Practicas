using System;
using System.Collections.Generic;

namespace SGCMP.ModelsDB;

public partial class PersonDatum
{
    public int IdPersonData { get; set; }

    public int? PkPatient { get; set; }

    public string? Nutrition { get; set; }

    public string? NameRepresentative { get; set; }

    public int? TelephoneNumber { get; set; }

    public string? Relationship { get; set; }

    public string? StatusEconomic { get; set; }

    public string? ObservationSocial { get; set; }

    public virtual Patient? PkPatientNavigation { get; set; }
}
