namespace TestMulticouchesFaceReco
{
    partial class Reconnaitre
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
            this.btnAC = new System.Windows.Forms.Button();
            this.btnRV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNV = new System.Windows.Forms.Label();
            this.lblNbre = new System.Windows.Forms.Label();
            this.CameraBox = new Emgu.CV.UI.ImageBox();
            this.btnRE = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAC
            // 
            this.btnAC.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAC.Location = new System.Drawing.Point(22, 188);
            this.btnAC.Name = "btnAC";
            this.btnAC.Size = new System.Drawing.Size(162, 58);
            this.btnAC.TabIndex = 12;
            this.btnAC.Text = "Arreter Camera";
            this.btnAC.UseVisualStyleBackColor = false;
            this.btnAC.Click += new System.EventHandler(this.btnAC_Click);
            // 
            // btnRV
            // 
            this.btnRV.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnRV.Location = new System.Drawing.Point(22, 97);
            this.btnRV.Name = "btnRV";
            this.btnRV.Size = new System.Drawing.Size(162, 58);
            this.btnRV.TabIndex = 13;
            this.btnRV.Text = "Reconnaitre Visage";
            this.btnRV.UseVisualStyleBackColor = false;
            this.btnRV.Click += new System.EventHandler(this.btnRV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(811, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = ".";
            // 
            // lblNV
            // 
            this.lblNV.AutoSize = true;
            this.lblNV.Location = new System.Drawing.Point(972, 52);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(16, 17);
            this.lblNV.TabIndex = 10;
            this.lblNV.Text = "0";
            // 
            // lblNbre
            // 
            this.lblNbre.AutoSize = true;
            this.lblNbre.Location = new System.Drawing.Point(811, 52);
            this.lblNbre.Name = "lblNbre";
            this.lblNbre.Size = new System.Drawing.Size(109, 17);
            this.lblNbre.TabIndex = 11;
            this.lblNbre.Text = "Nombre de face";
            // 
            // CameraBox
            // 
            this.CameraBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CameraBox.Location = new System.Drawing.Point(253, 12);
            this.CameraBox.Name = "CameraBox";
            this.CameraBox.Size = new System.Drawing.Size(412, 293);
            this.CameraBox.TabIndex = 2;
            this.CameraBox.TabStop = false;
            // 
            // btnRE
            // 
            this.btnRE.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnRE.Location = new System.Drawing.Point(22, 294);
            this.btnRE.Name = "btnRE";
            this.btnRE.Size = new System.Drawing.Size(188, 72);
            this.btnRE.TabIndex = 14;
            this.btnRE.Text = "Retour en";
            this.btnRE.UseVisualStyleBackColor = false;
            this.btnRE.Click += new System.EventHandler(this.btnRE_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.btnAC);
            this.panel1.Controls.Add(this.btnRE);
            this.panel1.Controls.Add(this.btnRV);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 549);
            this.panel1.TabIndex = 15;
            // 
            // Reconnaitre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1007, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CameraBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNV);
            this.Controls.Add(this.lblNbre);
            this.Name = "Reconnaitre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reconnaitre";
            this.Load += new System.EventHandler(this.Reconnaitre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAC;
        private System.Windows.Forms.Button btnRV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNV;
        private System.Windows.Forms.Label lblNbre;
        private Emgu.CV.UI.ImageBox CameraBox;
        private System.Windows.Forms.Button btnRE;
        private System.Windows.Forms.Panel panel1;
    }
}