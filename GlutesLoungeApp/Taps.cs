using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GlutesLoungeApp
{
    public partial class Taps : Form
    {
        public Taps()
        {
            InitializeComponent();
            LoadTapDataOnDataGridView();

            // ensure delete handler is wired if Designer isn't wiring it
            btnDelete.Click += btnDelete_Click;
        }

        private void LoadTapDataOnDataGridView()
        {
            LoadTapInfo();
        }

        public void LoadTapInfo()
        {
            string dbFileName = "GlutesLounge.db";
            string dbPath = Path.Combine(Application.StartupPath, dbFileName);

            if (!File.Exists(dbPath))
            {
                Taps_dataGridView.DataSource = null;
                return;
            }

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3"))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Taps", connection))
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        Taps_dataGridView.DataSource = dt;
                    }
                }

                // Optional: hide row headers and set read-only / full row select
                Taps_dataGridView.RowHeadersVisible = false;
                Taps_dataGridView.AllowUserToAddRows = false;
                Taps_dataGridView.AllowUserToDeleteRows = false;
                Taps_dataGridView.ReadOnly = true;
                Taps_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load taps: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Taps_dataGridView.DataSource = null;
            }
        }

        private void buttonNewTap_Click(object sender, EventArgs e)
        {
            GlutesLoungeApp.TapDetails frm = new GlutesLoungeApp.TapDetails(this);
            this.Hide();
            frm.Show();
        }

        private void btnUpdateTap_Click(object sender, EventArgs e)
        {
            int id = GetId();
            if (id <= 0)
                return;

            GlutesLoungeApp.TapDetails frm = new GlutesLoungeApp.TapDetails(this, id);
            this.Hide();
            frm.Show();
        }

        private int GetId()
        {
            if (Taps_dataGridView.CurrentRow == null)
                return -1;

            var cell = Taps_dataGridView.Rows[Taps_dataGridView.CurrentRow.Index].Cells[0].Value;
            if (cell == null) return -1;

            if (int.TryParse(cell.ToString(), out var val))
                return val;

            return -1;
        }

        // delete selected tap with confirmation and optional logging to TapEvents
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = GetId();
            if (id <= 0)
                return;

            // Get display info (KegBrand or Position) for prompt
            string display = string.Empty;
            if (Taps_dataGridView.CurrentRow != null)
            {
                // try KegBrand column by name, fallback to second visible cell
                var brandCell = Taps_dataGridView.CurrentRow.Cells.Cast<DataGridViewCell>()
                    .FirstOrDefault(c => string.Equals(c.OwningColumn?.Name, "KegBrand", StringComparison.OrdinalIgnoreCase) || string.Equals(c.OwningColumn?.DataPropertyName, "KegBrand", StringComparison.OrdinalIgnoreCase));
                if (brandCell != null && brandCell.Value != null)
                    display = brandCell.Value.ToString();
                else if (Taps_dataGridView.CurrentRow.Cells.Count > 1)
                    display = Taps_dataGridView.CurrentRow.Cells[1].Value?.ToString() ?? string.Empty;
            }

            var confirm = MessageBox.Show(this,
                $"Delete the selected tap{(string.IsNullOrWhiteSpace(display) ? "" : $" '{display}'")} (ID = {id})?\nThis action cannot be undone.",
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
                        // Capture current keg brand (optional) before delete
                        string kegBrand = string.Empty;
                        using (var cmd = new SQLiteCommand("SELECT KegBrand FROM Taps WHERE ID = @Id", connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id", id);
                            var scalar = cmd.ExecuteScalar();
                            if (scalar != null && scalar != DBNull.Value)
                                kegBrand = scalar.ToString();
                        }

                        using (var del = new SQLiteCommand("DELETE FROM Taps WHERE ID = @Id", connection, transaction))
                        {
                            del.Parameters.AddWithValue("@Id", id);
                            del.ExecuteNonQuery();
                        }

                        // Optional: log to TapEvents table that tap was deleted (or replaced)
                        using (var ev = new SQLiteCommand("INSERT INTO TapEvents (TapID, KegBrand, KegReplacementDate) VALUES (@TapID, @KegBrand, @KegReplacementDate)", connection, transaction))
                        {
                            ev.Parameters.AddWithValue("@TapID", id);
                            ev.Parameters.AddWithValue("@KegBrand", kegBrand);
                            ev.Parameters.AddWithValue("@KegReplacementDate", DateTime.Now);
                            ev.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                // Refresh grid
                LoadTapDataOnDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting tap: {ex.Message}", "Delete tap", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                var newMain = new GlutesForm();
                newMain.Show();
                newMain.LoadContactDataOnDataGridView();
            }

            this.Close();
        }
    }
}
