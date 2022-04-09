
namespace IDLE_FactoryGame
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.myResources1 = new IDLE_FactoryGame.UI.UI_MyResources();
            this.btn_my_all_machines = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_Producting = new System.Windows.Forms.Button();
            this.btn_Manuel_Mine = new System.Windows.Forms.Button();
            this.btn_Build_Mıner = new System.Windows.Forms.Button();
            this.btn_Build_Smelter = new System.Windows.Forms.Button();
            this.list_Alerts = new System.Windows.Forms.ListBox();
            this.btn_Build_PowerPlant = new System.Windows.Forms.Button();
            this.btn_Build_Producter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myResources1
            // 
            this.myResources1.AutoScroll = true;
            this.myResources1.BackColor = System.Drawing.Color.MistyRose;
            this.myResources1.Dock = System.Windows.Forms.DockStyle.Left;
            this.myResources1.Location = new System.Drawing.Point(0, 0);
            this.myResources1.Name = "myResources1";
            this.myResources1.Size = new System.Drawing.Size(288, 401);
            this.myResources1.TabIndex = 2;
            // 
            // btn_my_all_machines
            // 
            this.btn_my_all_machines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_my_all_machines.Location = new System.Drawing.Point(737, 2);
            this.btn_my_all_machines.Name = "btn_my_all_machines";
            this.btn_my_all_machines.Size = new System.Drawing.Size(136, 36);
            this.btn_my_all_machines.TabIndex = 3;
            this.btn_my_all_machines.Text = "My All Machines";
            this.btn_my_all_machines.UseVisualStyleBackColor = true;
            this.btn_my_all_machines.Click += new System.EventHandler(this.btn_my_all_machines_Click);
            // 
            // btn_Producting
            // 
            this.btn_Producting.Location = new System.Drawing.Point(291, 44);
            this.btn_Producting.Name = "btn_Producting";
            this.btn_Producting.Size = new System.Drawing.Size(136, 36);
            this.btn_Producting.TabIndex = 13;
            this.btn_Producting.Text = "Manuel Prodcut ";
            this.btn_Producting.UseVisualStyleBackColor = true;
            this.btn_Producting.Click += new System.EventHandler(this.btn_Producting_Click);
            // 
            // btn_Manuel_Mine
            // 
            this.btn_Manuel_Mine.Location = new System.Drawing.Point(291, 2);
            this.btn_Manuel_Mine.Name = "btn_Manuel_Mine";
            this.btn_Manuel_Mine.Size = new System.Drawing.Size(136, 36);
            this.btn_Manuel_Mine.TabIndex = 15;
            this.btn_Manuel_Mine.Text = "Manuel Mine";
            this.btn_Manuel_Mine.UseVisualStyleBackColor = true;
            this.btn_Manuel_Mine.Click += new System.EventHandler(this.btn_Manuel_Mine_Click);
            // 
            // btn_Build_Mıner
            // 
            this.btn_Build_Mıner.Location = new System.Drawing.Point(433, 2);
            this.btn_Build_Mıner.Name = "btn_Build_Mıner";
            this.btn_Build_Mıner.Size = new System.Drawing.Size(136, 36);
            this.btn_Build_Mıner.TabIndex = 18;
            this.btn_Build_Mıner.Text = "Build Miner";
            this.btn_Build_Mıner.UseVisualStyleBackColor = true;
            this.btn_Build_Mıner.Click += new System.EventHandler(this.btn_Build_Mıner_Click);
            // 
            // btn_Build_Smelter
            // 
            this.btn_Build_Smelter.Location = new System.Drawing.Point(433, 44);
            this.btn_Build_Smelter.Name = "btn_Build_Smelter";
            this.btn_Build_Smelter.Size = new System.Drawing.Size(136, 36);
            this.btn_Build_Smelter.TabIndex = 19;
            this.btn_Build_Smelter.Text = "Build Smelter";
            this.btn_Build_Smelter.UseVisualStyleBackColor = true;
            this.btn_Build_Smelter.Click += new System.EventHandler(this.btn_Build_Smelter_Click);
            // 
            // list_Alerts
            // 
            this.list_Alerts.Dock = System.Windows.Forms.DockStyle.Right;
            this.list_Alerts.FormattingEnabled = true;
            this.list_Alerts.Location = new System.Drawing.Point(874, 0);
            this.list_Alerts.Name = "list_Alerts";
            this.list_Alerts.Size = new System.Drawing.Size(236, 401);
            this.list_Alerts.TabIndex = 14;
            // 
            // btn_Build_PowerPlant
            // 
            this.btn_Build_PowerPlant.Location = new System.Drawing.Point(575, 2);
            this.btn_Build_PowerPlant.Name = "btn_Build_PowerPlant";
            this.btn_Build_PowerPlant.Size = new System.Drawing.Size(136, 36);
            this.btn_Build_PowerPlant.TabIndex = 20;
            this.btn_Build_PowerPlant.Text = "Build Power Plants";
            this.btn_Build_PowerPlant.UseVisualStyleBackColor = true;
            this.btn_Build_PowerPlant.Click += new System.EventHandler(this.btn_Build_PowerPlant_Click);
            // 
            // btn_Build_Producter
            // 
            this.btn_Build_Producter.Location = new System.Drawing.Point(433, 86);
            this.btn_Build_Producter.Name = "btn_Build_Producter";
            this.btn_Build_Producter.Size = new System.Drawing.Size(136, 36);
            this.btn_Build_Producter.TabIndex = 21;
            this.btn_Build_Producter.Text = "Build Producter";
            this.btn_Build_Producter.UseVisualStyleBackColor = true;
            this.btn_Build_Producter.Click += new System.EventHandler(this.btn_Build_Producter_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 401);
            this.Controls.Add(this.btn_Build_Producter);
            this.Controls.Add(this.btn_Build_PowerPlant);
            this.Controls.Add(this.btn_Build_Smelter);
            this.Controls.Add(this.btn_Build_Mıner);
            this.Controls.Add(this.btn_Manuel_Mine);
            this.Controls.Add(this.list_Alerts);
            this.Controls.Add(this.btn_Producting);
            this.Controls.Add(this.btn_my_all_machines);
            this.Controls.Add(this.myResources1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private UI.UI_MyResources myResources1;
        private System.Windows.Forms.Button btn_my_all_machines;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_Producting;
        private System.Windows.Forms.Button btn_Manuel_Mine;
        private System.Windows.Forms.Button btn_Build_Mıner;
        private System.Windows.Forms.Button btn_Build_Smelter;
        private System.Windows.Forms.ListBox list_Alerts;
        private System.Windows.Forms.Button btn_Build_PowerPlant;
        private System.Windows.Forms.Button btn_Build_Producter;
    }
}

