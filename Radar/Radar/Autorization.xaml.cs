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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

     
        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text == "admin" && PasswordTB.Password == "12456")
            {
                DataEnterWindow dew = new DataEnterWindow();
                dew.authWindow = this;
                dew.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Zdes' mogla bit' vasha reklama, no parol ne pravilniy(");
                MessageBox.Show("Raid: Shadow Legends - это пошаговая стратегия...");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Set icon from resources
            this.Icon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.RadarIcon.ToBitmap().GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
