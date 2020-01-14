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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Radar
{
    /// <summary>
    /// Interaction logic for FuncButtonsWIndow.xaml
    /// </summary>
    public partial class FuncButtonsWIndow : Window
    {
        public FuncButtonsWIndow()
        {
            InitializeComponent();
        }

        public RadarWindow rdrw;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            kompassImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.Kompass.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void PanicButton_Click(object sender, RoutedEventArgs e)
        {
            rdrw.ActivatePanic();
        }

        private void StationButton_Click(object sender, RoutedEventArgs e)
        {
            rdrw.ReturnToStation();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            rdrw.LaunchTest();
        }
    }
}
