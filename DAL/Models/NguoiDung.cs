using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class NguoiDung
{
    public int NguoiDungId { get; set; }

    public string TenNguoiDung { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public int? VaiTroId { get; set; }

    public virtual VaiTro? VaiTro { get; set; }
}
