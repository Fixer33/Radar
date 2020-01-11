using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radar
{
    public partial class GroupListUserControl : UserControl
    {
        public GroupListUserControl()
        {
            InitializeComponent();
        }

        public List<SensorDataControl> sensorControls = new List<SensorDataControl>();

        public void AddSensors(int SensorCount)
        {
            for (int i = 0; i < SensorCount; i++)
            {
                SensorDataControl newSensor = new SensorDataControl();
                newSensor.SetNumber(sensorControls.Count);
                sensorControls.Add(newSensor);
            }

            RefreshSensorList();
        }

        public void ClearSensors()
        {
            sensorControls.Clear();
            RefreshSensorList();
        }

        private void RefreshSensorList()
        {
            const int control_size = 259;
            const int space_between_control = 10;
            
            hScrollBar1.Maximum = 0;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Size = new Size(0, flowLayoutPanel1.Size.Height);
            flowLayoutPanel1.Location = new Point(0, 0);

            if (sensorControls.Count < 1) return;

            for (int i = 0; i < sensorControls.Count; i++)
            {
                flowLayoutPanel1.Size = new Size(flowLayoutPanel1.Size.Width + control_size + space_between_control, flowLayoutPanel1.Size.Height);
                flowLayoutPanel1.Controls.Add(sensorControls[i]);
            }
            int difference = this.Size.Width - flowLayoutPanel1.Size.Width;
            hScrollBar1.Maximum = Math.Abs(difference) / 10;
            hScrollBar1.Value = 0;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.Location = new Point(-hScrollBar1.Value*10, flowLayoutPanel1.Location.Y);
        }
    }
}
