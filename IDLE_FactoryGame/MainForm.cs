using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IDLE_FactoryGame
{
    public partial class MainForm : Sistem.MasterFrm
    {
        public MainForm()
        {
            InitializeComponent();
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            Application.Idle += HandleApplicationIdle;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }
        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);
        bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
        }
        void HandleApplicationIdle(object sender, EventArgs e)
        {
            while (IsApplicationIdle())
            {
                Update();
                Render();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetAlerts();
            Machines.Machine.StartAll();
            Models.ResourcesModel.SaveAllResources();
        }

        void Render()
        {
        }
        void Update()
        {
            ShowResource();
        }

        private void GetAlerts()
        {
            if (Globals.Alert.Trim().Length > 0)
            {
                list_Alerts.Items.Add(Globals.Alert);
                Globals.Alert = "";
            }
        }

        private void ShowResource()
        {
            string material = "";
            for (int i = 0; i < Resources.ActiveMaterialList.Count; i++)
            {
                material = Resources.ActiveMaterialList[i];                
                Label lbl = this.Controls.Find(material, true).FirstOrDefault() as Label;
                lbl.Text = Convert.ToString(Globals.Get_MyResource_PropValue_FromString(material));
            }
        }

        private void btn_my_all_machines_Click(object sender, EventArgs e) { new Forms.MyMachines { }.ShowDialog(); }
        private void btn_Producting_Click(object sender, EventArgs e) { new Manuel_Product.BasicProductions { }.ShowDialog(); }
        private void btn_Manuel_Mine_Click(object sender, EventArgs e) { new Manuel_Product.ManualMine { }.ShowDialog(); }


        private void btn_Build_PowerPlant_Click(object sender, EventArgs e)
        {
            new Forms.ChooseMK() { level = 0, MachineBuildCategory = "POWER_PLANT" }.ShowDialog();
        }
        private void btn_Build_Mıner_Click(object sender, EventArgs e)
        {
            new Forms.ChooseMK() { level = 1, MachineBuildCategory = "MINER" }.ShowDialog();
        }
        private void btn_Build_Smelter_Click(object sender, EventArgs e)
        {
            new Forms.ChooseMK() { level = 2, MachineBuildCategory = "SMELTER" }.ShowDialog();
        }
        private void btn_Build_Producter_Click(object sender, EventArgs e)
        {
            new Forms.ChooseMK() { level = 3, MachineBuildCategory = "PRODUCTER" }.ShowDialog();
        }
    }
}
