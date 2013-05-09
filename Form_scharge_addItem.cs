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
    public partial class Form_scharge_addItem : Form
    {
        Manager m = new Manager();

        public Form_scharge_addItem()
        {
            InitializeComponent();
        }

        public ComboBox ComboBox3
        {
            get { return comboBox3; }
        }

        public ComboBox ComboBox4
        {
            get { return comboBox4; }
        }

        public NumericUpDown NumericUpDown1
        {
            get { return numericUpDown1; }
        }

        public Button Button1 { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox3.Text != "")
                && (comboBox4.Text != ""))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void populate_organizations(List<Organization> org)
        {
            var dataSource = org;

            this.comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.AbbrName).ToList();

            this.comboBox1.DataSource = dataSource;
            this.comboBox1.DisplayMember = "FullName";
            this.comboBox1.ValueMember = "id";
        }

        public void populate_departments(List<Department> dep)
        {
            var dataSource = dep;

            this.comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.Title).ToList();

            this.comboBox2.DataSource = dataSource;
            this.comboBox2.DisplayMember = "Title";
            this.comboBox2.ValueMember = "id";
        }

        public void populate_employees(int id_org, int id_dep)
        {
            var dataSource = m.SelectEmp(id_org, id_dep);

            this.comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.Name).ToList();

            this.comboBox3.DataSource = dataSource;
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.ValueMember = "id";
        }

        public void populate_TofCharge()
        {
            var dataSource = m.SelectTCh();

            this.comboBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.Type).ToList();

            this.comboBox4.DataSource = dataSource;
            this.comboBox4.DisplayMember = "Type";
            this.comboBox4.ValueMember = "id";
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            int temp = (int)this.comboBox4.SelectedIndex;
            if (temp != 0)
            {
                this.label5.Visible = false;
                this.numericUpDown1.Visible = false;
            }
            else
            {
                this.label5.Visible = true;
                this.numericUpDown1.Visible = true;
            }
        }
    }
}
