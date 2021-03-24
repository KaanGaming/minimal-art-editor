using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace someartapplol
{
    public partial class NewFileDialog : Form
    {
        public NewFileDialog()
        {
            InitializeComponent();
            Done = false;
        }

        public static ushort Width = 0;
        public static ushort Height = 0;
        public static bool Done = true;
        public static DialogResult Status = DialogResult.Cancel;

        private void clickCreate(object sender, EventArgs e)
        {
            int w, h = 0;

            if (!int.TryParse(textBox1.Text, out w))
            {
                MessageBox.Show("Invalid value, must be a number");
                return;
            }
            if (!int.TryParse(textBox2.Text, out h))
            {
                MessageBox.Show("Invalid value, must be a number");
                return;
            }
            NewFileDialog.Width = Convert.ToUInt16(w);
            NewFileDialog.Height = Convert.ToUInt16(h);
            Status = DialogResult.OK;
            Done = true;
            Close();
        }

        private void NewFileDialog_Load(object sender, EventArgs e)
        {
            Status = DialogResult.Cancel;
        }
    }
}
