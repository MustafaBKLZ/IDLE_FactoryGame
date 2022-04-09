using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDLE_FactoryGame.Machines
{
    public static class Machine
    {
        static public List<SingleMachine> AllActiveMachines = new List<SingleMachine>();

        public static List<object[]> Minuses = new List<object[]>(); // tüketilecekler
        public static List<object[]> Plusses = new List<object[]>(); // üretilecekler

        public static void StartAll()
        {
            Minuses.Clear();
            Plusses.Clear();

            object[] list;
            bool dont_import = false;
            for (int i = 0; i < AllActiveMachines.Count; i++)
            {
                if (!AllActiveMachines[i].ProductType.Contains("POWER"))
                {
                    for (int ii = 0; ii < AllActiveMachines[i].Recipes.Count; ii++)
                    {
                        list = new object[6];
                        list[0] = AllActiveMachines[i].Recipes[ii].Material;
                        list[1] = AllActiveMachines[i].Recipes[ii].Quantity;
                        list[2] = AllActiveMachines[i].Count;
                        list[3] = AllActiveMachines[i].MaxProductPerMin;
                        list[4] = AllActiveMachines[i].ProductType;
                        list[5] = AllActiveMachines[i].Recipes[ii].MaterialLevel;

                        if (AllActiveMachines[i].Recipes.Count > 1 && AllActiveMachines[i].Recipes[ii].IOType == "i")
                        {
                            /*Recipe Quantity X Machine Count X Machine Producct Per Min */
                            double fund =
                                Convert.ToDouble(AllActiveMachines[i].Recipes[ii].Quantity) *
                                Convert.ToDouble(AllActiveMachines[i].Count) *
                                Convert.ToDouble(AllActiveMachines[i].MaxProductPerMin);
                            double quantitiy = Convert.ToDouble(Globals.Get_MyResource_PropValue_FromString(AllActiveMachines[i].Recipes[ii].Material)) - fund;                            
                            if (quantitiy <= 0) dont_import = true;
                        }                 

                        if (!dont_import)
                        {
                            if (AllActiveMachines[i].Recipes[ii].IOType == "i")
                            {
                                Minuses.Add(list);
                            }
                            if (AllActiveMachines[i].Recipes[ii].IOType == "o")
                            {
                                Plusses.Add(list);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    /* POWER Farklı şekilde hesaplanıyor.*/
                }
            }
            Resources.ComputeResource();
        }
        public static void Calculate_ProductandFund()
        {
            if (Convert.ToDouble(Globals.Get_MyResource_PropValue_FromString("POWER")) > 0)
            {
                for (int i = 0; i < Plusses.Count; i++)
                {
                    string material = Plusses[i][0].ToString();
                    /*Recipe Quantity X Machine Count X Machine Producct Per Min */
                    double fund = Convert.ToDouble(Plusses[i][1]) * Convert.ToDouble(Plusses[i][2]) * Convert.ToDouble(Plusses[i][3]);
                    Globals.Set_MyResource_PropValue_FromString(material, fund, "+");
                }
                for (int i = 0; i < Minuses.Count; i++)
                {
                    string material = Minuses[i][0].ToString();
                    /*Recipe Quantity X Machine Count X Machine Producct Per Min */
                    double fund = Convert.ToDouble(Minuses[i][1]) * Convert.ToDouble(Minuses[i][2]) * Convert.ToDouble(Minuses[i][3]);
                    double get = Convert.ToDouble(Globals.Get_MyResource_PropValue_FromString(material));
                    Globals.Set_MyResource_PropValue_FromString(material, fund, "-");
                }
            }
            else
            {
                if (AllActiveMachines.Count > 0)
                {
                    Globals.Alert = "Power not enought for machines works.";
                }
                else
                {
                    /* Makina Yok.*/
                }
            }
        }
        public static void Calculate_PowerProductandFund()
        {
            double power = 0;
            for (int i = 0; i < AllActiveMachines.Count; i++)
            {
                power += AllActiveMachines[i].TotalPowerConsume; 
            }
            Globals.Set_MyResource_PropValue_FromString("POWER", power, "+", true);
        }



        public class SingleMachine
        {
            public string Type { get; set; }
            public int MK { get; set; }
            public string Recipe { get; set; }
            public string Description { get; set; }
            public int Count { get; set; }
            public double MaxProductPerMin { get; set; }
            public double TotalPowerConsume { get; set; }
            public string ProductType { get; set; }


            public List<Recipe> Recipes { get; set; }
            public static void addListMachine(SingleMachine machine) { AllActiveMachines.Add(machine); }
            public static void Add(SingleMachine machine) { Models.MachineModel.Add(machine); }
        }
        public class Recipe
        {
            public string IOType { get; set; }
            public string Material { get; set; }
            public double Quantity { get; set; }
            public int MaterialLevel { get; set; }
        }
    }
}
