namespace GreibachNormalFormConverter
{
    partial class StepByStepForm
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
            this.Heading_lablel = new System.Windows.Forms.Label();
            this.Transformation_Log = new System.Windows.Forms.TextBox();
            this.StepByStep_groupBox = new System.Windows.Forms.GroupBox();
            this.Substitute_btn = new System.Windows.Forms.Button();
            this.Clean_btn = new System.Windows.Forms.Button();
            this.Creation_btn = new System.Windows.Forms.Button();
            this.Validation_btn = new System.Windows.Forms.Button();
            this.Finish_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.Help_btn = new System.Windows.Forms.Button();
            this.StepByStep_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Heading_lablel
            // 
            this.Heading_lablel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Heading_lablel.Location = new System.Drawing.Point(12, 9);
            this.Heading_lablel.Name = "Heading_lablel";
            this.Heading_lablel.Size = new System.Drawing.Size(607, 63);
            this.Heading_lablel.TabIndex = 0;
            this.Heading_lablel.Text = "Step by step execution";
            // 
            // Transformation_Log
            // 
            this.Transformation_Log.Location = new System.Drawing.Point(654, 22);
            this.Transformation_Log.Multiline = true;
            this.Transformation_Log.Name = "Transformation_Log";
            this.Transformation_Log.ReadOnly = true;
            this.Transformation_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Transformation_Log.Size = new System.Drawing.Size(854, 765);
            this.Transformation_Log.TabIndex = 22;
            this.Transformation_Log.Text = "Transformation_Log: \r\nYou can start the step by step execution by clicking on the" +
    " buttons on the left.\r\n";
            // 
            // StepByStep_groupBox
            // 
            this.StepByStep_groupBox.Controls.Add(this.Substitute_btn);
            this.StepByStep_groupBox.Controls.Add(this.Clean_btn);
            this.StepByStep_groupBox.Controls.Add(this.Creation_btn);
            this.StepByStep_groupBox.Controls.Add(this.Validation_btn);
            this.StepByStep_groupBox.Location = new System.Drawing.Point(19, 132);
            this.StepByStep_groupBox.Name = "StepByStep_groupBox";
            this.StepByStep_groupBox.Size = new System.Drawing.Size(285, 371);
            this.StepByStep_groupBox.TabIndex = 23;
            this.StepByStep_groupBox.TabStop = false;
            this.StepByStep_groupBox.Text = "Steps";
            // 
            // Substitute_btn
            // 
            this.Substitute_btn.Location = new System.Drawing.Point(7, 287);
            this.Substitute_btn.Name = "Substitute_btn";
            this.Substitute_btn.Size = new System.Drawing.Size(271, 77);
            this.Substitute_btn.TabIndex = 3;
            this.Substitute_btn.Text = "Substitute";
            this.Substitute_btn.UseVisualStyleBackColor = true;
            this.Substitute_btn.Click += new System.EventHandler(this.Substitute_btn_Click);
            // 
            // Clean_btn
            // 
            this.Clean_btn.Location = new System.Drawing.Point(6, 204);
            this.Clean_btn.Name = "Clean_btn";
            this.Clean_btn.Size = new System.Drawing.Size(271, 77);
            this.Clean_btn.TabIndex = 2;
            this.Clean_btn.Text = "clean";
            this.Clean_btn.UseVisualStyleBackColor = true;
            this.Clean_btn.Click += new System.EventHandler(this.Clean_btn_Click);
            // 
            // Creation_btn
            // 
            this.Creation_btn.Location = new System.Drawing.Point(7, 121);
            this.Creation_btn.Name = "Creation_btn";
            this.Creation_btn.Size = new System.Drawing.Size(271, 77);
            this.Creation_btn.TabIndex = 1;
            this.Creation_btn.Text = "Create";
            this.Creation_btn.UseVisualStyleBackColor = true;
            this.Creation_btn.Click += new System.EventHandler(this.Creation_btn_Click);
            // 
            // Validation_btn
            // 
            this.Validation_btn.Location = new System.Drawing.Point(7, 38);
            this.Validation_btn.Name = "Validation_btn";
            this.Validation_btn.Size = new System.Drawing.Size(271, 77);
            this.Validation_btn.TabIndex = 0;
            this.Validation_btn.Text = "Validate";
            this.Validation_btn.UseVisualStyleBackColor = true;
            this.Validation_btn.Click += new System.EventHandler(this.Validation_btn_Click);
            // 
            // Finish_btn
            // 
            this.Finish_btn.Location = new System.Drawing.Point(26, 710);
            this.Finish_btn.Name = "Finish_btn";
            this.Finish_btn.Size = new System.Drawing.Size(271, 77);
            this.Finish_btn.TabIndex = 24;
            this.Finish_btn.Text = "Finish";
            this.Finish_btn.UseVisualStyleBackColor = true;
            this.Finish_btn.Click += new System.EventHandler(this.Finish_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(359, 710);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(271, 77);
            this.Cancel_btn.TabIndex = 25;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Help_btn
            // 
            this.Help_btn.Location = new System.Drawing.Point(25, 545);
            this.Help_btn.Name = "Help_btn";
            this.Help_btn.Size = new System.Drawing.Size(271, 77);
            this.Help_btn.TabIndex = 26;
            this.Help_btn.Text = "Detailed information";
            this.Help_btn.UseVisualStyleBackColor = true;
            this.Help_btn.Click += new System.EventHandler(this.Help_btn_Click);
            // 
            // StepByStepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1520, 864);
            this.Controls.Add(this.Help_btn);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Finish_btn);
            this.Controls.Add(this.StepByStep_groupBox);
            this.Controls.Add(this.Transformation_Log);
            this.Controls.Add(this.Heading_lablel);
            this.Name = "StepByStepForm";
            this.Text = "StepByStepForm";
            this.StepByStep_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Heading_lablel;
        private System.Windows.Forms.TextBox Transformation_Log;
        private System.Windows.Forms.GroupBox StepByStep_groupBox;
        private System.Windows.Forms.Button Substitute_btn;
        private System.Windows.Forms.Button Clean_btn;
        private System.Windows.Forms.Button Creation_btn;
        private System.Windows.Forms.Button Validation_btn;
        private System.Windows.Forms.Button Finish_btn;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Button Help_btn;
    }
}