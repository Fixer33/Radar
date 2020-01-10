using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControls
{
    public partial class SensorDataControl : UserControl
    {
        public SensorDataControl(int number)
        {
            InitializeComponent();
        }

        public float Distance { get; private set; }
        public float Degrees { get; private set; }
        public int Number { get; private set; }

        private void DistanceField_ValueChanged(object sender, EventArgs e)
        {
            if (float.TryParse(DistanceField.Value.ToString(), out float value))
            {
                Distance = value;
            }
        }

        private void DegreesField_ValueChanged(object sender, EventArgs e)
        {
            if (float.TryParse(DegreesField.Value.ToString(), out float value))
            {
                Degrees = value;
            }
        }
    }
}
