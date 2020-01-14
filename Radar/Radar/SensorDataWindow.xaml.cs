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
    /// Interaction logic for SensorDataWindow.xaml
    /// </summary>
    public partial class SensorDataWindow : Window
    {
        public SensorDataWindow()
        {
            InitializeComponent();
        }

        public void SetSensors(List<Sensor> sensors)
        {
            foreach (Sensor sensor in sensors)
            {
                SensorDataShowingControl sdsc = new SensorDataShowingControl();
                sdsc.SetText(sensor.Number, sensor.Distance, sensor.Angle);
                listView.Items.Add(sdsc);
            }
        }
    }
}
