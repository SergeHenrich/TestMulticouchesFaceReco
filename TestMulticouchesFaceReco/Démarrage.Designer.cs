namespace TestMulticouchesFaceReco
{
    partial class Démarrage
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
            this.btnMR = new System.Windows.Forms.Button();
            this.btnME = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMR
            // 
            this.btnMR.BackColor = System.Drawing.SystemColors.Control;
            this.btnMR.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnMR.Location = new System.Drawing.Point(52, 243);
            this.btnMR.Name = "btnMR";
            this.btnMR.Size = new System.Drawing.Size(294, 120);
            this.btnMR.TabIndex = 3;
            this.btnMR.Text = "Module de Reconnaissance";
            this.btnMR.UseVisualStyleBackColor = false;
            this.btnMR.Click += new System.EventHandler(this.btnMR_Click);
            // 
            // btnME
            // 
            this.btnME.BackColor = System.Drawing.SystemColors.Control;
            this.btnME.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnME.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnME.Location = new System.Drawing.Point(52, 38);
            this.btnME.Name = "btnME";
            this.btnME.Size = new System.Drawing.Size(294, 120);
            this.btnME.TabIndex = 4;
            this.btnME.Text = "Module \r\nD\'entrainement";
            this.btnME.UseVisualStyleBackColor = false;
            this.btnME.Click += new System.EventHandler(this.btnME_Click);
            // 
            // Démarrage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(399, 400);
            this.Controls.Add(this.btnMR);
            this.Controls.Add(this.btnME);
            this.Name = "Démarrage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Démarrage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMR;
        private System.Windows.Forms.Button btnME;
    }
}