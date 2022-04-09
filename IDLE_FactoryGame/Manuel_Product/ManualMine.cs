using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDLE_FactoryGame.Manuel_Product
{
    public partial class ManualMine : Sistem.MasterFrm
    {
        public ManualMine()
        {
            InitializeComponent();
        }
        private void ManualMine_Load(object sender, EventArgs e)
        {
            DataTable dt = Globals.sql.Table("select * from MATERIALS where mat_IsActive = 1 and mat_level = 1 and mat_HowProduct = 'MINER'  ");
            for (int ii = 0; ii < dt.Rows.Count; ii++)
            {
                Button button = new Button();
                button.Name = dt.Rows[ii]["mat_Code"].ToString();
                button.Size = new System.Drawing.Size(150, 50);
                button.Text = dt.Rows[ii]["mat_Name"].ToString();
                button.UseVisualStyleBackColor = true;
                button.Click += Button_Click; ;
                flowLayoutPanel1.Controls.Add(button);
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Globals.Set_MyResource_PropValue_FromString(btn.Name, 1, "+");
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
