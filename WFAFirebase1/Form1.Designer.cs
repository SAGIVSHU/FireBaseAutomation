using System;

namespace WFAFirebase1
{
    partial class Form1
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbHH = new System.Windows.Forms.ComboBox();
            this.cmbMM = new System.Windows.Forms.ComboBox();
            this.btnSetTimer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Set time: HH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "MM";
            // 
            // cmbHH
            // 
            this.cmbHH.FormattingEnabled = true;
            this.cmbHH.Location = new System.Drawing.Point(134, 69);
            this.cmbHH.Name = "cmbHH";
            this.cmbHH.Size = new System.Drawing.Size(46, 24);
            this.cmbHH.TabIndex = 16;
            // 
            // cmbMM
            // 
            this.cmbMM.FormattingEnabled = true;
            this.cmbMM.Location = new System.Drawing.Point(220, 69);
            this.cmbMM.Name = "cmbMM";
            this.cmbMM.Size = new System.Drawing.Size(46, 24);
            this.cmbMM.TabIndex = 16;
            // 
            // btnSetTimer
            // 
            this.btnSetTimer.Location = new System.Drawing.Point(272, 65);
            this.btnSetTimer.Name = "btnSetTimer";
            this.btnSetTimer.Size = new System.Drawing.Size(89, 31);
            this.btnSetTimer.TabIndex = 17;
            this.btnSetTimer.Text = "Set Timer";
            this.btnSetTimer.UseVisualStyleBackColor = true;
            this.btnSetTimer.Click += new System.EventHandler(this.btnSetTimer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 170);
            this.Controls.Add(this.btnSetTimer);
            this.Controls.Add(this.cmbMM);
            this.Controls.Add(this.cmbHH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

       
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbHH;
        private System.Windows.Forms.ComboBox cmbMM;
        private System.Windows.Forms.Button btnSetTimer;
    }
}

