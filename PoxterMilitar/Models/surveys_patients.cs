﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PoxterMilitar.Models;

public partial class surveys_patients
{
    public long id_survey { get; set; }
    public DateTime hour_survey { get; set; }
    public string _1_survey { get; set; }
    public string _2_survey { get; set; }
    public string _3_survey { get; set; }
    public string _4_survey { get; set; }
    public string _5_survey { get; set; }
    public string _6_survey { get; set; }
    public string _7_survey { get; set; }
    public string _8_survey { get; set; }
    public string _9_survey { get; set; }
    public string _10_survey { get; set; }

    public long id_p { get; set; }

    public virtual patients_poxter Patient { get; set; }
}