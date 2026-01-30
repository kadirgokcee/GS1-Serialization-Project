namespace GS1.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtProductId = new TextBox();
            label2 = new Label();
            txtQuantity = new TextBox();
            btnCreate = new Button();
            lblStatus = new Label();
            label3 = new Label();
            dtpExpireDate = new DateTimePicker();
            label4 = new Label();
            txtLotNo = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(135, 98);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Ürün ID:";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(238, 95);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(181, 23);
            txtProductId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(150, 147);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 2;
            label2.Text = "Adet:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(238, 144);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(181, 23);
            txtQuantity.TabIndex = 3;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(560, 293);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(119, 56);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Üretimi Başlat";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(74, 334);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(114, 15);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Durum: Bekleniyor...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 252);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 6;
            label3.Text = "Son Kullanma Tarihi:";
            // 
            // dtpExpireDate
            // 
            dtpExpireDate.Location = new Point(238, 246);
            dtpExpireDate.Name = "dtpExpireDate";
            dtpExpireDate.Size = new Size(181, 23);
            dtpExpireDate.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(139, 196);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 8;
            label4.Text = "Lot No:";
            // 
            // txtLotNo
            // 
            txtLotNo.Location = new Point(238, 193);
            txtLotNo.Name = "txtLotNo";
            txtLotNo.Size = new Size(181, 23);
            txtLotNo.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 450);
            Controls.Add(txtLotNo);
            Controls.Add(label4);
            Controls.Add(dtpExpireDate);
            Controls.Add(label3);
            Controls.Add(lblStatus);
            Controls.Add(btnCreate);
            Controls.Add(txtQuantity);
            Controls.Add(label2);
            Controls.Add(txtProductId);
            Controls.Add(label1);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtProductId;
        private Label label2;
        private TextBox txtQuantity;
        private Button btnCreate;
        private Label lblStatus;
        private Label label3;
        private DateTimePicker dtpExpireDate;
        private Label label4;
        private TextBox txtLotNo;
    }
}
