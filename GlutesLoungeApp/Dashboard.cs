using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GlutesLoungeApp
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            LoadCustomerNames();
        }


        private void LoadCustomerNames()
        {
            string dbFileName = "GlutesLounge.db";
            string dbPath = Path.Combine(Application.StartupPath, dbFileName);

            if (!File.Exists(dbPath))
            {
                dataGridViewCustomerEvents.DataSource = null;
                return;
            }

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3"))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM CustomerEvents", connection))
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        dataGridViewCustomerEvents.DataSource = dt;
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridViewCustomerEvents.DataSource = null;
            }
        }
    }
}

