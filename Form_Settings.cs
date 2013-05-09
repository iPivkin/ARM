using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class Form_Settings : Form
    {
        public Form_Settings()
        {
            InitializeComponent();
        }

        private void link_Org_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_AddOrg Form = new Form_AddOrg();
            Form.Show();
        }
    }
}
