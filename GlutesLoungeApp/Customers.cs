using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace GlutesLoungeApp
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            LoadCustomerDataOnDataGridView();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            GlutesLoungeApp.CustomerDetails frm = new GlutesLoungeApp.CustomerDetails(this);
            this.Hide();
            frm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var main = Application.OpenForms.OfType<GlutesForm>().FirstOrDefault();
            if (main != null)
            {
                main.Show();
                main.LoadContactDataOnDataGridView();
            }
            else
            {
                // Fallback: if the main form isn't in OpenForms (shouldn't normally happen),
                // create and show a new Form1 instance.
                var newMain = new GlutesForm();

                newMain.Show();
                newMain.LoadContactDataOnDataGridView();
            }

            this.Close();
        }

        public void LoadCustomerDataOnDataGridView()
        {
            LoadCustomerNames();
        }

        // Load only the Name column into the Customers_dataGridView and format the column
        private void LoadCustomerNames()
        {
            string dbFileName = "GlutesLounge.db";
            string dbPath = Path.Combine(Application.StartupPath, dbFileName);

            if (!File.Exists(dbPath))
            {
                Customers_dataGridView.DataSource = null;
                return;
            }

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3"))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Customers", connection))
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        Customers_dataGridView.DataSource = dt;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Customers_dataGridView.DataSource = null;
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            int id = GetId();
            GlutesLoungeApp.CustomerDetails frm = new GlutesLoungeApp.CustomerDetails(this, id);
            this.Hide();
            frm.Show();
        }

        private int GetId()
        {
            if (Customers_dataGridView.CurrentRow == null)
                return -1;

            var cell = Customers_dataGridView.Rows[Customers_dataGridView.CurrentRow.Index].Cells[0].Value;
            if (cell == null) return -1;

            if (int.TryParse(cell.ToString(), out var val))
                return val;

            return -1;
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            int id = GetId();
            if (id <= 0)
                return; // nothing selected or invalid id

            // Get a display name for the confirmation if available
            string displayName = string.Empty;
            if (Customers_dataGridView.CurrentRow != null)
            {
                if (Customers_dataGridView.Columns.Contains("Name"))
                    displayName = Customers_dataGridView.CurrentRow.Cells["Name"].Value?.ToString() ?? string.Empty;
                else if (Customers_dataGridView.CurrentRow.Cells.Count > 1)
                    displayName = Customers_dataGridView.CurrentRow.Cells[1].Value?.ToString() ?? string.Empty;
            }

            var confirm = MessageBox.Show(this,
                $"Delete the selected customer{(string.IsNullOrWhiteSpace(displayName) ? "" : $" '{displayName}'")} (ID = {id})?\nThis action cannot be undone.",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            string dbFileName = "GlutesLounge.db";
            string dbPath = Path.Combine(Application.StartupPath, dbFileName);

            if (!File.Exists(dbPath))
                return;

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3"))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        using (var del = new SQLiteCommand("DELETE FROM Customers WHERE ID = @Id", connection, transaction))
                        {
                            del.Parameters.AddWithValue("@Id", id);
                            del.ExecuteNonQuery();
                        }

                        // Optional: write an event record for the deletion
                        using (var ev = new SQLiteCommand("INSERT INTO CustomerEvents (CustomerID, EventType, CreditChange, EventDate) VALUES (@CustomerID, @EventType, @CreditChange, @EventDate)", connection, transaction))
                        {
                            ev.Parameters.AddWithValue("@CustomerID", id);
                            ev.Parameters.AddWithValue("@EventType", "Customer Deleted");
                            ev.Parameters.AddWithValue("@CreditChange", 0);
                            ev.Parameters.AddWithValue("@EventDate", DateTime.Now);
                            ev.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                // Refresh grid after delete
                LoadCustomerDataOnDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting customer: {ex.Message}", "Delete customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

            var main = Application.OpenForms.OfType<GlutesForm>().FirstOrDefault();
            if (main != null)
            {
                main.Show();
                main.LoadContactDataOnDataGridView();
            }
            else
            {
                // Fallback: if the main form isn't in OpenForms (shouldn't normally happen),
                // create and show a new Form1 instance.
                var newMain = new GlutesForm();

                newMain.Show();
                newMain.LoadContactDataOnDataGridView();
            }

            this.Close();
        }
    }
}