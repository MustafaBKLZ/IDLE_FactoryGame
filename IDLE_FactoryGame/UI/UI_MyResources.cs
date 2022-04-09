using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace IDLE_FactoryGame.UI
{
    public partial class UI_MyResources : UserControl
    {
        List<string> ResourceList = new List<string>();
        public UI_MyResources()
        {
            InitializeComponent();
        }
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }


        public Panel pnl;
        public Label lbl;
        public Label lbl2;
        public Label lbl3;


        private void UI_MyResources_Load(object sender, System.EventArgs e)
        {
            if (Globals.isLoad == true)
            {
                DataTable dt = Globals.sql.Table("select " +
                    " * " +
                    " , (select mat_Name from MATERIALS where mat_Code = res_Material) as name " +
                    " , (select mat_level from MATERIALS where mat_Code = res_Material) as level " +
                    "  from ACTIVE_RESOURCES where res_Material not like '%_POWER' order by level asc");

                if (dt.Rows.Count == 0)
                {
                    Models.ResourcesModel.SaveAllResources();
                }

                dt = Globals.sql.Table("select " +
                  " * " +
                  " , (select mat_Name from MATERIALS where mat_Code = res_Material) as name " +
                  " , (select mat_level from MATERIALS where mat_Code = res_Material) as level " +
                  "  from ACTIVE_RESOURCES where res_Material not like '%_POWER' order by level asc");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pnl = new Panel();
                    pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    pnl.Name = "panel" + i + "";
                    pnl.Size = new System.Drawing.Size(269, 25);
                    pnl.TabIndex = 6;

                    lbl = new Label();
                    lbl.AutoSize = false;
                    lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
                    lbl.Location = new System.Drawing.Point(3, 2);
                    lbl.Name = "l" + i + "";
                    lbl.Size = new System.Drawing.Size(135, 20);
                    lbl.Dock = DockStyle.Left;
                    lbl.TabIndex = 0;
                    lbl.Text = dt.Rows[i]["name"].ToString();
                    pnl.Controls.Add(lbl);


                    lbl2 = new Label();
                    lbl2.AutoSize = false;
                    lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
                    lbl2.Name = "ll" + i + "";
                    lbl2.Size = new System.Drawing.Size(10, 20);
                    lbl2.Dock = DockStyle.Left;
                    lbl2.TabIndex = 0;
                    lbl2.Text = ":";
                    pnl.Controls.Add(lbl2);

                    lbl3 = new Label();
                    lbl3.AutoSize = false;
                    lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
                    lbl3.Name = dt.Rows[i]["res_Material"].ToString();
                    lbl3.Size = new System.Drawing.Size(135, 20);
                    lbl3.Dock = DockStyle.Left;
                    lbl3.TabIndex = 0;
                    lbl3.Text = "0";
                    pnl.Controls.Add(lbl3);

                    lbl3.SendToBack();
                    lbl2.SendToBack();
                    lbl.SendToBack();

                    flowLayoutPanel2.Controls.Add(pnl);
                }
            }
        }
    }
}
