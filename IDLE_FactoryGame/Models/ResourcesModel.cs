using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDLE_FactoryGame.Models
{
    public static class ResourcesModel
    {


        public static void SaveAllResources()
        {
            DataTable dt = Globals.sql.Table("select * from MATERIALS where mat_IsActive = 1 and mat_Code not like '%_POWER' order by  mat_level asc");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string materials = dt.Rows[i]["mat_Code"].ToString();
                double valueee = Convert.ToDouble(Globals.Get_MyResource_PropValue_FromString(materials));
                SaveActiveResource(materials, valueee);
            }
        }
        //static bool isLoad = false;
        private static void SaveActiveResource(string name, double quantity)
        {
            int kontrol = Convert.ToInt16(Globals.sql.Command(" select count(*) from  ACTIVE_RESOURCES where res_Material = '" + name + "' "));
            if (kontrol == 0)
            {
                Globals.sql.Command(" INSERT INTO [dbo].[ACTIVE_RESOURCES]  "
                    + " ( "
                    + "   res_Material "
                    + " , res_Quantitiy  "
                    + " ) values ( "
                    + "   '" + name + "' "
                    + " , '" + quantity + "'  "
                    + " ) ");
            }
            else
            {
                Globals.sql.Command(" update ACTIVE_RESOURCES set "
                + " res_Quantitiy = '" + quantity + "' "
                + " where  res_Material =  '" + name + "'  "
                );
            }

            //if (!isLoad)
            //{
            //    GetAll_ActiveResources_FromDB();
            //    isLoad = true;
            //}
        }

        public static void UpdateSingleMaterials(string name, double quantity)
        {
            Globals.sql.Command(" update ACTIVE_RESOURCES set "
                    + " res_Quantitiy = '" + quantity + "' "
                    + " where  res_Material =  '" + name + "'  ");
        }


        public static void GetAll_ActiveResources_FromDB()
        {
            DataTable dt = Globals.sql.Table("select * , (select mat_level from MATERIALS where mat_Code = res_Material) as level from ACTIVE_RESOURCES where res_Material not like '%_POWER'  order by level asc"); 
            Resources.ActiveMaterialList.Clear();
            if (dt.Rows.Count == 0)
            {
                SaveAllResources();
            }
            dt = Globals.sql.Table("select * , (select mat_level from MATERIALS where mat_Code = res_Material) as level from ACTIVE_RESOURCES where res_Material not like '%_POWER'  order by level asc");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string material = dt.Rows[i]["res_Material"].ToString();
                double fund = Convert.ToDouble(dt.Rows[i]["res_Quantitiy"]);
                Globals.Set_MyResource_PropValue_FromString(material, fund, "+");
                Resources.ActiveMaterialList.Add(material);
            }

        }

    }
}
