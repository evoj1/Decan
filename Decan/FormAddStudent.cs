using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decan
{
    public partial class FormAddStudent : Form
    {
        Logic logic;
        //public FormAddStudent(Logic logicSer)
        //{
        //    InitializeComponent();
        //    logic = logicSer;
        //}

        //private void buttonAddStudent_Click(object sender, EventArgs e)
        //{
        //    string name = textBoxName.Text;
        //    string speciality = textBoxSpeciality.Text;
        //    string group = textBoxGroup.Text;

        //    if (string.IsNullOrEmpty(name) ||
        //        string.IsNullOrEmpty(speciality) ||
        //        string.IsNullOrEmpty(group))
        //    {
        //        MessageBox.Show("Заполните все поля");
        //        return;
        //    }
        //    bool success = logic.AddStudent(name, speciality, group);
        //    if (success)
        //    {
        //        this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Не удалось добавить студента");
        //    }
        //}
    }
}
