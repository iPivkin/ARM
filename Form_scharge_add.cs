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
    public partial class Form_sdeduction_add : Form
    {
        Manager m = new Manager();
        
        List<SalaryCharge> list = new List<SalaryCharge>();
        List<TimeSheet> tlist = new List<TimeSheet>();

        public Form_sdeduction_add()
        {
            InitializeComponent();

            populate_organizations();
            populate_departments();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void but_next_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(SalaryCharge elem in list)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form_scharge_addItem Form = new Form_scharge_addItem();

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
            Form.populate_TofCharge();

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

                        if ((int)Form.ComboBox4.SelectedValue == 1)
                        {
                            dataGridView1.Rows[i].Cells[3].Value = 0;
                            dataGridView1.Rows[i].Cells[4].Value = 0;
                            dataGridView1.Rows[i].Cells[5].Value = (double)Form.NumericUpDown1.Value;
                        }
                        else if ((int)Form.ComboBox4.SelectedValue == 2)
                        {
                            tlist = m.SelectTimS((int)this.comboBox1.SelectedValue,
                                (int)this.comboBox2.SelectedValue,
                                (int)Form.ComboBox3.SelectedValue);

                            dataGridView1.Rows[i].Cells[3].Value = HoursOfWork();
                            dataGridView1.Rows[i].Cells[4].Value = DaysOfWork();

                            var empl = (Employ)Form.ComboBox3.SelectedItem;
                            int planNumWork = planNumberOfHours(empl.WorkShedule_id);
                            double salary = empl.Salary;

                            if ((int)dataGridView1.Rows[i].Cells[3].Value == planNumWork)
                            {
                                dataGridView1.Rows[i].Cells[5].Value = salary;
                            }
                            else
                            {
                                double stavka = salary / planNumWork;

                                dataGridView1.Rows[i].Cells[5].Value = stavka * (int)dataGridView1.Rows[i].Cells[3].Value;
                            }                            
                        }

                        // Подсчет итогов
                        SalaryCharge sc = new SalaryCharge();
                        sc.Data = DateTime.Now;
                        sc.Employees_id = (int)Form.ComboBox3.SelectedValue;
                        sc.Organization_id = (int)this.comboBox1.SelectedValue;
                        sc.Departments_id = (int)this.comboBox2.SelectedValue;
                        sc.StartPeriod = (DateTime)this.dateTimePicker1.Value;
                        sc.EndPeriod = (DateTime)this.dateTimePicker2.Value;
                        sc.TypeOfChrage_id = (int)Form.ComboBox4.SelectedValue;
                        sc.HoursOfWork = (int)dataGridView1.Rows[i].Cells[3].Value;
                        sc.DaysOfWork = (int)dataGridView1.Rows[i].Cells[4].Value;
                        sc.Result = (double)dataGridView1.Rows[i].Cells[5].Value;

                        list.Add(sc);

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
            this.comboBox1.ValueMember   = "id";
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

        private int HoursOfWork()
        {
            int HoursOfWork = 0;

            foreach (TimeSheet elem in tlist)
            {
                HoursOfWork += elem.HoursCol;
            }

            return HoursOfWork;
        }

        private int DaysOfWork()
        {
            return tlist.Count;
        }

        private int planNumberOfHours(int id)
        {
            var _list = m.SelectWoS(id);

            int num = 0;

            foreach (WorkShedule elem in _list)
            {
                num = elem.NumberOfHours;
            }

            return num;
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
    }
}
