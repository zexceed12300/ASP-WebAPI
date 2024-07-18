using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PTXYZ_WEBAPI.Models;

public partial class TblLapangan
{
    public int IdLapangan { get; set; }

    public string KodeLapangan { get; set; } = null!;

    public string NamaLapangan { get; set; } = null!;

    [NotMapped]
    [JsonIgnore]
    public virtual ICollection<TblSewa> TblSewas { get; set; } = new List<TblSewa>();
}
