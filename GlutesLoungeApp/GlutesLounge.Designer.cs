namespace GlutesLoungeApp
{
    partial class GlutesForm
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
            btnManageCustomers = new Button();
            btnManageTaps = new Button();
            btnPourBeer = new Button();
            Customers_dataGridView = new DataGridView();
            btnDashboards = new Button();
            btnHome = new Button();
            ((System.ComponentModel.ISupportInitialize)Customers_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnManageCustomers
            // 
            btnManageCustomers.Location = new Point(175, 12);
            btnManageCustomers.Name = "btnManageCustomers";
            btnManageCustomers.Size = new Size(148, 23);
            btnManageCustomers.TabIndex = 0;
            btnManageCustomers.Text = "Manage Customers";
            btnManageCustomers.UseVisualStyleBackColor = true;
            btnManageCustomers.Click += btnManageCustomers_Click;
            // 
            // btnManageTaps
            // 
            btnManageTaps.Location = new Point(329, 12);
            btnManageTaps.Name = "btnManageTaps";
            btnManageTaps.Size = new Size(148, 23);
            btnManageTaps.TabIndex = 1;
            btnManageTaps.Text = "Manage Taps";
            btnManageTaps.UseVisualStyleBackColor = true;
            btnManageTaps.Click += btnManageTaps_Click;
            // 
            // btnPourBeer
            // 
            btnPourBeer.Location = new Point(47, 352);
            btnPourBeer.Name = "btnPourBeer";
            btnPourBeer.Size = new Size(331, 48);
            btnPourBeer.TabIndex = 2;
            btnPourBeer.Text = "Pour Beer";
            btnPourBeer.UseVisualStyleBackColor = true;
            btnPourBeer.Click += btnPourBeer_Click;
            // 
            // Customers_dataGridView
            // 
            Customers_dataGridView.AllowUserToAddRows = false;
            Customers_dataGridView.AllowUserToResizeColumns = false;
            Customers_dataGridView.AllowUserToResizeRows = false;
            Customers_dataGridView.BackgroundColor = SystemColors.ControlLightLight;
            Customers_dataGridView.BorderStyle = BorderStyle.None;
            Customers_dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            Customers_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Customers_dataGridView.Location = new Point(47, 61);
            Customers_dataGridView.MultiSelect = false;
            Customers_dataGridView.Name = "Customers_dataGridView";
            Customers_dataGridView.ReadOnly = true;
            Customers_dataGridView.RowHeadersVisible = false;
            Customers_dataGridView.Size = new Size(462, 247);
            Customers_dataGridView.TabIndex = 4;
            // 
            // btnDashboards
            // 
            btnDashboards.Location = new Point(483, 12);
            btnDashboards.Name = "btnDashboards";
            btnDashboards.Size = new Size(143, 23);
            btnDashboards.TabIndex = 5;
            btnDashboards.Text = "Dashboards";
            btnDashboards.UseVisualStyleBackColor = true;
            btnDashboards.Click += btnDashboards_Click;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(28, 12);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(141, 23);
            btnHome.TabIndex = 6;
            btnHome.Text = "Order Home";
            btnHome.UseVisualStyleBackColor = true;
            // 
            // GlutesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(784, 461);
            Controls.Add(btnHome);
            Controls.Add(btnDashboards);
            Controls.Add(btnPourBeer);
            Controls.Add(Customers_dataGridView);
            Controls.Add(btnManageTaps);
            Controls.Add(btnManageCustomers);
            Name = "GlutesForm";
            Text = "Glute's Lounge";
            ((System.ComponentModel.ISupportInitialize)Customers_dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageCustomers;
        private Button btnManageTaps;
        private Button btnPourBeer;
        private DataGridView Customers_dataGridView;
        private Button btnDashboards;
        private Button btnHome;
    }
}
