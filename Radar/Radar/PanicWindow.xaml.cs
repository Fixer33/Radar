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

namespace Radar
{
    /// <summary>
    /// Interaction logic for PanicWindow.xaml
    /// </summary>
    public partial class PanicWindow : Window
    {
        public PanicWindow(string text_to_show)
        {
            InitializeComponent();
            textBox.Text = text_to_show;
        }

        public RadarWindow rw;

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            rw.ReturnToStation();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            rw.ActivatePanic();
            this.Close();
        }
    }
}
