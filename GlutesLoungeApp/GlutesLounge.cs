using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GlutesLoungeApp
{
    public partial class GlutesForm : Form
    {
        public GlutesForm()
        {
            InitializeComponent();
            this.Load += GlutesForm_Load;
        }
        private void GlutesForm_Load(object sender, EventArgs e)
        {
            CheckIfDatabaseFileExists();
        }

        private void CheckIfDatabaseFileExists()
        {
            string dbFileName = "GlutesLounge.db";
            string dbPath = Path.Combine(Application.StartupPath, dbFileName);

            if (!File.Exists(dbPath))
            {
                //SQLiteConnection.CreateFile("ContactBook.db");
                SQLiteConnection.CreateFile(dbPath);
                // Use the actual file path for the connection string
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3"))
                {
                    connection.Open();

                    // Ensure foreign key support (optional but recommended if you use FK constraints)
                    using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                    {
                        pragma.ExecuteNonQuery();
                    }

                    // Create Customers table
                    using (var cmd = new SQLiteCommand(connection))
                    {
                        cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Customers (
                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name VARCHAR(250),
                                Credits INTEGER
                            );";
                        cmd.ExecuteNonQuery();
                    }

                    // Create Taps table
                    using (var cmd = new SQLiteCommand(connection))
                    {
                        cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Taps (
                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                Position INTEGER,
                                KegBrand VARCHAR(250),
                                PoursSinceNewKeg INTEGER,
                                NewKegDate DATETIME
                            );";
                        cmd.ExecuteNonQuery();
                    }

                    // Create CustomerEvents table
                    using (var cmd = new SQLiteCommand(connection))
                    {
                        cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS CustomerEvents (
                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                CustomerID INTEGER,
                                EventType VARCHAR(100),
                                CreditChange INTEGER,
                                EventDate DATETIME,
                                FOREIGN KEY (CustomerID) REFERENCES Customers(ID) ON DELETE CASCADE
                            );";
                        cmd.ExecuteNonQuery();
                    }

                    // Create TapEvents table
                    using (var cmd = new SQLiteCommand(connection))
                    {
                        cmd.CommandText = @"
                            CREATE TABLE IF NOT EXISTS TapEvents (
                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                TapID INTEGER,
                                KegBrand VARCHAR(250),
                                KegReplacementDate DATETIME,
                                FOREIGN KEY (TapID) REFERENCES Taps(ID) ON DELETE CASCADE
                            );";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                LoadContactDataOnDataGridView();
            }

        }

        // Public helper so other forms can refresh the list
        public void LoadContactDataOnDataGridView()
        {
            LoadCustomerNamesAndCredits();
        }

        // Load only the Name column into the Customers_dataGridView and format the column
        private void LoadCustomerNamesAndCredits()
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
                    using (SQLiteCommand command = new SQLiteCommand("SELECT Name, Credits FROM Customers", connection))
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        Customers_dataGridView.DataSource = dt;
                    }
                }

                if (Customers_dataGridView.Columns.Count > 0)
                {
                    var col = Customers_dataGridView.Columns[0];
                    col.HeaderText = "Name";
                    
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Customers_dataGridView.DataSource = null;
            }
        }

        private DataTable GetCustomersFromDatabase()
        {
            // Kept for compatibility with other code paths that may rely on a DataTable return.
            // Use LoadCustomerNames for binding directly to the grid.
            DataTable result = new DataTable();
            string dbFileName = "GlutesLounge.db";
            string dbPath = Path.Combine(Application.StartupPath, dbFileName);

            if (!File.Exists(dbPath))
                return result;

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3"))
            {
                string query = "SELECT Name FROM Customers";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();
                    result.Load(reader);
                }
            }
            return result;
        }

        private void btnManageTaps_Click(object sender, EventArgs e)
        {
            GlutesLoungeApp.Taps frm = new GlutesLoungeApp.Taps();
            this.Hide();
            OpenChildPreserveBounds(frm);
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            GlutesLoungeApp.Customers frm = new GlutesLoungeApp.Customers();
            this.Hide();
            OpenChildPreserveBounds(frm);
        }

        private void btnPourBeer_Click(object sender, EventArgs e)
        {
            GlutesLoungeApp.PourBeer frm = new GlutesLoungeApp.PourBeer();
            OpenChildPreserveBounds(frm);
        }

        private void OpenChildPreserveBounds(Form child)
        {
            child.StartPosition = FormStartPosition.Manual;

            if (this.WindowState == FormWindowState.Maximized)
            {
                child.WindowState = FormWindowState.Maximized;
            }
            else
            {
                child.WindowState = FormWindowState.Normal;
                child.Bounds = this.Bounds;
            }

            child.Owner = this;
            this.Hide();
            child.Show();
        }

        private void btnDashboards_Click(object sender, EventArgs e)
        {
            GlutesLoungeApp.Dashboard frm = new GlutesLoungeApp.Dashboard();
            OpenChildPreserveBounds(frm);

        }
    }
}
