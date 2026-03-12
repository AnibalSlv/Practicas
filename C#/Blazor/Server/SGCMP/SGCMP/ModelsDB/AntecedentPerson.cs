using System;
using System.Collections.Generic;

namespace SGCMP.ModelsDB;

public partial class AntecedentPerson
{
    public int IdAntecedentPerson { get; set; }

    public int? PkPatient { get; set; }

    public string? Allergy { get; set; }

    public string? DiabetesMedicine { get; set; }

    public string? AsthmaLastCrisis { get; set; }

    public string? AsthmaTreatment { get; set; }

    public string? HtaTreatment { get; set; }

    public string? NephropathyTreatment { get; set; }

    public string? HospitalizationExplanation { get; set; }

    public string? SurgicalExplanation { get; set; }

    public virtual Patient? PkPatientNavigation { get; set; }
}
