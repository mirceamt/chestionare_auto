namespace ChestionareAuto
{
    partial class CategorieWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategorieWindow));
            this.chooseCategory = new System.Windows.Forms.Label();
            this.startChestionarButton = new System.Windows.Forms.Button();
            this.radioA = new System.Windows.Forms.RadioButton();
            this.radioB = new System.Windows.Forms.RadioButton();
            this.radioC = new System.Windows.Forms.RadioButton();
            this.radioD = new System.Windows.Forms.RadioButton();
            this.radioE = new System.Windows.Forms.RadioButton();
            this.radioR = new System.Windows.Forms.RadioButton();
            this.radioGroup = new System.Windows.Forms.GroupBox();
            this.radioGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseCategory
            // 
            this.chooseCategory.AutoSize = true;
            this.chooseCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chooseCategory.Location = new System.Drawing.Point(85, 9);
            this.chooseCategory.Name = "chooseCategory";
            this.chooseCategory.Size = new System.Drawing.Size(199, 25);
            this.chooseCategory.TabIndex = 1;
            this.chooseCategory.Text = "Alegeţi o categorie:";
            // 
            // startChestionarButton
            // 
            this.startChestionarButton.Image = global::ChestionareAuto.Properties.Resources.startChestionarButtonImg;
            this.startChestionarButton.Location = new System.Drawing.Point(109, 343);
            this.startChestionarButton.Name = "startChestionarButton";
            this.startChestionarButton.Size = new System.Drawing.Size(149, 81);
            this.startChestionarButton.TabIndex = 3;
            this.startChestionarButton.UseVisualStyleBackColor = true;
            this.startChestionarButton.Click += new System.EventHandler(this.startChestionarButton_Click);
            // 
            // radioA
            // 
            this.radioA.AutoSize = true;
            this.radioA.Location = new System.Drawing.Point(7, 34);
            this.radioA.Name = "radioA";
            this.radioA.Size = new System.Drawing.Size(168, 29);
            this.radioA.TabIndex = 0;
            this.radioA.TabStop = true;
            this.radioA.Text = "A, A1, A2, AM";
            this.radioA.UseVisualStyleBackColor = true;
            // 
            // radioB
            // 
            this.radioB.AutoSize = true;
            this.radioB.Location = new System.Drawing.Point(7, 70);
            this.radioB.Name = "radioB";
            this.radioB.Size = new System.Drawing.Size(115, 29);
            this.radioB.TabIndex = 1;
            this.radioB.TabStop = true;
            this.radioB.Text = "B, B1, Tr";
            this.radioB.UseVisualStyleBackColor = true;
            // 
            // radioC
            // 
            this.radioC.AutoSize = true;
            this.radioC.Location = new System.Drawing.Point(7, 108);
            this.radioC.Name = "radioC";
            this.radioC.Size = new System.Drawing.Size(86, 29);
            this.radioC.TabIndex = 2;
            this.radioC.TabStop = true;
            this.radioC.Text = "C, C1";
            this.radioC.UseVisualStyleBackColor = true;
            // 
            // radioD
            // 
            this.radioD.AutoSize = true;
            this.radioD.Location = new System.Drawing.Point(7, 143);
            this.radioD.Name = "radioD";
            this.radioD.Size = new System.Drawing.Size(159, 29);
            this.radioD.TabIndex = 3;
            this.radioD.TabStop = true;
            this.radioD.Text = "D, D1, Tb, Tv";
            this.radioD.UseVisualStyleBackColor = true;
            // 
            // radioE
            // 
            this.radioE.AutoSize = true;
            this.radioE.Location = new System.Drawing.Point(7, 177);
            this.radioE.Name = "radioE";
            this.radioE.Size = new System.Drawing.Size(300, 29);
            this.radioE.TabIndex = 4;
            this.radioE.TabStop = true;
            this.radioE.Text = "BE, CE, DE, B1E, C1E, D1E";
            this.radioE.UseVisualStyleBackColor = true;
            // 
            // radioR
            // 
            this.radioR.AutoSize = true;
            this.radioR.Location = new System.Drawing.Point(6, 214);
            this.radioR.Name = "radioR";
            this.radioR.Size = new System.Drawing.Size(152, 29);
            this.radioR.TabIndex = 5;
            this.radioR.TabStop = true;
            this.radioR.Text = "Redobandire";
            this.radioR.UseVisualStyleBackColor = true;
            // 
            // radioGroup
            // 
            this.radioGroup.Controls.Add(this.radioR);
            this.radioGroup.Controls.Add(this.radioE);
            this.radioGroup.Controls.Add(this.radioD);
            this.radioGroup.Controls.Add(this.radioC);
            this.radioGroup.Controls.Add(this.radioB);
            this.radioGroup.Controls.Add(this.radioA);
            this.radioGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.radioGroup.Location = new System.Drawing.Point(37, 49);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Size = new System.Drawing.Size(317, 271);
            this.radioGroup.TabIndex = 2;
            this.radioGroup.TabStop = false;
            // 
            // CategorieWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 463);
            this.Controls.Add(this.startChestionarButton);
            this.Controls.Add(this.radioGroup);
            this.Controls.Add(this.chooseCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategorieWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alegeţi o categorie";
            this.radioGroup.ResumeLayout(false);
            this.radioGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label chooseCategory;
        private System.Windows.Forms.Button startChestionarButton;
        private System.Windows.Forms.RadioButton radioA;
        private System.Windows.Forms.RadioButton radioB;
        private System.Windows.Forms.RadioButton radioC;
        private System.Windows.Forms.RadioButton radioD;
        private System.Windows.Forms.RadioButton radioE;
        private System.Windows.Forms.RadioButton radioR;
        private System.Windows.Forms.GroupBox radioGroup;
    }
}

