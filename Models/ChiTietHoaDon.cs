﻿using System;
using System.Collections.Generic;

namespace QLBanHang_Demo.Models
{
    public partial class ChiTietHoaDon
    {
        public string MaHd { get; set; } = null!;
        public string MaSp { get; set; } = null!;
        public int? SoLuongMua { get; set; }
        public int? DonGia { get; set; }

        public virtual SanPham MaSpNavigation { get; set; } = null!;
    }
}
