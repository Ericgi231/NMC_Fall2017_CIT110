namespace Grant121_FinchControl
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
            this.ButtFor = new System.Windows.Forms.Button();
            this.ButtLef = new System.Windows.Forms.Button();
            this.ButtBac = new System.Windows.Forms.Button();
            this.ButtRig = new System.Windows.Forms.Button();
            this.ButtSto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConnected = new System.Windows.Forms.TextBox();
            this.ButtExi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtFor
            // 
            this.ButtFor.Location = new System.Drawing.Point(105, 168);
            this.ButtFor.Name = "ButtFor";
            this.ButtFor.Size = new System.Drawing.Size(75, 23);
            this.ButtFor.TabIndex = 0;
            this.ButtFor.Text = "Forward";
            this.ButtFor.UseVisualStyleBackColor = true;
            this.ButtFor.Click += new System.EventHandler(this.ButtFor_Click);
            // 
            // ButtLef
            // 
            this.ButtLef.Location = new System.Drawing.Point(24, 197);
            this.ButtLef.Name = "ButtLef";
            this.ButtLef.Size = new System.Drawing.Size(75, 23);
            this.ButtLef.TabIndex = 1;
            this.ButtLef.Text = "Left";
            this.ButtLef.UseVisualStyleBackColor = true;
            this.ButtLef.Click += new System.EventHandler(this.ButtLef_Click);
            // 
            // ButtBac
            // 
            this.ButtBac.Location = new System.Drawing.Point(105, 226);
            this.ButtBac.Name = "ButtBac";
            this.ButtBac.Size = new System.Drawing.Size(75, 23);
            this.ButtBac.TabIndex = 2;
            this.ButtBac.Text = "Backwards";
            this.ButtBac.UseVisualStyleBackColor = true;
            this.ButtBac.Click += new System.EventHandler(this.ButtBac_Click);
            // 
            // ButtRig
            // 
            this.ButtRig.Location = new System.Drawing.Point(186, 197);
            this.ButtRig.Name = "ButtRig";
            this.ButtRig.Size = new System.Drawing.Size(75, 23);
            this.ButtRig.TabIndex = 3;
            this.ButtRig.Text = "Right";
            this.ButtRig.UseVisualStyleBackColor = true;
            this.ButtRig.Click += new System.EventHandler(this.ButtRig_Click);
            // 
            // ButtSto
            // 
            this.ButtSto.Location = new System.Drawing.Point(105, 197);
            this.ButtSto.Name = "ButtSto";
            this.ButtSto.Size = new System.Drawing.Size(75, 23);
            this.ButtSto.TabIndex = 4;
            this.ButtSto.Text = "Stop";
            this.ButtSto.UseVisualStyleBackColor = true;
            this.ButtSto.Click += new System.EventHandler(this.ButtSto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tina Controller";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(42, 171);
            this.nudSpeed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(57, 20);
            this.nudSpeed.TabIndex = 8;
            this.nudSpeed.ValueChanged += new System.EventHandler(this.nudSpeed_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Connected";
            // 
            // txtConnected
            // 
            this.txtConnected.Enabled = false;
            this.txtConnected.Location = new System.Drawing.Point(186, 171);
            this.txtConnected.Name = "txtConnected";
            this.txtConnected.Size = new System.Drawing.Size(56, 20);
            this.txtConnected.TabIndex = 10;
            // 
            // ButtExi
            // 
            this.ButtExi.Location = new System.Drawing.Point(197, 12);
            this.ButtExi.Name = "ButtExi";
            this.ButtExi.Size = new System.Drawing.Size(75, 23);
            this.ButtExi.TabIndex = 11;
            this.ButtExi.Text = "Exit";
            this.ButtExi.UseVisualStyleBackColor = true;
            this.ButtExi.Click += new System.EventHandler(this.ButtExi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ButtExi);
            this.Controls.Add(this.txtConnected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtSto);
            this.Controls.Add(this.ButtRig);
            this.Controls.Add(this.ButtBac);
            this.Controls.Add(this.ButtLef);
            this.Controls.Add(this.ButtFor);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtFor;
        private System.Windows.Forms.Button ButtLef;
        private System.Windows.Forms.Button ButtBac;
        private System.Windows.Forms.Button ButtRig;
        private System.Windows.Forms.Button ButtSto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtConnected;
        private System.Windows.Forms.Button ButtExi;
    }
}

