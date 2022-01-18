using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DialogBoxesDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFonts_Click(object sender, EventArgs e)
        {
            var Fonts = new FontDialog();
            var Result = Fonts.ShowDialog();
            if(Result == DialogResult.OK)
            {
                lblText.Font = Fonts.Font;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            var Colors = new ColorDialog();
            var Result = Colors.ShowDialog();
            if(Result == DialogResult.OK)
            {
                lblText.ForeColor = Colors.Color;
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            var Ofd = new OpenFileDialog();
            var Result = Ofd.ShowDialog();
            if(Result == DialogResult.OK)
            {
                var filepath = Ofd.FileName;
                MessageBox.Show(filepath);
            }
        }

        private void btnSaveLocation_Click(object sender, EventArgs e)
        {
            var Ofd = new SaveFileDialog();
            var Result = Ofd.ShowDialog();
            if (Result == DialogResult.OK)
            {
                var filepath = Ofd.FileName;
                MessageBox.Show(filepath);
                using (var fs = new FileStream(filepath, FileMode.CreateNew, FileAccess.Write))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("Hello there");
                        sw.Close();
                    }
                    fs.Close();
                }     
            }

        }
    }
}
