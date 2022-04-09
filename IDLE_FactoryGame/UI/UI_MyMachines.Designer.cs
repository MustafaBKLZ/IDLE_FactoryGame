
namespace IDLE_FactoryGame.UI
{
    partial class UI_MyMachines
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_MachineName = new System.Windows.Forms.Label();
            this.lbl_MachineCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_MachineRecipe = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantity :";
            // 
            // lbl_MachineName
            // 
            this.lbl_MachineName.AutoSize = true;
            this.lbl_MachineName.Location = new System.Drawing.Point(63, 7);
            this.lbl_MachineName.Name = "lbl_MachineName";
            this.lbl_MachineName.Size = new System.Drawing.Size(13, 13);
            this.lbl_MachineName.TabIndex = 0;
            this.lbl_MachineName.Text = "0";
            // 
            // lbl_MachineCount
            // 
            this.lbl_MachineCount.AutoSize = true;
            this.lbl_MachineCount.Location = new System.Drawing.Point(62, 28);
            this.lbl_MachineCount.Name = "lbl_MachineCount";
            this.lbl_MachineCount.Size = new System.Drawing.Size(13, 13);
            this.lbl_MachineCount.TabIndex = 1;
            this.lbl_MachineCount.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_MachineRecipe);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_MachineCount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_MachineName);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 72);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lbl_MachineRecipe
            // 
            this.lbl_MachineRecipe.AutoSize = true;
            this.lbl_MachineRecipe.Location = new System.Drawing.Point(62, 48);
            this.lbl_MachineRecipe.Name = "lbl_MachineRecipe";
            this.lbl_MachineRecipe.Size = new System.Drawing.Size(13, 13);
            this.lbl_MachineRecipe.TabIndex = 2;
            this.lbl_MachineRecipe.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Work On :";
            // 
            // UI_MyMachines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UI_MyMachines";
            this.Size = new System.Drawing.Size(191, 78);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbl_MachineName;
        public System.Windows.Forms.Label lbl_MachineCount;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lbl_MachineRecipe;
        public System.Windows.Forms.Label label4;
    }
}
