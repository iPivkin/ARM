using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Main;

namespace ARM
{
    public partial class Form_AddOrg : Form
    {

        Manager manager = new Manager();

        public Form_AddOrg()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void but_Save_Click(object sender, EventArgs e)
        {
            // Первичная валидация

            Organization Org = createOrganization(tb_Name.Text, tb_FullName.Text, tb_AbbrName.Text, tb_Address.Text, tb_Tel.Text);

            manager.Insert(Org);
        }

        private Organization createOrganization(string _Name, string _FullName, string _AbbrName, string _Address, string _Tel)
        {
            Organization o = new Organization();

            o.Name = _Name;
            o.FullName = _FullName;
            o.AbbrName = _AbbrName;
            o.Address = _Address;
            o.Tel = _Tel;

            return o;
        }
    }
}
