namespace FinancialTrackerApp
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
            txtTitle = new TextBox();
            label2 = new Label();
            txtAmount = new TextBox();
            label3 = new Label();
            txtCategory = new TextBox();
            label4 = new Label();
            btnSave = new Button();
            cmbType = new ComboBox();
            dgvTransactions = new DataGridView();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblTotalIncome = new Label();
            lblTotalExpense = new Label();
            lblBalance = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 91);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 0;
            label1.Text = "Title:";
            label1.Click += label1_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(54, 88);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(196, 23);
            txtTitle.TabIndex = 1;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 122);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Amount:";
            label2.Click += label2_Click;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(75, 119);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(175, 23);
            txtAmount.TabIndex = 3;
            txtAmount.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 158);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 4;
            label3.Text = "Category:";
            label3.Click += label3_Click;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(76, 155);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(174, 23);
            txtCategory.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 187);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 6;
            label4.Text = "Transaction Type:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(42, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(163, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save Transaction";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Income", "Expense" });
            cmbType.Location = new Point(114, 184);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(132, 23);
            cmbType.TabIndex = 9;
            // 
            // dgvTransactions
            // 
            dgvTransactions.BackgroundColor = SystemColors.Control;
            dgvTransactions.Location = new Point(286, 88);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.Size = new Size(690, 227);
            dgvTransactions.TabIndex = 0;
            dgvTransactions.CellClick += dgvTransactions_CellContentClick;
            dgvTransactions.CellContentClick += dgvTransactions_CellContentClick;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(42, 249);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(130, 249);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblTotalIncome
            // 
            lblTotalIncome.AutoSize = true;
            lblTotalIncome.BackColor = Color.White;
            lblTotalIncome.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalIncome.ForeColor = Color.Lime;
            lblTotalIncome.Location = new Point(65, 24);
            lblTotalIncome.Name = "lblTotalIncome";
            lblTotalIncome.Size = new Size(149, 30);
            lblTotalIncome.TabIndex = 14;
            lblTotalIncome.Text = "Income: ₱ 0.00";
            // 
            // lblTotalExpense
            // 
            lblTotalExpense.AutoSize = true;
            lblTotalExpense.BackColor = Color.White;
            lblTotalExpense.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalExpense.ForeColor = Color.Red;
            lblTotalExpense.Location = new Point(312, 24);
            lblTotalExpense.Name = "lblTotalExpense";
            lblTotalExpense.Size = new Size(156, 30);
            lblTotalExpense.TabIndex = 15;
            lblTotalExpense.Text = "Expense: ₱ 0.00";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.BackColor = Color.White;
            lblBalance.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBalance.ForeColor = Color.FromArgb(192, 192, 0);
            lblBalance.Location = new Point(587, 24);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(152, 30);
            lblBalance.TabIndex = 16;
            lblBalance.Text = "Balance: ₱ 0.00";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1036, 389);
            Controls.Add(lblBalance);
            Controls.Add(lblTotalExpense);
            Controls.Add(lblTotalIncome);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(dgvTransactions);
            Controls.Add(cmbType);
            Controls.Add(btnSave);
            Controls.Add(label4);
            Controls.Add(txtCategory);
            Controls.Add(label3);
            Controls.Add(txtAmount);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private TextBox txtAmount;
        private Label label3;
        private TextBox txtCategory;
        private Label label4;
        private Button btnSave;
        private ComboBox cmbType;
        private DataGridView dgvTransactions;
        private Button btnUpdate;
        private Button btnDelete;
      
     
        private Label lblTotalIncome;
        private Label lblTotalExpense;
        private Label lblBalance;
    }
}
