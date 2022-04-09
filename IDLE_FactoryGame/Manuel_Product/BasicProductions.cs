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
    public partial class BasicProductions : Sistem.MasterFrm
    {
        public BasicProductions()
        {
            InitializeComponent();
        }

        private void BasicProductions_Load(object sender, EventArgs e)
        {
            int max_level = Convert.ToInt16(Globals.sql.Command("select max(mat_level) from MATERIALS where mat_IsActive = 1"));

            for (int i = 1; i < max_level; i++)
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label.Dock = System.Windows.Forms.DockStyle.Top;
                label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
                label.TabIndex = 0;
                label.Text = "Level " + (i + 1) + " Products";
                label.Name = "label" + i.ToString();
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.Controls.Add(label);
                label.BringToFront();

                System.Windows.Forms.FlowLayoutPanel flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
                flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
                flowLayoutPanel.Location = new System.Drawing.Point(0, 23);
                flowLayoutPanel.Name = "flowLayoutPanel" + i.ToString();
                flowLayoutPanel.Size = new System.Drawing.Size(800, 100);
                flowLayoutPanel.TabIndex = 1;
                this.Controls.Add(flowLayoutPanel);
                flowLayoutPanel.BringToFront();

                DataTable dt = Globals.sql.Table("select * from MATERIALS where mat_IsActive = 1 and  mat_level  = " + (i + 1) + " ");
                for (int ii = 0; ii < dt.Rows.Count; ii++)
                {
                    DataTable dt_recipe = Globals.sql.Table("select * , (select mat_Name from MATERIALS where mat_Code = rec_Material) as Name from RECIPES where rec_Code = '" + dt.Rows[ii]["mat_Code"].ToString() + "' and rec_IsActive = 1 order by rec_IOType asc ");
                    Button button = new Button();
                    string recipe = "";
                    for (int iii = 0; iii < dt_recipe.Rows.Count; iii++)
                    {
                        recipe += dt_recipe.Rows[iii]["rec_IOType"].ToString() + "  ->  (" + dt_recipe.Rows[iii]["rec_Quantity"].ToString() + ") " + dt_recipe.Rows[iii]["Name"].ToString() + Environment.NewLine;
                    }

                    button.Name = dt.Rows[ii]["mat_Code"].ToString();
                    button.Size = new System.Drawing.Size(150, 50);
                    button.Text = dt.Rows[ii]["mat_Name"].ToString();
                    button.UseVisualStyleBackColor = true;
                    button.Click += Button_Click;
                    flowLayoutPanel.Controls.Add(button);

                    Globals.Controls_Tooltip("Product Needs", recipe, button);
                }

            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            DataTable dt_recipe = Globals.sql.Table("select * from RECIPES where rec_Code = '" + btn.Name + "' and rec_IsActive = 1 and rec_Productivite = 1 order by rec_IOType asc ");
            double fund = 0;
            string material = "";
            bool err = false;

            if (dt_recipe.Rows.Count > 0)
            {
                for (int i = 0; i < dt_recipe.Rows.Count; i++)
                {
                    string io = dt_recipe.Rows[i]["rec_IOType"].ToString();
                    if (io == "i")
                    {
                        string mat = dt_recipe.Rows[i]["rec_Material"].ToString();
                        double valueee = Convert.ToDouble(Globals.Get_MyResource_PropValue_FromString(mat));
                        double funddd = Convert.ToDouble(dt_recipe.Rows[i]["rec_Quantity"].ToString());
                        if (valueee - funddd < 0)
                        {
                            MessageBox.Show("Material Needed!");
                            err = true;
                            break;
                        }
                    }
                }

                if (!err)
                {
                    for (int i = 0; i < dt_recipe.Rows.Count; i++)
                    {
                        string io = dt_recipe.Rows[i]["rec_IOType"].ToString();

                        switch (io)
                        {
                            case "i":
                                fund = Convert.ToDouble(dt_recipe.Rows[i]["rec_Quantity"].ToString());
                                material = dt_recipe.Rows[i]["rec_Material"].ToString();
                                Globals.Set_MyResource_PropValue_FromString(material, fund, "-");
                                break;
                            case "o":
                                fund = Convert.ToDouble(dt_recipe.Rows[i]["rec_Quantity"].ToString());
                                material = dt_recipe.Rows[i]["rec_Material"].ToString();
                                Globals.Set_MyResource_PropValue_FromString(material, fund, "+");
                                break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Recipe Needed!");
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
