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
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnCallSce_Dec = new System.Windows.Forms.Button();
            this.btnCallSce_Spec = new System.Windows.Forms.Button();
            this.btnCallSce_Ann = new System.Windows.Forms.Button();
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
            // txtMsg
            // 
            this.txtMsg.ForeColor = System.Drawing.Color.IndianRed;
            this.txtMsg.Location = new System.Drawing.Point(41, 172);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(693, 333);
            this.txtMsg.TabIndex = 1;
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
    }
}

