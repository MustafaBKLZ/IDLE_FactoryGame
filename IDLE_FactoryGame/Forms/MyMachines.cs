using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDLE_FactoryGame.Forms
{
    public partial class MyMachines : Sistem.MasterFrm
    {
        public MyMachines()
        {
            InitializeComponent();
        }

        private void MyMachines_Load(object sender, EventArgs e)
        {
            DataTable dt = Models.MachineModel.GetAll_ActiveMachines_FromDB();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UI.UI_MyMachines mk = new UI.UI_MyMachines();
                mk.lbl_MachineName.Text = dt.Rows[i]["Name"].ToString();
                mk.lbl_MachineCount.Text = dt.Rows[i]["amac_MachineCount"].ToString();
                mk.lbl_MachineRecipe.Text = dt.Rows[i]["MaterialName"].ToString();                
                flowLayoutPanel1.Controls.Add(mk);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

