namespace ChestionareAuto
{
    partial class LoadingWindow
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
            this.creareChestionarLabel = new System.Windows.Forms.Label();
            this.creareChestionarProgressBar = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // creareChestionarLabel
            // 
            this.creareChestionarLabel.AutoSize = true;
            this.creareChestionarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.creareChestionarLabel.Location = new System.Drawing.Point(35, 20);
            this.creareChestionarLabel.Name = "creareChestionarLabel";
            this.creareChestionarLabel.Size = new System.Drawing.Size(218, 20);
            this.creareChestionarLabel.TabIndex = 0;
            this.creareChestionarLabel.Text = "Se creează chestionarul...";
            // 
            // creareChestionarProgressBar
            // 
            this.creareChestionarProgressBar.Location = new System.Drawing.Point(13, 61);
            this.creareChestionarProgressBar.Name = "creareChestionarProgressBar";
            this.creareChestionarProgressBar.Size = new System.Drawing.Size(259, 30);
            this.creareChestionarProgressBar.Step = 5;
            this.creareChestionarProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.creareChestionarProgressBar.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LoadingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 113);
            this.ControlBox = false;
            this.Controls.Add(this.creareChestionarProgressBar);
            this.Controls.Add(this.creareChestionarLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label creareChestionarLabel;
        private System.Windows.Forms.ProgressBar creareChestionarProgressBar;
        private System.Windows.Forms.Timer timer1;
    }
}