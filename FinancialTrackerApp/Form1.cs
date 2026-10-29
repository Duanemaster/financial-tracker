using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Security.Cryptography;
namespace FinancialTrackerApp


{

    public partial class Form1 : Form
    {
        private string connectionString = @"Server=JOLANMAHINAY\SQLEXPRESS2019;Database=FinacialTrackerDB;Integrated Security=True;TrustServerCertificate=True;";

        private int selectedTransactionId = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please fill in both Title and Amount!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid numeric value for amount!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertTransaction", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@CATEGORY", txtCategory.Text.Trim());
                        cmd.Parameters.AddWithValue("@TransactionType", cmbType.SelectedItem?.ToString() ?? "Expense");

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Transaction saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearInputs();
                        LoadTransactions();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearInputs()
        {
            txtTitle.Clear();
            txtAmount.Clear();
            txtCategory.Clear();
            cmbType.SelectedIndex = -1;
        }




        private void LoadTransactions()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllTransactions", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        UpdateDashboardSummary(dt);
                       
                        dgvTransactions.DataSource = dt;
                        dgvTransactions.Columns["Amount"].DefaultCellStyle.Format = "₱ #,##0.00";
                        dgvTransactions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvTransactions.Columns["CATEGORY"].HeaderText = "Category";
                        dgvTransactions.Columns["TransactionType"].HeaderText = "Type";
                        dgvTransactions.Columns["TransactionID"].Visible = false;
                        dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvTransactions.AllowUserToAddRows = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbType_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            ClearInputs();
            LoadTransactions();
        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTransactions.Rows[e.RowIndex];

                selectedTransactionId = Convert.ToInt32(row.Cells["TransactionID"].Value);

                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtAmount.Text = row.Cells["Amount"].Value.ToString();
                txtCategory.Text = row.Cells["CATEGORY"].Value.ToString();
                cmbType.SelectedItem = row.Cells["TransactionType"].Value.ToString();


            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTransactionId == 0)
            {
                MessageBox.Show("Please select a transaction from the list first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid numeric amount!", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please fill in the both Title and the Amount!", "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateTransaction", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TransactionID", selectedTransactionId);
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@CATEGORY", txtCategory.Text.Trim());
                        cmd.Parameters.AddWithValue("TransactionType", cmbType.SelectedItem?.ToString() ?? "Expense");

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Transaction updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearInputs();
                        selectedTransactionId = 0;
                        LoadTransactions();


                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTransactionId == 0)
            {
                MessageBox.Show("Please Select a transaction to Delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_DeleteTransaction", conn))

                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TransactionID", selectedTransactionId);

                            conn.Open();
                            cmd.ExecuteNonQuery();


                            MessageBox.Show("Transaction successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearInputs();
                            selectedTransactionId = 0; LoadTransactions();
                            LoadTransactions();

                        }

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("DataBase Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void UpdateDashboardSummary(DataTable dt)
        {
            decimal totalIncome = 0;
            decimal totalExpense = 0;

            foreach (DataRow row in dt.Rows) {

                decimal amount = Convert.ToDecimal(row["Amount"]);
                string type = row["TransactionType"].ToString();

                if (type == "Income") {
                    totalIncome += amount;    
                }
                else if (type == "Expense")
                {
                    totalExpense += amount;
                }
            }

            decimal balance = totalIncome - totalExpense;

            lblTotalIncome.Text = "Income: ₱ " + totalIncome.ToString("#,##0.00");
            lblTotalExpense.Text = "Expense: ₱" + totalExpense.ToString("#,##0.00");
            lblBalance.Text = "Balance: ₱" + balance.ToString("#,##0.00");

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

       
    }
} 
