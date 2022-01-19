﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
namespace Demo11_AsyncAwaitDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var prod = new Product();
            prod.Id = Convert.ToInt32(textBox1.Text);
            prod.Name = textBox2.Text;
            prod.Price = Convert.ToDecimal(textBox3.Text);
            prod.IsActive = checkBox1.Checked;

            var context = new CognizantEntities();

            context.Products.Add(prod);

            int rows = await context.SaveChangesAsync();

            MessageBox.Show($"{rows} records added");
        }

#pragma warning disable IDE1006 // Naming Styles
        private async void button2_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            var context = new CognizantEntities();
            var query = from obj in context.Products
                        select obj;
            dataGridView1.DataSource = await query.ToListAsync();
        }
    }
}
