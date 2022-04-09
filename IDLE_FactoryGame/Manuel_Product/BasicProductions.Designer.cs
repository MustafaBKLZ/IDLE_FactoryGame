
namespace IDLE_FactoryGame.Manuel_Product
{
    partial class BasicProductions
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
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.Location = new System.Drawing.Point(638, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(90, 413);
            this.btn_Close.TabIndex = 14;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // BasicProductions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 413);
            this.Controls.Add(this.btn_Close);
            this.Name = "BasicProductions";
            this.Text = "BasicProductions";
            this.Load += new System.EventHandler(this.BasicProductions_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
    }
}