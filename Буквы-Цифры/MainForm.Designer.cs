namespace Буквы_Цифры
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnLetters = new System.Windows.Forms.Button();
            this.btnNumbers0_10 = new System.Windows.Forms.Button();
            this.btnNumbers10_20 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.GorodDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLetters
            // 
            this.btnLetters.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnLetters.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnLetters.Location = new System.Drawing.Point(15, 29);
            this.btnLetters.Name = "btnLetters";
            this.btnLetters.Size = new System.Drawing.Size(121, 52);
            this.btnLetters.TabIndex = 0;
            this.btnLetters.Text = "Буквы";
            this.btnLetters.UseVisualStyleBackColor = true;
            this.btnLetters.Click += new System.EventHandler(this.BtnLetters_Click);
            // 
            // btnNumbers0_10
            // 
            this.btnNumbers0_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnNumbers0_10.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnNumbers0_10.Location = new System.Drawing.Point(142, 29);
            this.btnNumbers0_10.Name = "btnNumbers0_10";
            this.btnNumbers0_10.Size = new System.Drawing.Size(212, 52);
            this.btnNumbers0_10.TabIndex = 1;
            this.btnNumbers0_10.Text = "Цифры 0-10";
            this.btnNumbers0_10.UseVisualStyleBackColor = true;
            this.btnNumbers0_10.Click += new System.EventHandler(this.BtnNumbers0_10_Click);
            // 
            // btnNumbers10_20
            // 
            this.btnNumbers10_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnNumbers10_20.ForeColor = System.Drawing.Color.Crimson;
            this.btnNumbers10_20.Location = new System.Drawing.Point(360, 29);
            this.btnNumbers10_20.Name = "btnNumbers10_20";
            this.btnNumbers10_20.Size = new System.Drawing.Size(212, 52);
            this.btnNumbers10_20.TabIndex = 2;
            this.btnNumbers10_20.Text = "Цифры 10-20";
            this.btnNumbers10_20.UseVisualStyleBackColor = true;
            this.btnNumbers10_20.Click += new System.EventHandler(this.BtnNumbers10_20_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.linkLabel1.Location = new System.Drawing.Point(86, 92);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(51, 12);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Автор Otto";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // GorodDate
            // 
            this.GorodDate.AutoSize = true;
            this.GorodDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.GorodDate.Location = new System.Drawing.Point(6, 92);
            this.GorodDate.Name = "GorodDate";
            this.GorodDate.Size = new System.Drawing.Size(74, 12);
            this.GorodDate.TabIndex = 4;
            this.GorodDate.Text = "г. Омск 08.05.25";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(590, 108);
            this.Controls.Add(this.GorodDate);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnNumbers10_20);
            this.Controls.Add(this.btnNumbers0_10);
            this.Controls.Add(this.btnLetters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обучение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLetters;
        private System.Windows.Forms.Button btnNumbers0_10;
        private System.Windows.Forms.Button btnNumbers10_20;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label GorodDate;
    }
}

