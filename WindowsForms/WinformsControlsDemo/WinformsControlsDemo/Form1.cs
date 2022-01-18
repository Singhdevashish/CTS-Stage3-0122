using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsControlsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtName.Text;
            var gender = string.Empty;
            if (rbtnMale.Checked) gender = rbtnMale.Text;
            else if (rbtnFemale.Checked) gender = rbtnFemale.Text;
            else gender = rbtnOther.Text;

            var address = txtAddress.Text;
            var location = cboxLocations.SelectedItem.ToString();
            var technology = lstBoxTechnology.SelectedItem.ToString();

            var Message = $"Name = {username}\nGender={gender}\nAddress={address}\nLocation={location}\nTechnology={technology}";

            lblMessage.Text = Message;

            MessageBox.Show("Your registration is successful");

        }
        
    }
}
