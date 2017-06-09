using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reckoner_App
{
    public partial class image : Form
    {
        public image()
        {
            InitializeComponent();
        }

        private void image_Load(object sender, EventArgs e)
        {
            Form2 ab = new Form2();
            ab.Show();
            System.Threading.Thread.Sleep(3000);
            ab.Hide();
            var home = new Reckoner();
            home.BindProjects();
        }
    }
}
