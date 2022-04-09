
namespace IDLE_FactoryGame.Manuel_Product
{
    partial class ManualMine
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
            this.btn_Close = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.Location = new System.Drawing.Point(445, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(90, 243);
            this.btn_Close.TabIndex = 12;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(445, 243);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // ManualMine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 243);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_Close);
            this.Name = "ManualMine";
            this.Text = "ManualMine";
            this.Load += new System.EventHandler(this.ManualMine_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}