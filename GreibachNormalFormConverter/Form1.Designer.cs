namespace GreibachNormalFormConverter
{
    partial class GNFConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GNFConverter));
            this.exp_lable = new System.Windows.Forms.Label();
            this.V_lable = new System.Windows.Forms.Label();
            this.V_txt = new System.Windows.Forms.TextBox();
            this.Sig_lable = new System.Windows.Forms.Label();
            this.Sig_txt = new System.Windows.Forms.TextBox();
            this.P_txt = new System.Windows.Forms.TextBox();
            this.P_lable = new System.Windows.Forms.Label();
            this.S_lable = new System.Windows.Forms.Label();
            this.Convert_btn = new System.Windows.Forms.Button();
            this.P_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.S_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // exp_lable
            // 
            this.exp_lable.Location = new System.Drawing.Point(13, 13);
            this.exp_lable.Name = "exp_lable";
            this.exp_lable.Size = new System.Drawing.Size(1509, 66);
            this.exp_lable.TabIndex = 0;
            this.exp_lable.Text = resources.GetString("exp_lable.Text");
            // 
            // V_lable
            // 
            this.V_lable.AutoSize = true;
            this.V_lable.Location = new System.Drawing.Point(13, 83);
            this.V_lable.Name = "V_lable";
            this.V_lable.Size = new System.Drawing.Size(392, 25);
            this.V_lable.TabIndex = 1;
            this.V_lable.Text = "V = {                                                                  }";
            // 
            // V_txt
            // 
            this.V_txt.Location = new System.Drawing.Point(75, 83);
            this.V_txt.Name = "V_txt";
            this.V_txt.Size = new System.Drawing.Size(300, 29);
            this.V_txt.TabIndex = 2;
            // 
            // Sig_lable
            // 
            this.Sig_lable.AutoSize = true;
            this.Sig_lable.Location = new System.Drawing.Point(13, 122);
            this.Sig_lable.Name = "Sig_lable";
            this.Sig_lable.Size = new System.Drawing.Size(390, 25);
            this.Sig_lable.TabIndex = 3;
            this.Sig_lable.Text = "Σ = {                                                                  }";
            // 
            // Sig_txt
            // 
            this.Sig_txt.Location = new System.Drawing.Point(75, 122);
            this.Sig_txt.Name = "Sig_txt";
            this.Sig_txt.Size = new System.Drawing.Size(300, 29);
            this.Sig_txt.TabIndex = 4;
            // 
            // P_txt
            // 
            this.P_txt.Location = new System.Drawing.Point(75, 167);
            this.P_txt.Multiline = true;
            this.P_txt.Name = "P_txt";
            this.P_txt.Size = new System.Drawing.Size(300, 160);
            this.P_txt.TabIndex = 6;
            // 
            // P_lable
            // 
            this.P_lable.AutoSize = true;
            this.P_lable.Location = new System.Drawing.Point(13, 167);
            this.P_lable.Name = "P_lable";
            this.P_lable.Size = new System.Drawing.Size(391, 25);
            this.P_lable.TabIndex = 5;
            this.P_lable.Text = "P = {                                                                  }";
            // 
            // S_lable
            // 
            this.S_lable.AutoSize = true;
            this.S_lable.Location = new System.Drawing.Point(13, 347);
            this.S_lable.Name = "S_lable";
            this.S_lable.Size = new System.Drawing.Size(127, 25);
            this.S_lable.TabIndex = 7;
            this.S_lable.Text = "S = {             }";
            // 
            // Convert_btn
            // 
            this.Convert_btn.Location = new System.Drawing.Point(12, 419);
            this.Convert_btn.Name = "Convert_btn";
            this.Convert_btn.Size = new System.Drawing.Size(173, 63);
            this.Convert_btn.TabIndex = 9;
            this.Convert_btn.Text = "Convert into GNF";
            this.Convert_btn.UseVisualStyleBackColor = true;
            this.Convert_btn.Click += new System.EventHandler(this.Convert_btn_Click);
            // 
            // S_txt
            // 
            this.S_txt.Location = new System.Drawing.Point(75, 347);
            this.S_txt.Name = "S_txt";
            this.S_txt.Size = new System.Drawing.Size(36, 29);
            this.S_txt.TabIndex = 10;
            // 
            // GNFConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1519, 844);
            this.Controls.Add(this.S_txt);
            this.Controls.Add(this.Convert_btn);
            this.Controls.Add(this.S_lable);
            this.Controls.Add(this.P_txt);
            this.Controls.Add(this.P_lable);
            this.Controls.Add(this.Sig_txt);
            this.Controls.Add(this.Sig_lable);
            this.Controls.Add(this.V_txt);
            this.Controls.Add(this.V_lable);
            this.Controls.Add(this.exp_lable);
            this.Name = "GNFConverter";
            this.Text = "GNFConverter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label exp_lable;
        private System.Windows.Forms.Label V_lable;
        private System.Windows.Forms.TextBox V_txt;
        private System.Windows.Forms.Label Sig_lable;
        private System.Windows.Forms.TextBox Sig_txt;
        private System.Windows.Forms.TextBox P_txt;
        private System.Windows.Forms.Label P_lable;
        private System.Windows.Forms.Label S_lable;
        private System.Windows.Forms.Button Convert_btn;
        private System.Windows.Forms.ToolTip P_tooltip;
        private System.Windows.Forms.TextBox S_txt;
    }
}

