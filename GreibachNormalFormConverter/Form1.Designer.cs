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
            this.Result_lable = new System.Windows.Forms.Label();
            this.Result_Sig_txt = new System.Windows.Forms.TextBox();
            this.Result_Sig_lable = new System.Windows.Forms.Label();
            this.Result_V_txt = new System.Windows.Forms.TextBox();
            this.Result_V_lable = new System.Windows.Forms.Label();
            this.Result_S_txt = new System.Windows.Forms.TextBox();
            this.Result_S_lable = new System.Windows.Forms.Label();
            this.Result_P_txt = new System.Windows.Forms.TextBox();
            this.Result_P_label = new System.Windows.Forms.Label();
            this.Transformation_Log = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // exp_lable
            // 
            this.exp_lable.Location = new System.Drawing.Point(13, 13);
            this.exp_lable.Name = "exp_lable";
            this.exp_lable.Size = new System.Drawing.Size(801, 115);
            this.exp_lable.TabIndex = 0;
            this.exp_lable.Text = resources.GetString("exp_lable.Text");
            // 
            // V_lable
            // 
            this.V_lable.AutoSize = true;
            this.V_lable.Location = new System.Drawing.Point(19, 131);
            this.V_lable.Name = "V_lable";
            this.V_lable.Size = new System.Drawing.Size(392, 25);
            this.V_lable.TabIndex = 1;
            this.V_lable.Text = "V = {                                                                  }";
            // 
            // V_txt
            // 
            this.V_txt.Location = new System.Drawing.Point(81, 131);
            this.V_txt.Name = "V_txt";
            this.V_txt.Size = new System.Drawing.Size(300, 29);
            this.V_txt.TabIndex = 2;
            // 
            // Sig_lable
            // 
            this.Sig_lable.AutoSize = true;
            this.Sig_lable.Location = new System.Drawing.Point(19, 170);
            this.Sig_lable.Name = "Sig_lable";
            this.Sig_lable.Size = new System.Drawing.Size(390, 25);
            this.Sig_lable.TabIndex = 3;
            this.Sig_lable.Text = "Σ = {                                                                  }";
            // 
            // Sig_txt
            // 
            this.Sig_txt.Location = new System.Drawing.Point(81, 170);
            this.Sig_txt.Name = "Sig_txt";
            this.Sig_txt.Size = new System.Drawing.Size(300, 29);
            this.Sig_txt.TabIndex = 4;
            // 
            // P_txt
            // 
            this.P_txt.Location = new System.Drawing.Point(81, 215);
            this.P_txt.Multiline = true;
            this.P_txt.Name = "P_txt";
            this.P_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.P_txt.Size = new System.Drawing.Size(300, 160);
            this.P_txt.TabIndex = 6;
            this.P_txt.Enter += new System.EventHandler(this.P_txt_Enter);
            this.P_txt.Leave += new System.EventHandler(this.P_txt_Leave);
            // 
            // P_lable
            // 
            this.P_lable.AutoSize = true;
            this.P_lable.Location = new System.Drawing.Point(19, 215);
            this.P_lable.Name = "P_lable";
            this.P_lable.Size = new System.Drawing.Size(391, 25);
            this.P_lable.TabIndex = 5;
            this.P_lable.Text = "P = {                                                                  }";
            // 
            // S_lable
            // 
            this.S_lable.AutoSize = true;
            this.S_lable.Location = new System.Drawing.Point(19, 395);
            this.S_lable.Name = "S_lable";
            this.S_lable.Size = new System.Drawing.Size(122, 25);
            this.S_lable.TabIndex = 7;
            this.S_lable.Text = "S = {            }";
            // 
            // Convert_btn
            // 
            this.Convert_btn.Location = new System.Drawing.Point(18, 467);
            this.Convert_btn.Name = "Convert_btn";
            this.Convert_btn.Size = new System.Drawing.Size(173, 63);
            this.Convert_btn.TabIndex = 9;
            this.Convert_btn.Text = "Convert into GNF";
            this.Convert_btn.UseVisualStyleBackColor = true;
            this.Convert_btn.Click += new System.EventHandler(this.Convert_btn_Click);
            // 
            // S_txt
            // 
            this.S_txt.Location = new System.Drawing.Point(81, 395);
            this.S_txt.Name = "S_txt";
            this.S_txt.Size = new System.Drawing.Size(36, 29);
            this.S_txt.TabIndex = 10;
            // 
            // Result_lable
            // 
            this.Result_lable.AutoSize = true;
            this.Result_lable.Location = new System.Drawing.Point(18, 602);
            this.Result_lable.Name = "Result_lable";
            this.Result_lable.Size = new System.Drawing.Size(614, 25);
            this.Result_lable.TabIndex = 12;
            this.Result_lable.Text = "The given grammar was converted into the following grammar in GNF:";
            // 
            // Result_Sig_txt
            // 
            this.Result_Sig_txt.Location = new System.Drawing.Point(81, 844);
            this.Result_Sig_txt.Name = "Result_Sig_txt";
            this.Result_Sig_txt.Size = new System.Drawing.Size(300, 29);
            this.Result_Sig_txt.TabIndex = 16;
            // 
            // Result_Sig_lable
            // 
            this.Result_Sig_lable.AutoSize = true;
            this.Result_Sig_lable.Location = new System.Drawing.Point(19, 844);
            this.Result_Sig_lable.Name = "Result_Sig_lable";
            this.Result_Sig_lable.Size = new System.Drawing.Size(390, 25);
            this.Result_Sig_lable.TabIndex = 15;
            this.Result_Sig_lable.Text = "Σ = {                                                                  }";
            // 
            // Result_V_txt
            // 
            this.Result_V_txt.Location = new System.Drawing.Point(81, 668);
            this.Result_V_txt.Multiline = true;
            this.Result_V_txt.Name = "Result_V_txt";
            this.Result_V_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Result_V_txt.Size = new System.Drawing.Size(300, 160);
            this.Result_V_txt.TabIndex = 14;
            // 
            // Result_V_lable
            // 
            this.Result_V_lable.AutoSize = true;
            this.Result_V_lable.Location = new System.Drawing.Point(19, 668);
            this.Result_V_lable.Name = "Result_V_lable";
            this.Result_V_lable.Size = new System.Drawing.Size(392, 25);
            this.Result_V_lable.TabIndex = 13;
            this.Result_V_lable.Text = "V = {                                                                  }";
            // 
            // Result_S_txt
            // 
            this.Result_S_txt.Location = new System.Drawing.Point(81, 1218);
            this.Result_S_txt.Name = "Result_S_txt";
            this.Result_S_txt.Size = new System.Drawing.Size(36, 29);
            this.Result_S_txt.TabIndex = 18;
            // 
            // Result_S_lable
            // 
            this.Result_S_lable.AutoSize = true;
            this.Result_S_lable.Location = new System.Drawing.Point(19, 1218);
            this.Result_S_lable.Name = "Result_S_lable";
            this.Result_S_lable.Size = new System.Drawing.Size(122, 25);
            this.Result_S_lable.TabIndex = 17;
            this.Result_S_lable.Text = "S = {            }";
            // 
            // Result_P_txt
            // 
            this.Result_P_txt.Location = new System.Drawing.Point(81, 890);
            this.Result_P_txt.Multiline = true;
            this.Result_P_txt.Name = "Result_P_txt";
            this.Result_P_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Result_P_txt.Size = new System.Drawing.Size(300, 297);
            this.Result_P_txt.TabIndex = 20;
            // 
            // Result_P_label
            // 
            this.Result_P_label.AutoSize = true;
            this.Result_P_label.Location = new System.Drawing.Point(19, 890);
            this.Result_P_label.Name = "Result_P_label";
            this.Result_P_label.Size = new System.Drawing.Size(391, 25);
            this.Result_P_label.TabIndex = 19;
            this.Result_P_label.Text = "P = {                                                                  }";
            // 
            // Transformation_Log
            // 
            this.Transformation_Log.Location = new System.Drawing.Point(1059, 13);
            this.Transformation_Log.Multiline = true;
            this.Transformation_Log.Name = "Transformation_Log";
            this.Transformation_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Transformation_Log.Size = new System.Drawing.Size(1034, 1187);
            this.Transformation_Log.TabIndex = 21;
            // 
            // GNFConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2170, 1351);
            this.Controls.Add(this.Transformation_Log);
            this.Controls.Add(this.Result_P_txt);
            this.Controls.Add(this.Result_P_label);
            this.Controls.Add(this.Result_S_txt);
            this.Controls.Add(this.Result_S_lable);
            this.Controls.Add(this.Result_Sig_txt);
            this.Controls.Add(this.Result_Sig_lable);
            this.Controls.Add(this.Result_V_txt);
            this.Controls.Add(this.Result_V_lable);
            this.Controls.Add(this.Result_lable);
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
        private System.Windows.Forms.Label Result_lable;
        private System.Windows.Forms.TextBox Result_Sig_txt;
        private System.Windows.Forms.Label Result_Sig_lable;
        private System.Windows.Forms.TextBox Result_V_txt;
        private System.Windows.Forms.Label Result_V_lable;
        private System.Windows.Forms.TextBox Result_S_txt;
        private System.Windows.Forms.Label Result_S_lable;
        private System.Windows.Forms.TextBox Result_P_txt;
        private System.Windows.Forms.Label Result_P_label;
        private System.Windows.Forms.TextBox Transformation_Log;
    }
}

