namespace TestClient_PLF1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCallSce_AddNP = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnAddNpBiztalk = new System.Windows.Forms.Button();
            this.btnDecBiztalk = new System.Windows.Forms.Button();
            this.btnSpecBiztalk = new System.Windows.Forms.Button();
            this.btnCallSce_Modif = new System.Windows.Forms.Button();
            this.btnCallSce_Ann = new System.Windows.Forms.Button();
            this.btnCallSce_Spec = new System.Windows.Forms.Button();
            this.btnCallSce_Dec = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnResident = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCallSce_AddNP
            // 
            this.btnCallSce_AddNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallSce_AddNP.Location = new System.Drawing.Point(20, 28);
            this.btnCallSce_AddNP.Name = "btnCallSce_AddNP";
            this.btnCallSce_AddNP.Size = new System.Drawing.Size(212, 34);
            this.btnCallSce_AddNP.TabIndex = 0;
            this.btnCallSce_AddNP.Text = "Ajout Non Participation";
            this.btnCallSce_AddNP.UseVisualStyleBackColor = true;
            this.btnCallSce_AddNP.Click += new System.EventHandler(this.btnCallSce_AddNP_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnResident);
            this.groupBox1.Controls.Add(this.BtnAddNpBiztalk);
            this.groupBox1.Controls.Add(this.btnDecBiztalk);
            this.groupBox1.Controls.Add(this.btnSpecBiztalk);
            this.groupBox1.Controls.Add(this.btnCallSce_Modif);
            this.groupBox1.Controls.Add(this.btnCallSce_Ann);
            this.groupBox1.Controls.Add(this.btnCallSce_Spec);
            this.groupBox1.Controls.Add(this.btnCallSce_Dec);
            this.groupBox1.Controls.Add(this.txtMsg);
            this.groupBox1.Controls.Add(this.btnCallSce_AddNP);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 593);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PLF1";
            // 
            // BtnAddNpBiztalk
            // 
            this.BtnAddNpBiztalk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddNpBiztalk.Location = new System.Drawing.Point(20, 149);
            this.BtnAddNpBiztalk.Name = "BtnAddNpBiztalk";
            this.BtnAddNpBiztalk.Size = new System.Drawing.Size(212, 34);
            this.BtnAddNpBiztalk.TabIndex = 8;
            this.BtnAddNpBiztalk.Text = "Ajout NP BizTalk";
            this.BtnAddNpBiztalk.UseVisualStyleBackColor = true;
            this.BtnAddNpBiztalk.Click += new System.EventHandler(this.BtnAddNpBiztalk_Click);
            // 
            // btnDecBiztalk
            // 
            this.btnDecBiztalk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecBiztalk.Location = new System.Drawing.Point(260, 149);
            this.btnDecBiztalk.Name = "btnDecBiztalk";
            this.btnDecBiztalk.Size = new System.Drawing.Size(212, 34);
            this.btnDecBiztalk.TabIndex = 7;
            this.btnDecBiztalk.Text = "Deces BizTalk";
            this.btnDecBiztalk.UseVisualStyleBackColor = true;
            this.btnDecBiztalk.Click += new System.EventHandler(this.btnDecBiztalk_Click);
            // 
            // btnSpecBiztalk
            // 
            this.btnSpecBiztalk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpecBiztalk.Location = new System.Drawing.Point(491, 89);
            this.btnSpecBiztalk.Name = "btnSpecBiztalk";
            this.btnSpecBiztalk.Size = new System.Drawing.Size(255, 34);
            this.btnSpecBiztalk.TabIndex = 6;
            this.btnSpecBiztalk.Text = "Specialite BizTalk";
            this.btnSpecBiztalk.UseVisualStyleBackColor = true;
            this.btnSpecBiztalk.Click += new System.EventHandler(this.btnSpecBiztalk_Click);
            // 
            // btnCallSce_Modif
            // 
            this.btnCallSce_Modif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallSce_Modif.Location = new System.Drawing.Point(260, 89);
            this.btnCallSce_Modif.Name = "btnCallSce_Modif";
            this.btnCallSce_Modif.Size = new System.Drawing.Size(212, 34);
            this.btnCallSce_Modif.TabIndex = 5;
            this.btnCallSce_Modif.Text = "Modifier  Non Participation";
            this.btnCallSce_Modif.UseVisualStyleBackColor = true;
            this.btnCallSce_Modif.Click += new System.EventHandler(this.btnCallSce_Modif_Click);
            // 
            // btnCallSce_Ann
            // 
            this.btnCallSce_Ann.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallSce_Ann.Location = new System.Drawing.Point(20, 89);
            this.btnCallSce_Ann.Name = "btnCallSce_Ann";
            this.btnCallSce_Ann.Size = new System.Drawing.Size(212, 34);
            this.btnCallSce_Ann.TabIndex = 4;
            this.btnCallSce_Ann.Text = "Annuler Non Participation";
            this.btnCallSce_Ann.UseVisualStyleBackColor = true;
            this.btnCallSce_Ann.Click += new System.EventHandler(this.btnCallSce_Ann_Click);
            // 
            // btnCallSce_Spec
            // 
            this.btnCallSce_Spec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallSce_Spec.Location = new System.Drawing.Point(491, 28);
            this.btnCallSce_Spec.Name = "btnCallSce_Spec";
            this.btnCallSce_Spec.Size = new System.Drawing.Size(255, 34);
            this.btnCallSce_Spec.TabIndex = 3;
            this.btnCallSce_Spec.Text = "Specialite Non Participation";
            this.btnCallSce_Spec.UseVisualStyleBackColor = true;
            this.btnCallSce_Spec.Click += new System.EventHandler(this.btnCallSce_Spec_Click);
            // 
            // btnCallSce_Dec
            // 
            this.btnCallSce_Dec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallSce_Dec.Location = new System.Drawing.Point(260, 28);
            this.btnCallSce_Dec.Name = "btnCallSce_Dec";
            this.btnCallSce_Dec.Size = new System.Drawing.Size(212, 34);
            this.btnCallSce_Dec.TabIndex = 2;
            this.btnCallSce_Dec.Text = "Deces Non Participation";
            this.btnCallSce_Dec.UseVisualStyleBackColor = true;
            this.btnCallSce_Dec.Click += new System.EventHandler(this.btnCallSce_Dec_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.ForeColor = System.Drawing.Color.IndianRed;
            this.txtMsg.Location = new System.Drawing.Point(41, 243);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(693, 262);
            this.txtMsg.TabIndex = 1;
            // 
            // btnResident
            // 
            this.btnResident.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResident.Location = new System.Drawing.Point(491, 149);
            this.btnResident.Name = "btnResident";
            this.btnResident.Size = new System.Drawing.Size(212, 34);
            this.btnResident.TabIndex = 9;
            this.btnResident.Text = "Resident";
            this.btnResident.UseVisualStyleBackColor = true;
            this.btnResident.Click += new System.EventHandler(this.btnResident_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 671);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCallSce_AddNP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnCallSce_Dec;
        private System.Windows.Forms.Button btnCallSce_Spec;
        private System.Windows.Forms.Button btnCallSce_Ann;
        private System.Windows.Forms.Button btnCallSce_Modif;
        private System.Windows.Forms.Button btnSpecBiztalk;
        private System.Windows.Forms.Button btnDecBiztalk;
        private System.Windows.Forms.Button BtnAddNpBiztalk;
        private System.Windows.Forms.Button btnResident;
    }
}

