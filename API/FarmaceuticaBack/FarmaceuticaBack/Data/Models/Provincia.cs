﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FarmaceuticaBack.Models;

public partial class Provincia
{
    public int IdProvincia { get; set; }

    public string Provincia1 { get; set; }

    public int IdPais { get; set; }
    [JsonIgnore]
    public virtual ICollection<Ciudad> Ciudades { get; set; } = new List<Ciudad>();

    public virtual Pais IdPaisNavigation { get; set; }
}