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
    public partial class Form1 : Form
    {
        Manager m = new Manager();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {      
            m.Insert();
        }

        private void but_Settings_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;

            lab_header.Text = "Настройки";
            //Form_Settings Form = new Form_Settings();
            //Form.Show();
        }

        private void but_charge_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

            lab_header.Text = "Учет начислений";

            populate_salarycharge();
        }

        private void but_dedc_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

            lab_header.Text = "Учет удержаний";

            populate_salarydeduction();
        }

        private void but_time_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;

            lab_header.Text = "Учет отработанного времени";
            
            populate_timesheet();
        }

        private void but_statm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;

            lab_header.Text = "Составление расчетных ведомостей";
        }

        private void but_back_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            lab_header.Text = "Рабочий стол";
        }

        private void but_cdoc_create_Click(object sender, EventArgs e)
        {
            Form_sdeduction_add Form = new Form_sdeduction_add();
            Form.ShowDialog();

            populate_salarycharge();
        }

        private void populate_salarycharge()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Refresh();
            
            var list = m.SelectSaCList();

            this.dataGridView1.DataSource = list;
            this.dataGridView1.Refresh();
        }

        private void but_cdoc_del_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            try
            {
                m.Delete("SalaryCharge", (int)dataGridView1.CurrentRow.Cells[0].Value);
                populate_salarycharge();
            }
            catch
            {
                MessageBox.Show("Не удается удалить эту строку!");
            }
        }

        private void populate_salarydeduction()
        {
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Refresh();

            var list = m.SelectSaDList();

            this.dataGridView2.DataSource = list;
            this.dataGridView2.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_deduction_add Form = new Form_deduction_add();
            Form.ShowDialog();

            populate_salarydeduction();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView2.CurrentRow.Index;
            try
            {
                m.Delete("SalaryDeduction", (int)dataGridView2.CurrentRow.Cells[0].Value);
                populate_salarydeduction();
            }
            catch
            {
                MessageBox.Show("Не удается удалить эту строку!");
            }
        }

        private void populate_timesheet()
        {
            this.dataGridView3.DataSource = null;
            this.dataGridView3.Refresh();

            var list = m.SelectTimSList();

            this.dataGridView3.DataSource = list;
            this.dataGridView3.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form_timesheet_add Form = new Form_timesheet_add();
            Form.ShowDialog();

            populate_timesheet();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = dataGridView3.CurrentRow.Index;
            try
            {
                m.Delete("TimeSheet", (int)dataGridView3.CurrentRow.Cells[0].Value);
                populate_timesheet();
            }
            catch
            {
                MessageBox.Show("Не удается удалить эту строку!");
            }
        }

        private void but_cdoc_statm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 6;

            lab_header.Text = "Ведомость начислений";

            if (dataGridView4.Rows.Count > 1)
                    dataGridView4.Rows.Clear();
            this.populate_organizations();
            this.populate_departments();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.dataGridView4.Refresh();

            var list = m.SelectSaCStat((int)this.comboBox1.SelectedValue, (int)this.comboBox2.SelectedValue, 0, (DateTime)this.dateTimePicker1.Value, (DateTime)this.dateTimePicker2.Value);

            int i = 0,
                _empl = 0,
                pos = 0;
            double sum = 0;
            string _emplName = null;

            if (list.Count > 0)
            {
                // Добавление в таблицу
                foreach (SalaryChargeStatement elem in list)
                {
                    if (_empl == elem.Employees_id)
                    {
                        sum += elem.SalaryCharge_result;

                        dataGridView4.Rows.Add();
                        dataGridView4.Rows[i].Cells[0].Value = elem.Employees_id;
                        dataGridView4.Rows[i].Cells[1].Value = elem.Employees_name;
                        dataGridView4.Rows[i].Cells[2].Value = elem.TypeOfCharge_type;
                        dataGridView4.Rows[i].Cells[3].Value = elem.SalaryCharge_result;
                    }
                    else
                    {
                        // Вывод итоговой строки
                        dataGridView4.Rows.Add();
                        dataGridView4.Rows[pos].Cells[1].Value = elem.Employees_name;
                        dataGridView4.Rows[pos].Cells[3].Value = sum;

                        _empl = elem.Employees_id;
                        _emplName = elem.Employees_name;
                        pos = i;
                        sum = 0;

                        dataGridView4.Rows.Add();
                        dataGridView4.Rows[i + 1].Cells[0].Value = elem.Employees_id;
                        dataGridView4.Rows[i + 1].Cells[1].Value = elem.Employees_name;
                        dataGridView4.Rows[i + 1].Cells[2].Value = elem.TypeOfCharge_type;
                        dataGridView4.Rows[i + 1].Cells[3].Value = elem.SalaryCharge_result;

                    }

                    i++;
                }
                dataGridView4.Rows.Add();
                dataGridView4.Rows[pos].Cells[1].Value = _emplName;
                dataGridView4.Rows[pos].Cells[3].Value = sum;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void populate_organizations_2()
        {
            var dataSource = m.SelectOrg();

            this.comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.AbbrName).ToList();

            this.comboBox3.DataSource = dataSource;
            this.comboBox3.DisplayMember = "FullName";
            this.comboBox3.ValueMember = "id";
        }

        private void populate_departments_2()
        {
            var dataSource = m.SelectDep();

            this.comboBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.Title).ToList();

            this.comboBox4.DataSource = dataSource;
            this.comboBox4.DisplayMember = "Title";
            this.comboBox4.ValueMember = "id";
        }

        private void populate_organizations_3()
        {
            var dataSource = m.SelectOrg();

            this.comboBox5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.AbbrName).ToList();

            this.comboBox5.DataSource = dataSource;
            this.comboBox5.DisplayMember = "FullName";
            this.comboBox5.ValueMember = "id";
        }

        private void populate_departments_3()
        {
            var dataSource = m.SelectDep();

            this.comboBox6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox6.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.Title).ToList();

            this.comboBox6.DataSource = dataSource;
            this.comboBox6.DisplayMember = "Title";
            this.comboBox6.ValueMember = "id";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.dataGridView5.Refresh();

            var list = m.SelectSaDStat((int)this.comboBox3.SelectedValue, (int)this.comboBox4.SelectedValue, 0, (DateTime)this.dateTimePicker3.Value, (DateTime)this.dateTimePicker4.Value);

            int i = 0,
                _empl = 0,
                pos = 0;
            double sum = 0;
            string _emplName = null;

            if (list.Count > 0)
            {
                // Добавление в таблицу
                foreach (SalaryDeductionStatement elem in list)
                {
                    if (_empl == elem.Employees_id)
                    {
                        sum += elem.SalaryDeduction_result;

                        dataGridView5.Rows.Add();
                        dataGridView5.Rows[i].Cells[0].Value = elem.Employees_id;
                        dataGridView5.Rows[i].Cells[1].Value = elem.Employees_name;
                        dataGridView5.Rows[i].Cells[2].Value = elem.TypeOfDeduction_type;
                        dataGridView5.Rows[i].Cells[3].Value = elem.SalaryDeduction_result;
                    }
                    else
                    {
                        // Вывод итоговой строки
                        dataGridView5.Rows.Add();
                        dataGridView5.Rows[pos].Cells[1].Value = elem.Employees_name;
                        dataGridView5.Rows[pos].Cells[3].Value = sum;

                        _empl = elem.Employees_id;
                        _emplName = elem.Employees_name;
                        pos = i;
                        sum = 0;

                        dataGridView5.Rows.Add();
                        dataGridView5.Rows[i + 1].Cells[0].Value = elem.Employees_id;
                        dataGridView5.Rows[i + 1].Cells[1].Value = elem.Employees_name;
                        dataGridView5.Rows[i + 1].Cells[2].Value = elem.TypeOfDeduction_type;
                        dataGridView5.Rows[i + 1].Cells[3].Value = elem.SalaryDeduction_result;

                    }

                    i++;
                }
                dataGridView5.Rows.Add();
                dataGridView5.Rows[pos].Cells[1].Value = _emplName;
                dataGridView5.Rows[pos].Cells[3].Value = sum;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 7;

            lab_header.Text = "Ведомость удержаний";

            if (dataGridView6.Rows.Count > 1)
                dataGridView6.Rows.Clear();
            this.populate_organizations_2();
            this.populate_departments_2();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            var list = m.SelectTimSStat((int)this.comboBox5.SelectedValue, (int)this.comboBox6.SelectedValue, (DateTime)this.dateTimePicker5.Value, (DateTime)this.dateTimePicker6.Value);

            int j = -2,
                _empl = 0,
                _day = 0,
                SumD = 0,
                SumY = 0,
                SumN = 0,
                SumV = 0;

            if (list.Count > 0)
            {
                // Добавление в таблицу
                foreach (TimeSheetStatement elem in list)
                {
                    if (_empl == elem.Employees_id)
                    {
                        _day = (int)elem.Timesheet_date.Day;

                        // Добавляем статус
                        this.dataGridView6.Rows[j].Cells[_day + 1].Value = elem.WorkdayStatus;
                        // Добавляем отработанные часы
                        this.dataGridView6.Rows[j + 1].Cells[_day + 1].Value = elem.HoursCol;

                        if (elem.WorkdayStatus == "Я")
                        {
                            SumY += elem.HoursCol;
                            SumD += 1;
                        }
                        else if (elem.WorkdayStatus == "Н")
                            SumN += 1;
                        else if (elem.WorkdayStatus == "В")
                            SumV += 1;

                        // Добавляем табельный номер и ФИО
                        this.dataGridView6.Rows[j + 1].Cells[0].Value = elem.Employees_id;
                        this.dataGridView6.Rows[j + 1].Cells[1].Value = elem.Employees_name;
                    }
                    else
                    {
                        if (j > 0)
                        {
                            this.dataGridView6.Rows[j + 1].Cells[34].Value = SumD;
                            this.dataGridView6.Rows[j + 1].Cells[35].Value = SumY;
                            this.dataGridView6.Rows[j + 1].Cells[36].Value = SumN;
                            this.dataGridView6.Rows[j + 1].Cells[37].Value = SumV;
                        }

                        _empl = elem.Employees_id;

                        SumD = 0;
                        SumY = 0;
                        SumN = 0;
                        SumV = 0;

                        j = j + 2;

                        // Добавляем строку статусов
                        this.dataGridView6.Rows.Add();
                        // Добавляем строку часов
                        this.dataGridView6.Rows.Add();

                        _day = (int)elem.Timesheet_date.Day;

                        // Добавляем статус
                        this.dataGridView6.Rows[j].Cells[_day + 1].Value = elem.WorkdayStatus;
                        // Добавляем отработанные часы
                        this.dataGridView6.Rows[j + 1].Cells[_day + 1].Value = elem.HoursCol;

                        if (elem.WorkdayStatus == "Я")
                        {
                            SumY += elem.HoursCol;
                            SumD += 1;
                        }
                        else if (elem.WorkdayStatus == "Н")
                            SumN += 1;
                        else if (elem.WorkdayStatus == "В")
                            SumV += 1;

                        // Добавляем табельный номер и ФИО
                        this.dataGridView6.Rows[j + 1].Cells[0].Value = elem.Employees_id;
                        this.dataGridView6.Rows[j + 1].Cells[1].Value = elem.Employees_name;
                    }
                    this.dataGridView6.Rows[j + 1].Cells[33].Value = SumD;
                    this.dataGridView6.Rows[j + 1].Cells[34].Value = SumY;
                    this.dataGridView6.Rows[j + 1].Cells[35].Value = SumN;
                    this.dataGridView6.Rows[j + 1].Cells[36].Value = SumV;
                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 8;

            lab_header.Text = "Ведомость (табель) учета рабочего времени";

            if (dataGridView6.Rows.Count > 1)
                dataGridView6.Rows.Clear();
            this.populate_organizations_3();
            this.populate_departments_3();
        }

        private void populate_organizations_4()
        {
            var dataSource = m.SelectOrg();

            this.comboBox7.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.AbbrName).ToList();

            this.comboBox7.DataSource = dataSource;
            this.comboBox7.DisplayMember = "FullName";
            this.comboBox7.ValueMember = "id";
        }

        private void populate_departments_4()
        {
            var dataSource = m.SelectDep();

            this.comboBox8.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox8.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.Title).ToList();

            this.comboBox8.DataSource = dataSource;
            this.comboBox8.DisplayMember = "Title";
            this.comboBox8.ValueMember = "id";
        }

        public void populate_employees_4(int id_org, int id_dep)
        {
            var dataSource = m.SelectEmp(id_org, id_dep);

            this.comboBox9.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox9.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.Name).ToList();

            this.comboBox9.DataSource = dataSource;
            this.comboBox9.DisplayMember = "Name";
            this.comboBox9.ValueMember = "id";
        }

        private void populate_organizations_5()
        {
            var dataSource = m.SelectOrg();

            this.comboBox10.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox10.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataSource.OrderBy(t => t.AbbrName).ToList();

            this.comboBox10.DataSource = dataSource;
            this.comboBox10.DisplayMember = "FullName";
            this.comboBox10.ValueMember = "id";
        }

        private void but_rlist_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 9;

            lab_header.Text = "Расчетный лист";

            if (dataGridView7.Rows.Count > 1)
                dataGridView7.Rows.Clear();
            this.populate_organizations_4();
            this.populate_departments_4();
            this.populate_employees_4((int)this.comboBox7.SelectedValue, (int)this.comboBox8.SelectedValue);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.dataGridView7.Refresh();

            // Начисления
            var list_sc = m.SelectSaCStat((int)this.comboBox7.SelectedValue, (int)this.comboBox8.SelectedValue, (int)this.comboBox9.SelectedValue, (DateTime)this.dateTimePicker7.Value, (DateTime)this.dateTimePicker8.Value);

            // Удержания
            var list_sd = m.SelectSaDStat((int)this.comboBox7.SelectedValue, (int)this.comboBox8.SelectedValue, (int)this.comboBox9.SelectedValue, (DateTime)this.dateTimePicker7.Value, (DateTime)this.dateTimePicker8.Value);

            // Добавляем фамилию
            this.dataGridView7.Rows.Add();
            this.dataGridView7.Rows.Add();
            this.dataGridView7.Rows.Add();
            this.dataGridView7.Rows.Add();

            this.dataGridView7.Rows[0].Cells[0].Value = this.comboBox9.Text;
            this.dataGridView7.Rows[1].Cells[0].Value = "К выплате:";
            this.dataGridView7.Rows[2].Cells[0].Value = this.comboBox9.SelectedValue;
            this.dataGridView7.Rows[3].Cells[0].Value = "1.Начислено";
            this.dataGridView7.Rows[3].Cells[2].Value = "2.Удержано";

            int pos = 4,
                i = pos;

            double sumSC = 0,
                   sumSD = 0;

            if (list_sc.Count > 0)
            {
                // Добавление в таблицу
                foreach (SalaryChargeStatement elem in list_sc)
                {
                    // Добавляем новую строку
                    this.dataGridView7.Rows.Add();

                    dataGridView7.Rows[i].Cells[0].Value = elem.TypeOfCharge_type;
                    dataGridView7.Rows[i].Cells[1].Value = elem.SalaryCharge_result;

                    // Складываем начисления
                    sumSC += elem.SalaryCharge_result;

                    i++;
                }

                this.dataGridView7.Rows.Add();

                dataGridView7.Rows[i].Cells[0].Value = "Всего начислено:";
                dataGridView7.Rows[i].Cells[1].Value = sumSC;
            }

            i = pos;

            if (list_sd.Count > 0)
            {
                // Добавление в таблицу
                foreach (SalaryDeductionStatement elem in list_sd)
                {
                    // Добавляем новую строку

                    dataGridView7.Rows[i].Cells[2].Value = elem.TypeOfDeduction_type;
                    dataGridView7.Rows[i].Cells[3].Value = elem.SalaryDeduction_result;

                    // Складываем начисления
                    sumSD += elem.SalaryDeduction_result;

                    i++;
                }

                this.dataGridView7.Rows.Add();

                dataGridView7.Rows[i].Cells[2].Value = "Всего удержано:";
                dataGridView7.Rows[i].Cells[3].Value = sumSD;

                this.dataGridView7.Rows[1].Cells[1].Value = sumSC - sumSD;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // Формирование ведомости
            this.dataGridView8.Refresh();

            var list = m.SelectEstSheet((int)this.comboBox10.SelectedValue, (DateTime)this.dateTimePicker9.Value, (DateTime)this.dateTimePicker10.Value);

            double sum = 0;

            this.dataGridView8.Rows.Add();

            this.dataGridView8.Rows[0].Cells[0].Value = "Организация:";
            this.dataGridView8.Rows[0].Cells[1].Value = this.comboBox10.Text;
            this.dataGridView8.Rows[0].Cells[3].Value = "Отчетный";
            this.dataGridView8.Rows[0].Cells[4].Value = "период";

            int i = 2;

            foreach (EstimatedSheet elem in list)
            {
                this.dataGridView8.Rows.Add();

                this.dataGridView8.Rows[i].Cells[0].Value = elem.Employees_id;
                this.dataGridView8.Rows[i].Cells[1].Value = elem.Employees_name;
                this.dataGridView8.Rows[i].Cells[2].Value = elem.Post;
                this.dataGridView8.Rows[i].Cells[3].Value = elem.Employees_Salary;
                this.dataGridView8.Rows[i].Cells[4].Value = elem.HoursCol;
                this.dataGridView8.Rows[i].Cells[5].Value = elem.SalaryCharge_result;
                this.dataGridView8.Rows[i].Cells[6].Value = elem.SalaryDeduction_result;
                this.dataGridView8.Rows[i].Cells[7].Value = elem.Result;

                sum += elem.Result;

                i++;
            }

            this.dataGridView8.Rows[1].Cells[0].Value = "Всего к выплате:";
            this.dataGridView8.Rows[1].Cells[1].Value = sum;
            this.dataGridView8.Rows[1].Cells[3].Value = this.dateTimePicker9.Text;
            this.dataGridView8.Rows[1].Cells[4].Value = this.dateTimePicker10.Text;
        }

        private void but_rstatm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 10;

            lab_header.Text = "Расчетная ведомость";

            if (dataGridView8.Rows.Count > 1)
                dataGridView8.Rows.Clear();
            this.populate_organizations_5();
        }
    }
}
