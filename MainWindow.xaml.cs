using QLBanHang_Demo.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace QLBanHang_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        QLBanHangContext a = new QLBanHangContext();
        private void Hienthi()
        {
            // do bảng DataGrid dùng bảng SP trong SQL nên sẽ là a.SanPham
            var b = from c in a.SanPhams
                    select new
                    {
                        c.MaSp,
                        c.TenSp,
                        c.MaLoai,
                        c.DonGia,
                        c.SoLuongCo,
                        ThanhTien = c.DonGia * c.SoLuongCo
                    };
            // dòng này in dữ liệu vừa nhập
            dvgSanpham.ItemsSource = b.ToList();
        }

        private void DanhSach()
        {
            var b = from c in a.LoaiSps
                    select c;
            cbo.ItemsSource = b.ToList();
            // Hiển thị combo theo loại 
            cbo.DisplayMemberPath = "TenLoai";
            cbo.SelectedValuePath = "MaLoai";
            cbo.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Hienthi();
            DanhSach();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = a.SanPhams.SingleOrDefault(t => t.DonGia.Equals(txDonGia));
            SanPham sp = new SanPham();
            sp.MaSp = txMaSP.Text;
            sp.TenSp = txTenSP.Text;
            sp.DonGia = int.Parse(txDonGia.Text);
            sp.SoLuongCo = int.Parse(txSoLuong.Text);
            LoaiSp cb1 = (LoaiSp)cbo.SelectedItem;
            sp.MaLoai = cb1.MaLoai;
            if (b != null)
            {
                MessageBox.Show(" Lỗi trùng mã sản phẩm ", "Thông báo");

            }
            else if (sp.DonGia < 0)
            {
                MessageBox.Show("Đơn giá phải >0", "Thông báo");

            }
            else if (sp.SoLuongCo < 0)
            {
                MessageBox.Show("Số lượng có phải >0", "Thông báo");
            }
            else
            {

                a.SanPhams.Add(sp);
                a.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo");
                Hienthi();
            }

        }
        // Hàm Sửa thông tin sản phẩm
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var sp = a.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txMaSP.Text));

            if (sp != null)
            {

                sp.TenSp = txTenSP.Text;
                sp.DonGia = int.Parse(txDonGia.Text);
                sp.SoLuongCo = int.Parse(txSoLuong.Text);
                LoaiSp cb1 = (LoaiSp)cbo.SelectedItem;
                sp.MaLoai = cb1.MaLoai;
                a.SaveChanges();
                MessageBox.Show("Sửa thành công", "Thông báo");
                Hienthi();
            }
            else
            {

                MessageBox.Show("Không trùng sản phẩm", "Lỗi thông báo");

            }

        }

        // Hàm Xóa một sản phẩm bất kỳ trong bảng SanPham trong SQL
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var sp = a.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txMaSP.Text));
            if (sp != null)
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButton.YesNoCancel);
                if (rs == MessageBoxResult.Yes)
                {
                    a.SanPhams.Remove(sp);
                    a.SaveChanges();
                    Hienthi();
                }
            }
            else
            {
                MessageBox.Show("Không được trùng sản phẩm ", "Thông báo");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 a = new Window1();
            a.Show();
        }
    }
}