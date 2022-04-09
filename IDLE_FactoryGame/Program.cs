using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IDLE_FactoryGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Globals.isLoad = true;
            SQLConnectionClass.Baglan();


            Models.MachineModel.GetAll_ActiveMachines_FromDB();
            Models.ResourcesModel.GetAll_ActiveResources_FromDB();
            Machines.Machine.StartAll();







            Application.Run(new MainForm());
        }
    }
}
