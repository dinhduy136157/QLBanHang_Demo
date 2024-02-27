using QLBanHang_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLBanHang_Demo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QLBanHangContext a = new QLBanHangContext();
            //
            var b = from sp in a.SanPhams
                    join c in a.LoaiSps on sp.MaLoai equals c.MaLoai
                    join d in a.ChiTietHoaDons on sp.MaSp equals d.MaSp
                    select new
                    {
                        sp.MaSp,
                        sp.TenSp,
                        c.TenLoai,
                        d.SoLuongMua,
                        TongTienBan = d.DonGia * d.SoLuongMua
                    };
            dvg1.ItemsSource = b.ToList();
        }
    }
}
