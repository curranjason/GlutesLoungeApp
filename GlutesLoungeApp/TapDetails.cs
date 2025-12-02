using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GlutesLoungeApp
{
    public partial class TapDetails : Form
    {

        int? Id;

        public TapDetails(Taps parent, int id)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Id = id;

            var dt = GetDataById(id);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                if (row.Table.Columns.Contains("Position") && row["Position"] != DBNull.Value)
                    textBox1.Text = row["Position"].ToString();
                if (row.Table.Columns.Contains("KegBrand") && row["KegBrand"] != DBNull.Value)
                    textBox2.Text = row["KegBrand"].ToString();

            }
        }
        public TapDetails(Taps parent)
        {
            InitializeComponent();
            this.Owner = parent;
        }
        public TapDetails()
        {
            InitializeComponent();
        }



        private DataTable GetDataById(int Id)
        {
            DataTable result = new DataTable();
            string dbFileName = "GlutesLounge.db";
            string dbPath = System.IO.Path.Combine(Application.StartupPath, dbFileName);

            if (!System.IO.File.Exists(dbPath))
                return result;

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3"))
            {
                string query = "SELECT Position,KegBrand FROM Taps WHERE ID = @Id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        result.Load(reader);
                    }
                }
            }

            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Id.HasValue && Id.Value > 0)
                SaveData();
            //UpdateData();
            else
                SaveData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnToPreviousForm();
        }

        private void SaveData()
        {
            long insertedId = 0;
            string dbFileName = "GlutesLounge.db";
            string dbPath = System.IO.Path.Combine(Application.StartupPath, dbFileName);

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    string query = "INSERT INTO Taps (Position, KegBrand) VALUES (@Position, @KegBrand)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Position", int.Parse(textBox1.Text));
                        command.Parameters.AddWithValue("@KegBrand", textBox2.Text);
                        command.ExecuteNonQuery();
                    }

                    using (var cmdId = new SQLiteCommand("SELECT last_insert_rowid();", connection, transaction))
                    {
                        var scalar = cmdId.ExecuteScalar();
                        insertedId = (scalar != null && scalar != DBNull.Value) ? Convert.ToInt64(scalar) : 0L;
                    }

                    transaction.Commit();
                }
            }

            Id = (int)insertedId;
            WriteToTapEventsTable((int)insertedId, textBox2.Text);

            ReturnToPreviousForm();
        }

        private void WriteToTapEventsTable(int TapId, string KegBrand)
        {
            string dbFileName = "GlutesLounge.db";
            string dbPath = System.IO.Path.Combine(Application.StartupPath, dbFileName);

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3"))
            {
                string query = "INSERT INTO TapEvents (TapID, KegBrand) VALUES (@TapID, @KegBrand)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@TapID", TapId);
                    command.Parameters.AddWithValue("@KegBrand", KegBrand);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ReturnToPreviousForm()
        {
            var main = Application.OpenForms.OfType<Taps>().FirstOrDefault();
            if (main != null)
            {
                // Refresh parent grid if available
                var reloadMethod = main.GetType().GetMethod("LoadTapInfo");
                reloadMethod?.Invoke(main, null);

                main.Show();
            }
            else
            {
                var newMain = new GlutesForm();
                newMain.Show();
            }

            this.Close();
        }


    }
}
