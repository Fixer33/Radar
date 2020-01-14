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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Radar
{
    /// <summary>
    /// Interaction logic for SensorDataShowingControl.xaml
    /// </summary>
    public partial class SensorDataShowingControl : UserControl
    {
        public SensorDataShowingControl()
        {
            InitializeComponent();
        }

        public void SetText(int sensorNumber, float distance, float angle)
        {
            label1.Content = "Датчик " + (sensorNumber+1).ToString();
            label2.Content = "D " + (sensorNumber+1).ToString();
            label3.Content = "Раастояние " + distance.ToString();
            label4.Content = "Угол " + angle.ToString();
        }
    }
}
