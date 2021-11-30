
namespace LogicCalculator
{
    partial class Form1
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
            this.TxBInput = new System.Windows.Forms.TextBox();
            this.BtnGetRes = new System.Windows.Forms.Button();
            this.TxBViewRes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxBInput
            // 
            this.TxBInput.Location = new System.Drawing.Point(7, 31);
            this.TxBInput.Name = "TxBInput";
            this.TxBInput.Size = new System.Drawing.Size(325, 20);
            this.TxBInput.TabIndex = 0;
            // 
            // BtnGetRes
            // 
            this.BtnGetRes.Location = new System.Drawing.Point(7, 68);
            this.BtnGetRes.Name = "BtnGetRes";
            this.BtnGetRes.Size = new System.Drawing.Size(75, 23);
            this.BtnGetRes.TabIndex = 1;
            this.BtnGetRes.Text = "Решить";
            this.BtnGetRes.UseVisualStyleBackColor = true;
            this.BtnGetRes.Click += new System.EventHandler(this.BtnGetRes_Click);
            // 
            // TxBViewRes
            // 
            this.TxBViewRes.Location = new System.Drawing.Point(55, 107);
            this.TxBViewRes.Name = "TxBViewRes";
            this.TxBViewRes.Size = new System.Drawing.Size(100, 20);
            this.TxBViewRes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ответ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 78);
            this.label2.TabIndex = 4;
            this.label2.Text = "Допустимые лог. опер.:\r\n!-отрицание\r\n1-правда\r\n0-ложь\r\n*-лог. И\r\n+-лог ИЛИ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 176);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxBViewRes);
            this.Controls.Add(this.BtnGetRes);
            this.Controls.Add(this.TxBInput);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Логический калькулятор";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxBInput;
        private System.Windows.Forms.Button BtnGetRes;
        private System.Windows.Forms.TextBox TxBViewRes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

