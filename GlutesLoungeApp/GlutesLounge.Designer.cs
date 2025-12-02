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
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)Customers_dataGridView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnManageCustomers
            // 
            btnManageCustomers.Anchor = AnchorStyles.Top;
            btnManageCustomers.BackColor = Color.Transparent;
            btnManageCustomers.FlatAppearance.BorderSize = 0;
            btnManageCustomers.FlatStyle = FlatStyle.Flat;
            btnManageCustomers.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageCustomers.ForeColor = Color.White;
            btnManageCustomers.Location = new Point(3, 40);
            btnManageCustomers.Margin = new Padding(0, 5, 0, 5);
            btnManageCustomers.Name = "btnManageCustomers";
            btnManageCustomers.Size = new Size(208, 40);
            btnManageCustomers.TabIndex = 0;
            btnManageCustomers.Text = "Manage Customers";
            btnManageCustomers.UseVisualStyleBackColor = false;
            btnManageCustomers.Click += btnManageCustomers_Click;
            // 
            // btnManageTaps
            // 
            btnManageTaps.Anchor = AnchorStyles.None;
            btnManageTaps.BackColor = Color.Transparent;
            btnManageTaps.FlatAppearance.BorderSize = 0;
            btnManageTaps.FlatStyle = FlatStyle.Flat;
            btnManageTaps.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageTaps.ForeColor = Color.White;
            btnManageTaps.Location = new Point(3, 78);
            btnManageTaps.Name = "btnManageTaps";
            btnManageTaps.Size = new Size(208, 40);
            btnManageTaps.TabIndex = 1;
            btnManageTaps.Text = "Manage Taps";
            btnManageTaps.UseVisualStyleBackColor = false;
            btnManageTaps.Click += btnManageTaps_Click;
            // 
            // btnPourBeer
            // 
            btnPourBeer.Location = new Point(225, 361);
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
            Customers_dataGridView.Location = new Point(225, 80);
            Customers_dataGridView.MultiSelect = false;
            Customers_dataGridView.Name = "Customers_dataGridView";
            Customers_dataGridView.ReadOnly = true;
            Customers_dataGridView.RowHeadersVisible = false;
            Customers_dataGridView.Size = new Size(508, 193);
            Customers_dataGridView.TabIndex = 4;
            // 
            // btnDashboards
            // 
            btnDashboards.Anchor = AnchorStyles.Top;
            btnDashboards.BackColor = Color.Transparent;
            btnDashboards.FlatAppearance.BorderSize = 0;
            btnDashboards.FlatStyle = FlatStyle.Flat;
            btnDashboards.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboards.ForeColor = Color.White;
            btnDashboards.Location = new Point(3, 123);
            btnDashboards.Margin = new Padding(0, 5, 0, 5);
            btnDashboards.Name = "btnDashboards";
            btnDashboards.Size = new Size(208, 40);
            btnDashboards.TabIndex = 5;
            btnDashboards.Text = "Dashboards";
            btnDashboards.UseVisualStyleBackColor = false;
            btnDashboards.Click += btnDashboards_Click;
            // 
            // btnHome
            // 
            btnHome.Anchor = AnchorStyles.Top;
            btnHome.BackColor = Color.White;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.Black;
            btnHome.Location = new Point(3, 0);
            btnHome.Margin = new Padding(0, 5, 0, 5);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(208, 40);
            btnHome.TabIndex = 6;
            btnHome.Text = "Order Home";
            btnHome.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.WindowFrame;
            panel1.Controls.Add(btnHome);
            panel1.Controls.Add(btnDashboards);
            panel1.Controls.Add(btnManageCustomers);
            panel1.Controls.Add(btnManageTaps);
            panel1.Location = new Point(-3, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(211, 461);
            panel1.TabIndex = 7;
            // 
            // GlutesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(784, 461);
            Controls.Add(panel1);
            Controls.Add(btnPourBeer);
            Controls.Add(Customers_dataGridView);
            Name = "GlutesForm";
            Text = "Glute's Lounge";
            ((System.ComponentModel.ISupportInitialize)Customers_dataGridView).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageCustomers;
        private Button btnManageTaps;
        private Button btnPourBeer;
        private DataGridView Customers_dataGridView;
        private Button btnDashboards;
        private Button btnHome;
        private Panel panel1;
    }
}
