using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class GiaoDich
{
    public int GiaoDichId { get; set; }

    public string? SoCt { get; set; }

    public DateTime NgayCt { get; set; }

    public string? DienGiai { get; set; }

    public decimal SoTien { get; set; }

    public string? TkdoiUng { get; set; }

    public string? TenDoiTuong { get; set; }

    public byte? LoaiGiaoDich { get; set; }

    public string? DiaChi { get; set; }

    public string? SoTienBangChu { get; set; }

    public string? ChungTuGoc { get; set; }
}
