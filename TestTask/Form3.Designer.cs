namespace TestTask
{
    partial class Form3
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ParentCB = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChildCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CodeTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(325, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 48);
            this.button2.TabIndex = 31;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(157, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 48);
            this.button1.TabIndex = 30;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ParentCB
            // 
            this.ParentCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ParentCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ParentCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParentCB.Location = new System.Drawing.Point(284, 124);
            this.ParentCB.Name = "ParentCB";
            this.ParentCB.Size = new System.Drawing.Size(277, 28);
            this.ParentCB.TabIndex = 29;
            this.ParentCB.Tag = "Родительский департамент";
            this.ParentCB.SelectedIndexChanged += new System.EventHandler(this.ParentCB_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(308, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(226, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Родительский департамент";
            // 
            // NameTB
            // 
            this.NameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameTB.Location = new System.Drawing.Point(56, 126);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(209, 26);
            this.NameTB.TabIndex = 27;
            this.NameTB.Tag = "Имя";
            this.NameTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(131, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Имя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(129, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 31);
            this.label1.TabIndex = 25;
            this.label1.Text = "Данные о департаменте";
            // 
            // ChildCB
            // 
            this.ChildCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ChildCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ChildCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChildCB.Location = new System.Drawing.Point(284, 191);
            this.ChildCB.Name = "ChildCB";
            this.ChildCB.Size = new System.Drawing.Size(277, 28);
            this.ChildCB.TabIndex = 33;
            this.ChildCB.Tag = "Дочерний департамент";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(324, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Дочерний департамент";
            // 
            // CodeTB
            // 
            this.CodeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeTB.Location = new System.Drawing.Point(56, 193);
            this.CodeTB.Name = "CodeTB";
            this.CodeTB.Size = new System.Drawing.Size(209, 26);
            this.CodeTB.TabIndex = 35;
            this.CodeTB.Tag = "Код департамента";
            this.CodeTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(82, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Код департамента";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 406);
            this.Controls.Add(this.CodeTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ChildCB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ParentCB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ParentCB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ChildCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CodeTB;
        private System.Windows.Forms.Label label4;
    }
}