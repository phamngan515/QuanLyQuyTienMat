using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class VaiTro
{
    public int VaiTroId { get; set; }

    public string TenVaiTro { get; set; } = null!;

    public virtual ICollection<NguoiDung> NguoiDungs { get; set; } = new List<NguoiDung>();
}
