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
            this.exp_label = new System.Windows.Forms.Label();
            this.V_label = new System.Windows.Forms.Label();
            this.V_txt = new System.Windows.Forms.TextBox();
            this.Sig_label = new System.Windows.Forms.Label();
            this.Sig_txt = new System.Windows.Forms.TextBox();
            this.P_txt = new System.Windows.Forms.TextBox();
            this.P_label = new System.Windows.Forms.Label();
            this.S_label = new System.Windows.Forms.Label();
            this.Convert_btn = new System.Windows.Forms.Button();
            this.P_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.S_txt = new System.Windows.Forms.TextBox();
            this.Result_label = new System.Windows.Forms.Label();
            this.Result_Sig_txt = new System.Windows.Forms.TextBox();
            this.Result_Sig_label = new System.Windows.Forms.Label();
            this.Result_V_txt = new System.Windows.Forms.TextBox();
            this.Result_V_label = new System.Windows.Forms.Label();
            this.Result_S_txt = new System.Windows.Forms.TextBox();
            this.Result_S_label = new System.Windows.Forms.Label();
            this.Result_P_txt = new System.Windows.Forms.TextBox();
            this.Result_P_label = new System.Windows.Forms.Label();
            this.Transformation_Log = new System.Windows.Forms.TextBox();
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.Combo_label = new System.Windows.Forms.Label();
            this.CleanInput_btn = new System.Windows.Forms.Button();
            this.StepByStep_checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // exp_label
            // 
            this.exp_label.Location = new System.Drawing.Point(13, 13);
            this.exp_label.Name = "exp_label";
            this.exp_label.Size = new System.Drawing.Size(801, 115);
            this.exp_label.TabIndex = 0;
            this.exp_label.Text = resources.GetString("exp_label.Text");
            // 
            // V_label
            // 
            this.V_label.AutoSize = true;
            this.V_label.Location = new System.Drawing.Point(22, 131);
            this.V_label.Name = "V_label";
            this.V_label.Size = new System.Drawing.Size(457, 25);
            this.V_label.TabIndex = 1;
            this.V_label.Text = "V = {                                                                            " +
    "   }";
            // 
            // V_txt
            // 
            this.V_txt.Location = new System.Drawing.Point(81, 131);
            this.V_txt.Name = "V_txt";
            this.V_txt.Size = new System.Drawing.Size(374, 29);
            this.V_txt.TabIndex = 2;
            // 
            // Sig_label
            // 
            this.Sig_label.AutoSize = true;
            this.Sig_label.Location = new System.Drawing.Point(19, 170);
            this.Sig_label.Name = "Sig_label";
            this.Sig_label.Size = new System.Drawing.Size(460, 25);
            this.Sig_label.TabIndex = 3;
            this.Sig_label.Text = "Σ =  {                                                                           " +
    "    }";
            // 
            // Sig_txt
            // 
            this.Sig_txt.Location = new System.Drawing.Point(81, 170);
            this.Sig_txt.Name = "Sig_txt";
            this.Sig_txt.Size = new System.Drawing.Size(374, 29);
            this.Sig_txt.TabIndex = 4;
            // 
            // P_txt
            // 
            this.P_txt.Location = new System.Drawing.Point(81, 215);
            this.P_txt.Multiline = true;
            this.P_txt.Name = "P_txt";
            this.P_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.P_txt.Size = new System.Drawing.Size(374, 160);
            this.P_txt.TabIndex = 6;
            this.P_txt.Enter += new System.EventHandler(this.P_txt_Enter);
            this.P_txt.Leave += new System.EventHandler(this.P_txt_Leave);
            // 
            // P_label
            // 
            this.P_label.AutoSize = true;
            this.P_label.Location = new System.Drawing.Point(19, 215);
            this.P_label.Name = "P_label";
            this.P_label.Size = new System.Drawing.Size(461, 25);
            this.P_label.TabIndex = 5;
            this.P_label.Text = "P =  {                                                                           " +
    "    }";
            // 
            // S_label
            // 
            this.S_label.AutoSize = true;
            this.S_label.Location = new System.Drawing.Point(19, 395);
            this.S_label.Name = "S_label";
            this.S_label.Size = new System.Drawing.Size(122, 25);
            this.S_label.TabIndex = 7;
            this.S_label.Text = "S = {            }";
            // 
            // Convert_btn
            // 
            this.Convert_btn.Location = new System.Drawing.Point(23, 504);
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
            // Result_label
            // 
            this.Result_label.AutoSize = true;
            this.Result_label.Location = new System.Drawing.Point(18, 602);
            this.Result_label.Name = "Result_label";
            this.Result_label.Size = new System.Drawing.Size(614, 25);
            this.Result_label.TabIndex = 12;
            this.Result_label.Text = "The given grammar was converted into the following grammar in GNF:";
            // 
            // Result_Sig_txt
            // 
            this.Result_Sig_txt.Location = new System.Drawing.Point(81, 844);
            this.Result_Sig_txt.Name = "Result_Sig_txt";
            this.Result_Sig_txt.ReadOnly = true;
            this.Result_Sig_txt.Size = new System.Drawing.Size(374, 29);
            this.Result_Sig_txt.TabIndex = 16;
            // 
            // Result_Sig_label
            // 
            this.Result_Sig_label.AutoSize = true;
            this.Result_Sig_label.Location = new System.Drawing.Point(19, 844);
            this.Result_Sig_label.Name = "Result_Sig_label";
            this.Result_Sig_label.Size = new System.Drawing.Size(460, 25);
            this.Result_Sig_label.TabIndex = 15;
            this.Result_Sig_label.Text = "Σ = {                                                                            " +
    "    }";
            // 
            // Result_V_txt
            // 
            this.Result_V_txt.Location = new System.Drawing.Point(81, 668);
            this.Result_V_txt.Multiline = true;
            this.Result_V_txt.Name = "Result_V_txt";
            this.Result_V_txt.ReadOnly = true;
            this.Result_V_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Result_V_txt.Size = new System.Drawing.Size(374, 160);
            this.Result_V_txt.TabIndex = 14;
            // 
            // Result_V_label
            // 
            this.Result_V_label.AutoSize = true;
            this.Result_V_label.Location = new System.Drawing.Point(19, 668);
            this.Result_V_label.Name = "Result_V_label";
            this.Result_V_label.Size = new System.Drawing.Size(462, 25);
            this.Result_V_label.TabIndex = 13;
            this.Result_V_label.Text = "V = {                                                                            " +
    "    }";
            // 
            // Result_S_txt
            // 
            this.Result_S_txt.Location = new System.Drawing.Point(81, 1218);
            this.Result_S_txt.Name = "Result_S_txt";
            this.Result_S_txt.ReadOnly = true;
            this.Result_S_txt.Size = new System.Drawing.Size(36, 29);
            this.Result_S_txt.TabIndex = 18;
            // 
            // Result_S_label
            // 
            this.Result_S_label.AutoSize = true;
            this.Result_S_label.Location = new System.Drawing.Point(19, 1218);
            this.Result_S_label.Name = "Result_S_label";
            this.Result_S_label.Size = new System.Drawing.Size(122, 25);
            this.Result_S_label.TabIndex = 17;
            this.Result_S_label.Text = "S = {            }";
            // 
            // Result_P_txt
            // 
            this.Result_P_txt.Location = new System.Drawing.Point(81, 890);
            this.Result_P_txt.Multiline = true;
            this.Result_P_txt.Name = "Result_P_txt";
            this.Result_P_txt.ReadOnly = true;
            this.Result_P_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Result_P_txt.Size = new System.Drawing.Size(374, 297);
            this.Result_P_txt.TabIndex = 20;
            // 
            // Result_P_label
            // 
            this.Result_P_label.AutoSize = true;
            this.Result_P_label.Location = new System.Drawing.Point(19, 890);
            this.Result_P_label.Name = "Result_P_label";
            this.Result_P_label.Size = new System.Drawing.Size(461, 25);
            this.Result_P_label.TabIndex = 19;
            this.Result_P_label.Text = "P = {                                                                            " +
    "    }";
            // 
            // Transformation_Log
            // 
            this.Transformation_Log.Location = new System.Drawing.Point(951, 13);
            this.Transformation_Log.Multiline = true;
            this.Transformation_Log.Name = "Transformation_Log";
            this.Transformation_Log.ReadOnly = true;
            this.Transformation_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Transformation_Log.Size = new System.Drawing.Size(1142, 1187);
            this.Transformation_Log.TabIndex = 21;
            // 
            // ComboBox
            // 
            this.ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBox.FormattingEnabled = true;
            this.ComboBox.Location = new System.Drawing.Point(569, 161);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(265, 32);
            this.ComboBox.TabIndex = 22;
            this.ComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // Combo_label
            // 
            this.Combo_label.AutoSize = true;
            this.Combo_label.Location = new System.Drawing.Point(542, 128);
            this.Combo_label.Name = "Combo_label";
            this.Combo_label.Size = new System.Drawing.Size(305, 25);
            this.Combo_label.TabIndex = 23;
            this.Combo_label.Text = "Select an example grammar here:";
            // 
            // CleanInput_btn
            // 
            this.CleanInput_btn.Location = new System.Drawing.Point(290, 504);
            this.CleanInput_btn.Name = "CleanInput_btn";
            this.CleanInput_btn.Size = new System.Drawing.Size(165, 63);
            this.CleanInput_btn.TabIndex = 24;
            this.CleanInput_btn.Text = "CleanInput";
            this.CleanInput_btn.UseVisualStyleBackColor = true;
            this.CleanInput_btn.Click += new System.EventHandler(this.CleanInput_btn_Click);
            // 
            // StepByStep_checkBox
            // 
            this.StepByStep_checkBox.AutoSize = true;
            this.StepByStep_checkBox.Location = new System.Drawing.Point(27, 467);
            this.StepByStep_checkBox.Name = "StepByStep_checkBox";
            this.StepByStep_checkBox.Size = new System.Drawing.Size(240, 29);
            this.StepByStep_checkBox.TabIndex = 26;
            this.StepByStep_checkBox.Text = "Step by Step execution";
            this.StepByStep_checkBox.UseVisualStyleBackColor = true;
            // 
            // GNFConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2208, 1269);
            this.Controls.Add(this.StepByStep_checkBox);
            this.Controls.Add(this.CleanInput_btn);
            this.Controls.Add(this.Combo_label);
            this.Controls.Add(this.ComboBox);
            this.Controls.Add(this.Transformation_Log);
            this.Controls.Add(this.Result_P_txt);
            this.Controls.Add(this.Result_P_label);
            this.Controls.Add(this.Result_S_txt);
            this.Controls.Add(this.Result_S_label);
            this.Controls.Add(this.Result_Sig_txt);
            this.Controls.Add(this.Result_Sig_label);
            this.Controls.Add(this.Result_V_txt);
            this.Controls.Add(this.Result_V_label);
            this.Controls.Add(this.Result_label);
            this.Controls.Add(this.S_txt);
            this.Controls.Add(this.Convert_btn);
            this.Controls.Add(this.S_label);
            this.Controls.Add(this.P_txt);
            this.Controls.Add(this.P_label);
            this.Controls.Add(this.Sig_txt);
            this.Controls.Add(this.Sig_label);
            this.Controls.Add(this.V_txt);
            this.Controls.Add(this.V_label);
            this.Controls.Add(this.exp_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GNFConverter";
            this.Text = "GNFConverter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label exp_label;
        private System.Windows.Forms.Label V_label;
        private System.Windows.Forms.TextBox V_txt;
        private System.Windows.Forms.Label Sig_label;
        private System.Windows.Forms.TextBox Sig_txt;
        private System.Windows.Forms.TextBox P_txt;
        private System.Windows.Forms.Label P_label;
        private System.Windows.Forms.Label S_label;
        private System.Windows.Forms.Button Convert_btn;
        private System.Windows.Forms.ToolTip P_tooltip;
        private System.Windows.Forms.TextBox S_txt;
        private System.Windows.Forms.Label Result_label;
        private System.Windows.Forms.TextBox Result_Sig_txt;
        private System.Windows.Forms.Label Result_Sig_label;
        private System.Windows.Forms.TextBox Result_V_txt;
        private System.Windows.Forms.Label Result_V_label;
        private System.Windows.Forms.TextBox Result_S_txt;
        private System.Windows.Forms.Label Result_S_label;
        private System.Windows.Forms.TextBox Result_P_txt;
        private System.Windows.Forms.Label Result_P_label;
        public System.Windows.Forms.TextBox Transformation_Log;
        private System.Windows.Forms.ComboBox ComboBox;
        private System.Windows.Forms.Label Combo_label;
        public System.Windows.Forms.Button CleanInput_btn;
        private System.Windows.Forms.CheckBox StepByStep_checkBox;
    }
}

