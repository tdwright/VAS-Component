using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VAS
{
    public partial class VAS : UserControl
    {
        public VAS()
        {
            InitializeComponent();
        }

        private int max = 100;

        public int Maximum
        {
            get
            {
                return max;
            }
            set
            {
                max = value;
                trackBar.Maximum = value;
            }
        }

        private int min = 0;

        public int Minimum
        {
            get
            {
                return min;
            }
            set
            {
                min = value;
                trackBar.Minimum = value;
            }
        }

        public int Value
        {
            get
            {
                return this.trackBar.Value;
            }
        }

        public new bool Enabled
        {
            get
            {
                return trackBar.Enabled;
            }
            set
            {
                trackBar.Enabled = value;
            }
        }

        private void trackBar_MouseDown(object sender, MouseEventArgs e)
        {
            int marginsize = 12;
            double leftDelta = e.Location.X - (this.trackBar.Location.X + marginsize);
            int newvalue = (int)(leftDelta / (this.trackBar.Size.Width - (marginsize * 2)) * this.trackBar.Maximum);
            this.trackBar.Value = clip(newvalue,this.trackBar.Minimum,this.trackBar.Maximum);
        }

        private int clip(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private void VAS_Load(object sender, EventArgs e)
        {
            this.Reset();
        }

        public void Reset()
        {
            this.trackBar.Minimum = this.Minimum;
            this.trackBar.Maximum = this.Maximum;
            this.trackBar.Value = (int)(0.5 * (this.Minimum + this.Maximum));
        }

        public event MouseEventHandler Accessed
        {
            add { this.trackBar.MouseDown += value; }
            remove { this.trackBar.MouseDown -= value; }
        }

        private void trackBar_Resize(object sender, EventArgs e)
        {

        }


    }
}
