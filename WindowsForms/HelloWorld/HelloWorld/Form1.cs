using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //BackColor = Color.BlanchedAlmond;
            //Text = "MyApp";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Form is loaded on screen");
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            var frm = new Form2();
            frm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var Result = MessageBox.Show("Are you sure, you want to exit", "Exit", MessageBoxButtons.YesNoCancel);
            if(Result != DialogResult.Yes)
            {
                e.Cancel = true;   
            }
        }
    }
}
