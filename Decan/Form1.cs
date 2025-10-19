using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Decan
{
    public partial class Form1 : Form
    {
        Logic logic;
        //public Form1()
        //{
        //    InitializeComponent();
        //    logic = new Logic();
        //    logic.DataChanged += Logic_DataChanged;

        //    InitializeChart();
        //    RefreshStudentList();
        //}

        //private void Logic_DataChanged(object sender, EventArgs e)
        //{
        //    if (InvokeRequired)
        //    {
        //        Invoke(new Action(RefreshStudentList));
        //    }
        //    else
        //    {
        //        RefreshStudentList();
        //    }
        //}

        //private void InitializeChart()
        //{
        //    chartSpeciality.ChartAreas[0].AxisX.Title = "Специальности";
        //    chartSpeciality.ChartAreas[0].AxisY.Title = "Количество студентов";
        //    chartSpeciality.Titles.Add("Распределение студентов по специальностям");
        //}
        //private void RefreshStudentList()
        //{
        //    if (listView1.Columns.Count == 0)
        //    {
        //        listView1.View = View.Details;
        //        listView1.Columns.Add("ФИО", 250);
        //        listView1.Columns.Add("Специальность", 243);
        //        listView1.Columns.Add("Группа", 200);
        //    }

        //    listView1.Items.Clear();
        //    var studentsList = logic.GetAllStudentsData();
        //    foreach (var student in studentsList)
        //    {
        //        var item = new ListViewItem(student[0]);
        //        item.SubItems.Add(student[1]);
        //        item.SubItems.Add(student[2]);
        //        listView1.Items.Add(item);
        //    }

        //    RefreshDataGridView();
        //    RefreshHistogram();
        //}

        //private void RefreshDataGridView()
        //{
        //    dataGridView1.Rows.Clear();
        //    dataGridView1.Columns.Clear();
        //    dataGridView1.Columns.Add("name", "ФИО");
        //    dataGridView1.Columns.Add("speciality", "Специальность");
        //    dataGridView1.Columns.Add("group", "Группа");

        //    var studentsList = logic.GetAllStudentsData();
        //    foreach (var student in studentsList)
        //    {
        //        dataGridView1.Rows.Add(student[0], student[1], student[2]);
        //    }
        //}

        //private void RefreshHistogram()
        //{
        //    chartSpeciality.Series[0].Points.Clear();
        //    var distribution = logic.GetSpecialityDistribution();
        //    foreach (var special in distribution)
        //    {
        //        chartSpeciality.Series[0].Points.AddXY(special.Key, special.Value);
        //    }
        //}


        //private void btnAddStudent_Click(object sender, EventArgs e)
        //{
        //    FormAddStudent formAddStudent = new FormAddStudent(logic);
        //    formAddStudent.ShowDialog();
        //    RefreshStudentList();
        //}

        //private void btnDeleteStudent_Click(object sender, EventArgs e)
        //{
        //    string name = "", speciality = "", group = "";

        //    if (listView1.Visible && listView1.SelectedItems.Count > 0)
        //    {
        //        var studentList = listView1.SelectedItems[0];
        //        name = studentList.Text ?? "";
        //        speciality = studentList.SubItems[1]?.Text ?? "";
        //        group = studentList.SubItems[2]?.Text ?? "";
        //    }
        //    else if (dataGridView1.Visible && dataGridView1.SelectedRows.Count > 0)
        //    {
        //        var studentGrid = dataGridView1.SelectedRows[0];
        //        name = studentGrid.Cells[0].Value?.ToString() ?? "";
        //        speciality = studentGrid.Cells[1].Value?.ToString() ?? "";
        //        group = studentGrid.Cells[2].Value?.ToString() ?? "";
        //    }
        //    else
        //    {
        //        MessageBox.Show("Выберите студента для удаления", "Ошибка");
        //        return;
        //    }

        //    logic.RemoveStudent(name, speciality, group);

        //    RefreshStudentList();
        //}

        //private void btnShowHistogram_Click(object sender, EventArgs e)
        //{
        //    if (chartSpeciality.Visible)
        //    {
        //        chartSpeciality.Visible = false;
        //        btnShowHistogram.Text = "Показать гистограмму";
        //    }
        //    else
        //    {
        //        chartSpeciality.Visible = true;
        //        btnShowHistogram.Text = "Скрыть гистограмму";
        //    }
        //}

        //private void btnSwitch_Click(object sender, EventArgs e)
        //{
        //    if (listView1.Visible)
        //    {
        //        listView1.Visible = false;
        //        dataGridView1.Visible = true;
        //        btnSwitch.Text = "Список";
        //    }
        //    else
        //    {
        //        listView1.Visible = true;
        //        dataGridView1.Visible = false;
        //        btnSwitch.Text = "Таблица";
        //    }
        //}

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        RefreshStudentList();
        //    }
        //    catch
        //    {
        //        Close();
        //    }
        //}

        //protected override void OnFormClosed(FormClosedEventArgs e)
        //{
        //    base.OnFormClosed(e);
        //    if (logic != null)
        //    {
        //        logic.DataChanged -= Logic_DataChanged;
        //    }
        //}
    }
}
