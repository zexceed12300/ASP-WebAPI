using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PTXYZ_WEBAPI.Models;

public partial class TblSewa
{
    public int IdTransaksi { get; set; }

    public string NoTransaksi { get; set; } = null!;

    public DateTime TglTransaksi { get; set; }

    public long TotalBayar { get; set; }

    public string LamaSewa { get; set; } = null!;

    public int IdLapangan { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual TblLapangan? IdLapanganNavigation { get; set; } = null!;
}
