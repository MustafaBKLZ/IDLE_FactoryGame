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
    public partial class ChooseRecipe : Sistem.MasterFrm
    {
        public ChooseRecipe()
        {
            InitializeComponent();
        }

        public string MachineBuildCategory = "";
        public string MachineName = "";
        public int level = 0;
        public int MK = 0;
        private void ChooseMinerMK_Load(object sender, EventArgs e)
        {
            DataTable dt = Globals.sql.Table("select * from MATERIALS where mat_IsActive = 1 and /*mat_level = " + level + " and*/ mat_HowProduct = '" + MachineBuildCategory + "' ORDER BY  mat_level ASC");
            for (int ii = 0; ii < dt.Rows.Count; ii++)
            {
                string s = dt.Rows[ii]["mat_Code"].ToString();
                DataTable dt_recipe = Globals.sql.Table("select *  , (select mat_Name from MATERIALS where mat_Code = rec_Material) as Name from RECIPES where rec_Code = '" + s + "' and rec_IsActive = 1 order by rec_IOType asc ");
                Button button = new Button();
                string recipe = "";
                for (int iii = 0; iii < dt_recipe.Rows.Count; iii++)
                {
                    recipe += dt_recipe.Rows[iii]["rec_IOType"].ToString() + "  ->  (" + dt_recipe.Rows[iii]["rec_Quantity"].ToString() + ") " + dt_recipe.Rows[iii]["Name"].ToString() + Environment.NewLine;
                }
                string code = dt.Rows[ii]["mat_Code"].ToString();
                string name = dt.Rows[ii]["mat_Name"].ToString();
                string description = dt.Rows[ii]["mat_Name"].ToString();

                button.Name = code + "@" + name;
                button.Size = new System.Drawing.Size(150, 50);
                button.Text = dt.Rows[ii]["mat_Name"].ToString();
                button.UseVisualStyleBackColor = true;
                button.Click += Button_Click;
                flowLayoutPanel1.Controls.Add(button);

                Globals.Controls_Tooltip("Product Needs", recipe, button);
            }
        }


        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            DataTable dt_recipe = Globals.sql.Table("select * from CONSTRUCTION_RECIPES where com_Code = '" + button.Name.Split('@')[0] + "' ");
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
                for (int i = 0; i < dt_recipe.Rows.Count; i++)
                {
                    fund = Convert.ToDouble(dt_recipe.Rows[i]["com_MaterialQuantity"].ToString());
                    material = dt_recipe.Rows[i]["com_MaterialName"].ToString();
                    Globals.Set_MyResource_PropValue_FromString(material, fund, "-");
                }

                List<Machines.Machine.Recipe> recipe_list = new List<Machines.Machine.Recipe>();
                for (int i = 0; i < dt_recipe.Rows.Count; i++)
                {
                    Machines.Machine.Recipe recipe = new Machines.Machine.Recipe()
                    {
                        IOType = dt_recipe.Rows[i]["rec_IOType"].ToString(),
                        Material = dt_recipe.Rows[i]["rec_Material"].ToString(),
                        Quantity = Convert.ToDouble(dt_recipe.Rows[i]["rec_Quantity"].ToString()),
                    };
                    recipe_list.Add(recipe);
                }

                Machines.Machine.SingleMachine machine = new Machines.Machine.SingleMachine()
                {
                    Description = "",
                    MK = MK,
                    Recipe = button.Name.Split('@')[0],
                    Type = MachineName,
                    Recipes = recipe_list,
                    ProductType = Convert.ToString(Globals.sql.Command("select mac_ProductType from MACHINES where mac_Type = '" + MachineName + "'")),
                    MaxProductPerMin = Convert.ToDouble(Globals.sql.Command("select mac_ProductPerMin from MACHINES where mac_Type = '" + MachineName + "'")),
                };
                Machines.Machine.SingleMachine.Add(machine);
                //Machines.Machine.SingleMachine.addListMachine(machine);

                Models.MachineModel.GetAll_ActiveMachines_FromDB();
                Machines.Machine.StartAll();                
            }


        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
