namespace TestMulticouchesFaceReco
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
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnArrêtModel = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            this.btnDF = new System.Windows.Forms.Button();
            this.btnArrêt = new System.Windows.Forms.Button();
            this.btnDemarrer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic2
            // 
            this.pic2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic2.Location = new System.Drawing.Point(708, 12);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(345, 293);
            this.pic2.TabIndex = 21;
            this.pic2.TabStop = false;
            // 
            // pic1
            // 
            this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic1.Location = new System.Drawing.Point(22, 12);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(412, 293);
            this.pic1.TabIndex = 22;
            this.pic1.TabStop = false;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(762, 360);
            this.txtNom.Multiline = true;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(252, 36);
            this.txtNom.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(785, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Entrer le nom de la personne";
            // 
            // btnArrêtModel
            // 
            this.btnArrêtModel.Location = new System.Drawing.Point(27, 176);
            this.btnArrêtModel.Name = "btnArrêtModel";
            this.btnArrêtModel.Size = new System.Drawing.Size(180, 36);
            this.btnArrêtModel.TabIndex = 14;
            this.btnArrêtModel.Text = "3.Entrainer le model";
            this.btnArrêtModel.UseVisualStyleBackColor = true;
            this.btnArrêtModel.Click += new System.EventHandler(this.btnArrêtModel_Click);
            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(54, 359);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(126, 36);
            this.btnRetour.TabIndex = 15;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // btnDF
            // 
            this.btnDF.Location = new System.Drawing.Point(27, 88);
            this.btnDF.Name = "btnDF";
            this.btnDF.Size = new System.Drawing.Size(171, 36);
            this.btnDF.TabIndex = 16;
            this.btnDF.Text = "2.Détection Faciale";
            this.btnDF.UseVisualStyleBackColor = true;
            this.btnDF.Click += new System.EventHandler(this.btnDF_Click);
            // 
            // btnArrêt
            // 
            this.btnArrêt.Location = new System.Drawing.Point(54, 268);
            this.btnArrêt.Name = "btnArrêt";
            this.btnArrêt.Size = new System.Drawing.Size(126, 36);
            this.btnArrêt.TabIndex = 17;
            this.btnArrêt.Text = "Arrêter";
            this.btnArrêt.UseVisualStyleBackColor = true;
            this.btnArrêt.Click += new System.EventHandler(this.btnArrêt_Click);
            // 
            // btnDemarrer
            // 
            this.btnDemarrer.Location = new System.Drawing.Point(54, 5);
            this.btnDemarrer.Name = "btnDemarrer";
            this.btnDemarrer.Size = new System.Drawing.Size(109, 42);
            this.btnDemarrer.TabIndex = 18;
            this.btnDemarrer.Text = "1.Démarrer";
            this.btnDemarrer.UseVisualStyleBackColor = true;
            this.btnDemarrer.Click += new System.EventHandler(this.btnDemarrer_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDF);
            this.panel1.Controls.Add(this.btnDemarrer);
            this.panel1.Controls.Add(this.btnArrêt);
            this.panel1.Controls.Add(this.btnRetour);
            this.panel1.Controls.Add(this.btnArrêtModel);
            this.panel1.Location = new System.Drawing.Point(459, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 477);
            this.panel1.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1075, 477);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entraînement";
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnArrêtModel;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.Button btnDF;
        private System.Windows.Forms.Button btnArrêt;
        private System.Windows.Forms.Button btnDemarrer;
        private System.Windows.Forms.Panel panel1;
    }
}

