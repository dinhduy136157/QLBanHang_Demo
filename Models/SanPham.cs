using System;
using System.Collections.Generic;

namespace QLBanHang_Demo.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public string MaSp { get; set; } = null!;
        public string? TenSp { get; set; }
        public int? DonGia { get; set; }
        public int? SoLuongCo { get; set; }
        public string? MaLoai { get; set; }

        public virtual LoaiSp? MaLoaiNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
