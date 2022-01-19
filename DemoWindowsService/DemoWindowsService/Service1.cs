using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

namespace DemoWindowsService
{
    public partial class Service1 : ServiceBase
    {
       
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            using (var fs = new FileStream("C:\\ServiceDemo.txt", FileMode.Append, FileAccess.Write))
            using (var sw = new StreamWriter(fs))
            {
                sw.WriteLine(DateTime.Now.ToString());
                sw.Close();
                fs.Close();
            }
        }

        protected override void OnStop()
        {
            timer1.Stop();
        }
    }
}
