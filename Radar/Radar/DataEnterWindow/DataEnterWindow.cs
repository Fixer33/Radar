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
        }

        private void side1Field_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown upDown = (NumericUpDown)sender;

            if (int.TryParse(upDown.Value.ToString(), out int value))
            {
                if (upDown == side1Field)
                {
                    Side1 = value;
                }
                else if (upDown == side2Field)
                {
                    Side1 = value;
                }
            }
        }

        private void EnterDataBut_Click(object sender, EventArgs e)
        {

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
    }
}
