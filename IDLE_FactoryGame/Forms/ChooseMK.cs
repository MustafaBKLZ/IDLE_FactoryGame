using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDLE_FactoryGame.Forms
{
    public partial class ChooseMK : Sistem.MasterFrm
    {
        public ChooseMK()
        {
            InitializeComponent();
        }

        public string MachineBuildCategory = "";
        public string MachineName = "";
        public int level = 0;

        private void ChooseMinerMK_Load(object sender, EventArgs e)
        {
            DataTable dt = Globals.sql.Table("select * from MACHINES where mac_IsActive = 1 and mac_BuildCategory = '" + MachineBuildCategory + "'  ");

            for (int ii = 0; ii < dt.Rows.Count; ii++)
            {
                DataTable dt_recipe = Globals.sql.Table("select * , (select mat_Name from MATERIALS where mat_Code = com_MaterialName ) as Name from CONSTRUCTION_RECIPES where com_Code = '" + dt.Rows[ii]["mac_ConstructionRecipe"].ToString() + "'  ");
                Button button = new Button();
                string recipe = "";
                for (int iii = 0; iii < dt_recipe.Rows.Count; iii++)
                {
                    recipe += "i" + "  ->  (" + dt_recipe.Rows[iii]["com_MaterialQuantity"].ToString() + ") " + dt_recipe.Rows[iii]["Name"].ToString() + Environment.NewLine;
                }

                string code = dt.Rows[ii]["mac_Type"].ToString();
                string mk = dt.Rows[ii]["mac_Mark"].ToString();
                string name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(code.ToLower()) + " MK " + mk;
                string recipe_code = dt.Rows[ii]["mac_ConstructionRecipe"].ToString();

                button.Name = code + "@" + mk + "@" + recipe_code;
                button.Text = name.Replace("_", " ");
                button.Size = new System.Drawing.Size(150, 50);
                button.UseVisualStyleBackColor = true;
                button.Click += Btn1_Click;

                flowLayoutPanel1.Controls.Add(button);

                Globals.Controls_Tooltip("Build Needs", recipe, button);
            }
        }


        private void Btn1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            DataTable dt_recipe = Globals.sql.Table("select * from CONSTRUCTION_RECIPES where com_Code = '" + button.Name.Split('@')[2] + "' ");
            double fund = 0;
            string material = "";
            bool err = false;

            for (int i = 0; i < dt_recipe.Rows.Count; i++)
            {
                string mat = dt_recipe.Rows[i]["com_MaterialName"].ToString();
                double valueee = Convert.ToDouble(Globals.Get_MyResource_PropValue_FromString(mat));
                double funddd = Convert.ToDouble(dt_recipe.Rows[i]["com_MaterialQuantity"].ToString());
                if (valueee - funddd < 0)
                {
                    MessageBox.Show("Material Needed!");
                    err = true;
                    break;
                }
            }

            if (!err)
            {
                if (MachineBuildCategory == "POWER_PLANT")
                {
                    new Forms.ChooseRecipe() { MachineBuildCategory = MachineBuildCategory, MachineName = button.Name.Split('@')[0], level = level, MK = Convert.ToInt16(button.Name.Split('@')[1]) }.ShowDialog();
                }
                else
                    new Forms.ChooseRecipe() { MachineBuildCategory = MachineBuildCategory, MachineName = button.Name.Split('@')[0], level = level, MK = Convert.ToInt16(button.Name.Split('@')[1]) }.ShowDialog();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
