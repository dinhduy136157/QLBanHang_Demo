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
    /// Interaction logic for Add.xaml
    /// </summary>
    
    public partial class Add : Window
    {
        private QLBanHangContext _db = new QLBanHangContext();
        public Add()
        {
            InitializeComponent();

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
