using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDLE_FactoryGame.Models
{
    public static class MachineModel
    {
        public static DataTable GetAll_ActiveMachines_FromDB()
        {
            DataTable dt = Globals.sql.Table("Select * " +
                " , (select mac_ProductPerMin from MACHINES where mac_Type = amac_MachineType and mac_Mark =  amac_MachineMK)  as ProductPerMin " +
                " , (select mac_Name from MACHINES where mac_Type = amac_MachineType and mac_Mark = amac_MachineMK ) as Name " +
                " , (select sum(mac_PowerConsumption) from MACHINES where mac_Mark = amac_MachineMK and mac_Type = amac_MachineType) * amac_MachineCount as Power_Consume " +
                " , (select mac_ProductType from MACHINES where mac_Type = amac_MachineType and mac_Mark =  amac_MachineMK)  as ProductType " +
                " , (select mat_level from MATERIALS where mat_Code =  amac_Recipe)  as Level " +
                " , (select mat_Name from MATERIALS where mat_Code =  amac_Recipe)  as MaterialName " +
                "from ACTIVE_MACHINES order by Level asc");

            Machines.Machine.AllActiveMachines.Clear(); 
      

            List<Machines.Machine.Recipe> recipes;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt_recipe = Globals.sql.Table("select * " +
                    ", (select  mat_level from MATERIALS where mat_Code =  rec_Code)  as Level " +
                    "  from RECIPES where rec_Code = '" + dt.Rows[i]["amac_Recipe"].ToString() + "'  order by rec_IOType asc");

                recipes = new List<Machines.Machine.Recipe>();
                for (int ii = 0; ii < dt_recipe.Rows.Count; ii++)
                {
                    Machines.Machine.Recipe recipe = new Machines.Machine.Recipe()
                    {
                        IOType = dt_recipe.Rows[ii]["rec_IOType"].ToString(),
                        Material = dt_recipe.Rows[ii]["rec_Material"].ToString(),
                        Quantity = Convert.ToDouble(dt_recipe.Rows[ii]["rec_Quantity"]),
                        MaterialLevel = Convert.ToInt16(dt_recipe.Rows[ii]["Level"]),
                    };
                    recipes.Add(recipe);
                }

                Machines.Machine.SingleMachine machine = new Machines.Machine.SingleMachine()
                {
                    MK = Convert.ToInt16(dt.Rows[i]["amac_MachineMK"]),
                    Recipe = dt.Rows[i]["amac_Recipe"].ToString(),
                    Type = dt.Rows[i]["amac_MachineType"].ToString(),
                    Description = "",
                    Recipes = recipes,
                    Count = Convert.ToInt32(dt.Rows[i]["amac_MachineCount"]),
                    MaxProductPerMin = Convert.ToInt32(dt.Rows[i]["ProductPerMin"]),
                    TotalPowerConsume = Convert.ToInt32(dt.Rows[i]["Power_Consume"]),
                    ProductType = Convert.ToString(dt.Rows[i]["ProductType"]),
                };
                Machines.Machine.SingleMachine.addListMachine(machine);


            }
            return dt;
        }

        public static object Add(Machines.Machine.SingleMachine machine)
        {
            int adet = Convert.ToInt32(Globals.sql.Command("select count(*) from ACTIVE_MACHINES where "
                + " amac_MachineType = '" + machine.Type + "' and amac_MachineMK =  " + machine.MK + " and amac_Recipe = '" + machine.Recipe + "'"));
            if (adet == 0)
            {
                Globals.sql.Command(""
                               + "      INSERT INTO [dbo].[ACTIVE_MACHINES]        "
                               + "             ([amac_MachineType]                "
                               + "             ,[amac_MachineMK]                  "
                               + "             ,[amac_MachineCount]               "
                               + "             ,[amac_Recipe] )                    "
                               + "       VALUES                                   "
                               + "             (   '" + machine.Type + "' "
                               + "               ,  " + machine.MK + "          "
                               + "               ,  1     "
                               + "               , '" + machine.Recipe + "'  )     ");
            }
            else
            {
                Globals.sql.Command(""
                            + "      update [dbo].[ACTIVE_MACHINES]      set  "
                            + "             [amac_MachineCount]     =  [amac_MachineCount]    +1           "
                            + " where "
                            + " amac_MachineType = '" + machine.Type + "' and         "
                            + " amac_MachineMK =  " + machine.MK + "  and  "
                            + " amac_Recipe = '" + machine.Recipe + "'       "
                            + "                    ");
            }
            FundMaterial(machine);
            return "";
        }

        static void FundMaterial(Machines.Machine.SingleMachine machine)
        {
            string recipe = Globals.sql.Command("select mac_ConstructionRecipe from MACHINES where mac_Type= '" + machine.Type + "' and  mac_Mark = '" + machine.MK + "' and mac_IsActive = 1 ").ToString();
            DataTable dt_recipe = Globals.sql.Table("select * from CONSTRUCTION_RECIPES where com_Code = '" + recipe + "' ");

            double fund = 0;
            string material = "";
            bool err = false;

            for (int i = 0; i < dt_recipe.Rows.Count; i++)
            {
                if (!dt_recipe.Rows[i]["com_Code"].ToString().Contains("POWER"))
                {
                    string io = "i";
                    if (io == "i")
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
                }
            }

            if (!err)
            {
                for (int i = 0; i < dt_recipe.Rows.Count; i++)
                {
                    if (!dt_recipe.Rows[i]["com_Code"].ToString().Contains("POWER"))
                    {
                        fund = Convert.ToDouble(dt_recipe.Rows[i]["com_MaterialQuantity"].ToString());
                        material = dt_recipe.Rows[i]["com_MaterialName"].ToString();
                        Globals.Set_MyResource_PropValue_FromString(material, fund, "-");
                    }
                }
            }
        }
    }
}
