namespace dairy_farm
{
    partial class IntegrationModul
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
            getbutton = new Button();
            resultbutton = new Button();
            getlabel = new Label();
            resultlabel = new Label();
            SuspendLayout();
            // 
            // getbutton
            // 
            getbutton.Location = new Point(59, 52);
            getbutton.Name = "getbutton";
            getbutton.Size = new Size(163, 42);
            getbutton.TabIndex = 0;
            getbutton.Text = "Получить данные";
            getbutton.UseVisualStyleBackColor = true;
            getbutton.Click += getbutton_Click;
            // 
            // resultbutton
            // 
            resultbutton.Location = new Point(59, 137);
            resultbutton.Name = "resultbutton";
            resultbutton.Size = new Size(163, 51);
            resultbutton.TabIndex = 1;
            resultbutton.Text = "Отправить результат теста";
            resultbutton.UseVisualStyleBackColor = true;
            resultbutton.Click += resultbutton_Click;
            // 
            // getlabel
            // 
            getlabel.AutoSize = true;
            getlabel.Location = new Point(310, 66);
            getlabel.Name = "getlabel";
            getlabel.Size = new Size(34, 15);
            getlabel.TabIndex = 2;
            getlabel.Text = "ФИО";
            // 
            // resultlabel
            // 
            resultlabel.AutoSize = true;
            resultlabel.Location = new Point(310, 155);
            resultlabel.Name = "resultlabel";
            resultlabel.Size = new Size(116, 15);
            resultlabel.TabIndex = 3;
            resultlabel.Text = "Результат проверки";
            resultlabel.Click += label2_Click;
            // 
            // IntegrationModul
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 226);
            Controls.Add(resultlabel);
            Controls.Add(getlabel);
            Controls.Add(resultbutton);
            Controls.Add(getbutton);
            Name = "IntegrationModul";
            Text = "IntegrationModul";
            Load += IntegrationModul_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button getbutton;
        private Button resultbutton;
        private Label getlabel;
        private Label resultlabel;
    }
}