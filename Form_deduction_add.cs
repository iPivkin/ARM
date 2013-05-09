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
    public partial class Form_deduction_add : Form
    {
        Manager m = new Manager();

        List<SalaryDeduction> list = new List<SalaryDeduction>();

        public Form_deduction_add()
        {
            InitializeComponent();

            populate_organizations();
            populate_departments();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Добавить
            Form_deduction_addItem Form = new Form_deduction_addItem();

            // Устанавливаем организацию и подразделение
            List<Organization> list_org = new List<Organization>();
            Organization temp = (Organization)this.comboBox1.SelectedItem;
            list_org.Add(temp);

            List<Department> list_dep = new List<Department>();
            Department temp_ = (Department)this.comboBox2.SelectedItem;
            list_dep.Add(temp_);

            Form.populate_organizations(list_org);
            Form.populate_departments(list_dep);

            Form.populate_employees((int)this.comboBox1.SelectedValue, (int)this.comboBox2.SelectedValue);
            Form.populate_TofDeduction();

            Form.ShowDialog();

            if (Form.DialogResult == DialogResult.OK)
            {
                // Добавление в таблицу
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    if (dataGridView1.Rows[i].Cells[0].Value == null)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = dataGridView1.Rows.Count - 1;
                        dataGridView1.Rows[i].Cells[1].Value = Form.ComboBox3.Text;
                        dataGridView1.Rows[i].Cells[2].Value = Form.ComboBox4.Text;
                        dataGridView1.Rows[i].Cells[3].Value = (double)Form.NumericUpDown1.Value;


                        // Подсчет итогов
                        SalaryDeduction sd = new SalaryDeduction();
                        sd.id = 0;
                        sd.Data = DateTime.Now;
                        sd.Employees_id = (int)Form.ComboBox3.SelectedValue;
                        sd.Organization_id = (int)this.comboBox1.SelectedValue;
                        sd.Departments_id = (int)this.comboBox2.SelectedValue;
                        sd.TypeOfDeduction_id = (int)Form.ComboBox4.SelectedValue;
                        sd.Result = (double)dataGridView1.Rows[i].Cells[3].Value;

                        list.Add(sd);

                        break;
                    }
            }
        }

        private void populate_organizations()
        {
            var dataSource = m.SelectOrg();

            this.comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.AbbrName).ToList();

            this.comboBox1.DataSource = dataSource;
            this.comboBox1.DisplayMember = "FullName";
            this.comboBox1.ValueMember = "id";
        }

        private void populate_departments()
        {
            var dataSource = m.SelectDep();

            this.comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.Title).ToList();

            this.comboBox2.DataSource = dataSource;
            this.comboBox2.DisplayMember = "Title";
            this.comboBox2.ValueMember = "id";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SalaryDeduction elem in list)
                {
                    m.Insert(elem);
                }
            }
            catch
            {
                MessageBox.Show("Хьюстон, у нас проблемы!");
            }

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            try
            {
                dataGridView1.Rows.RemoveAt(index);
                list.RemoveAt(index);
            }
            catch
            {
                MessageBox.Show("Не удается удалить эту строку!");
            }
        }
    }
}
