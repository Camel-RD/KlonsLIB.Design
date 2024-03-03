using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = userControl11;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
