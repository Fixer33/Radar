using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radar
{
    public partial class DataEnterWindow : Form
    {
        public DataEnterWindow()
        {
            InitializeComponent();
        }

        public int Side1 { get; private set; }
        public int Side2 { get; private set; }

        public List<SensorDataControl> sensorControls
        {
            get
            {
                return groupListUserControl1.sensorControls;
            }
        }

        private void sensorCountField_ValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(sensorCountField.Value.ToString(), out int sensorCount))
            {
                groupListUserControl1.ClearSensors();
                groupListUserControl1.AddSensors(sensorCount);
            }
        }

        private void DataEnterWindow_Load(object sender, EventArgs e)
        {
            sensorCountField_ValueChanged(sensorCountField, new EventArgs());
            side1Field_ValueChanged(side1Field, new EventArgs());
            side2Field_ValueChanged(side2Field, new EventArgs());
        }

        private void EnterDataBut_Click(object sender, EventArgs e)
        {
            List<Sensor> sensors = new List<Sensor>();
            foreach (SensorDataControl sensor in sensorControls)
            {
                Sensor newSensor = new Sensor(sensor.Number, sensor.Distance, sensor.Degrees);
                sensors.Add(newSensor);
            }

            RadarWindow rw = new RadarWindow(sensors, authWindow, this);
            rw.Width = Side1 + 6;
            rw.Height = Side2 + 29;
            this.Hide();
            rw.Show();
        }


        public Window1 authWindow;

        private void DataEnterWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (authWindow == null)
            {
                Application.Restart();
                return;
            }
            authWindow.Close();
        }

        private void side1Field_ValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(side1Field.Value.ToString(), out int value))
            {
                Side1 = value;
            }
        }

        private void side2Field_ValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(side2Field.Value.ToString(), out int value))
            {
                Side2 = value;
            }
        }
    }
}
