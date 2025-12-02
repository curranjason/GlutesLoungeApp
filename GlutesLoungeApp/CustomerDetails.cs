using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace GlutesLoungeApp
{
    public partial class CustomerDetails : Form
    {
        int? Id;
        int? OriginalCredits;

        // Constructor used when opening from Customers (new)
        public CustomerDetails(Customers parent)
        {
            InitializeComponent();
            this.Owner = parent;
        }

        // Constructor used when editing an existing customer
        public CustomerDetails(Customers parent, int id)
        {
            InitializeComponent();
            this.Owner = parent;
            this.Id = id;

            var dt = GetDataById(id);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                if (row.Table.Columns.Contains("Name") && row["Name"] != DBNull.Value)
                    textCustomerName.Text = row["Name"].ToString();

                if (row.Table.Columns.Contains("Credits") && row["Credits"] != DBNull.Value)
                    OriginalCredits = Convert.ToInt32(row["Credits"]);
            }
        }

        // Parameterless designer constructor
        public CustomerDetails()
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
                string query = "SELECT ID, Name, Credits FROM Customers WHERE ID = @Id";
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnToPreviousForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Id.HasValue && Id.Value > 0)
                UpdateData();
            else
                SaveData();
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
                    string query = "INSERT INTO Customers (Name, Credits) VALUES (@Name, @Credits)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Name", textCustomerName.Text);
                        command.Parameters.AddWithValue("@Credits", 0);
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
            OriginalCredits = 0;
            WriteToCustomerEventTable("New User Created", (int)insertedId, 0);

            ReturnToPreviousForm();
        }

        private void UpdateData()
        {
            if (!Id.HasValue)
                return;

            int idValue = Id.Value;
            int newCredits = OriginalCredits ?? 0;

            // If you have a credits control, try to read it by known names
            var tb = this.Controls.Find("textCredits", true).FirstOrDefault() as TextBox;
            if (tb != null && int.TryParse(tb.Text, out var parsedFromTextBox))
            {
                newCredits = parsedFromTextBox;
            }
            else
            {
                var nud = this.Controls.Find("numericCredits", true).FirstOrDefault() as NumericUpDown;
                if (nud != null)
                    newCredits = Convert.ToInt32(nud.Value);
            }

            string dbFileName = "GlutesLounge.db";
            string dbPath = System.IO.Path.Combine(Application.StartupPath, dbFileName);

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    string query = "UPDATE Customers SET Name = @Name = @Credits WHERE ID = @Id";
                    using (var command = new SQLiteCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Name", textCustomerName.Text);
                       // command.Parameters.AddWithValue("@Credits", newCredits);
                       // command.Parameters.AddWithValue("@Id", idValue);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }

            int creditChange = 0;
           // OriginalCredits = newCredits;*/

            WriteToCustomerEventTable("Customer Updated", idValue, creditChange);

            ReturnToPreviousForm();
        }

        private void WriteToCustomerEventTable(string eventType, int customerId, int creditChange)
        {
            string dbFileName = "GlutesLounge.db";
            string dbPath = System.IO.Path.Combine(Application.StartupPath, dbFileName);

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3"))
            {
                string query = "INSERT INTO CustomerEvents (CustomerID, EventType, CreditChange, EventDate) VALUES (@CustomerID, @EventType, @CreditChange, @EventDate)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    command.Parameters.AddWithValue("@EventType", eventType);
                    command.Parameters.AddWithValue("@CreditChange", creditChange);
                    command.Parameters.AddWithValue("@EventDate", DateTime.Now);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ReturnToPreviousForm()
        {
            var main = Application.OpenForms.OfType<Customers>().FirstOrDefault();
            if (main != null)
            {
                // Refresh parent grid if available
                var reloadMethod = main.GetType().GetMethod("ReloadCustomers");
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