namespace GlutesLoungeApp
{
    partial class Customers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnNewCustomer = new Button();
            Customers_dataGridView = new DataGridView();
            btnUpdateCustomer = new Button();
            btnDeleteCustomer = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            btnHome = new Button();
            btnDashboards = new Button();
            btnManageCustomers = new Button();
            btnManageTaps = new Button();
            ((System.ComponentModel.ISupportInitialize)Customers_dataGridView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnNewCustomer
            // 
            btnNewCustomer.Location = new Point(255, 325);
            btnNewCustomer.Name = "btnNewCustomer";
            btnNewCustomer.Size = new Size(122, 30);
            btnNewCustomer.TabIndex = 0;
            btnNewCustomer.Text = "New Customer";
            btnNewCustomer.UseVisualStyleBackColor = true;
            btnNewCustomer.Click += btnNewCustomer_Click;
            // 
            // Customers_dataGridView
            // 
            Customers_dataGridView.AllowUserToAddRows = false;
            Customers_dataGridView.AllowUserToDeleteRows = false;
            Customers_dataGridView.AllowUserToResizeColumns = false;
            Customers_dataGridView.AllowUserToResizeRows = false;
            Customers_dataGridView.BackgroundColor = SystemColors.ControlLightLight;
            Customers_dataGridView.BorderStyle = BorderStyle.None;
            Customers_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Customers_dataGridView.Location = new Point(255, 47);
            Customers_dataGridView.MultiSelect = false;
            Customers_dataGridView.Name = "Customers_dataGridView";
            Customers_dataGridView.RowHeadersVisible = false;
            Customers_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Customers_dataGridView.Size = new Size(479, 251);
            Customers_dataGridView.TabIndex = 1;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Location = new Point(388, 325);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(119, 31);
            btnUpdateCustomer.TabIndex = 2;
            btnUpdateCustomer.Text = "Update";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(513, 325);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(134, 31);
            btnDeleteCustomer.TabIndex = 3;
            btnDeleteCustomer.Text = "Delete";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(658, 325);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(76, 30);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.WindowFrame;
            panel1.Controls.Add(btnHome);
            panel1.Controls.Add(btnDashboards);
            panel1.Controls.Add(btnManageCustomers);
            panel1.Controls.Add(btnManageTaps);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(208, 461);
            panel1.TabIndex = 8;
            // 
            // btnHome
            // 
            btnHome.Anchor = AnchorStyles.Top;
            btnHome.BackColor = Color.Transparent;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(1, 0);
            btnHome.Margin = new Padding(0, 5, 0, 5);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(208, 40);
            btnHome.TabIndex = 6;
            btnHome.Text = "Order Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // btnDashboards
            // 
            btnDashboards.Anchor = AnchorStyles.Top;
            btnDashboards.BackColor = Color.Transparent;
            btnDashboards.FlatAppearance.BorderSize = 0;
            btnDashboards.FlatStyle = FlatStyle.Flat;
            btnDashboards.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboards.ForeColor = Color.White;
            btnDashboards.Location = new Point(1, 81);
            btnDashboards.Margin = new Padding(0, 5, 0, 5);
            btnDashboards.Name = "btnDashboards";
            btnDashboards.Size = new Size(208, 40);
            btnDashboards.TabIndex = 5;
            btnDashboards.Text = "Dashboards";
            btnDashboards.UseVisualStyleBackColor = false;
            // 
            // btnManageCustomers
            // 
            btnManageCustomers.Anchor = AnchorStyles.Top;
            btnManageCustomers.BackColor = Color.White;
            btnManageCustomers.FlatAppearance.BorderSize = 0;
            btnManageCustomers.FlatStyle = FlatStyle.Flat;
            btnManageCustomers.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageCustomers.ForeColor = Color.Black;
            btnManageCustomers.Location = new Point(0, 41);
            btnManageCustomers.Margin = new Padding(0, 5, 0, 5);
            btnManageCustomers.Name = "btnManageCustomers";
            btnManageCustomers.Size = new Size(208, 40);
            btnManageCustomers.TabIndex = 0;
            btnManageCustomers.Text = "Manage Customers";
            btnManageCustomers.UseVisualStyleBackColor = false;
            // 
            // btnManageTaps
            // 
            btnManageTaps.Anchor = AnchorStyles.None;
            btnManageTaps.BackColor = Color.Transparent;
            btnManageTaps.FlatAppearance.BorderSize = 0;
            btnManageTaps.FlatStyle = FlatStyle.Flat;
            btnManageTaps.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageTaps.ForeColor = Color.White;
            btnManageTaps.Location = new Point(0, 120);
            btnManageTaps.Name = "btnManageTaps";
            btnManageTaps.Size = new Size(208, 40);
            btnManageTaps.TabIndex = 1;
            btnManageTaps.Text = "Manage Taps";
            btnManageTaps.UseVisualStyleBackColor = false;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(784, 461);
            Controls.Add(panel1);
            Controls.Add(btnCancel);
            Controls.Add(btnDeleteCustomer);
            Controls.Add(btnUpdateCustomer);
            Controls.Add(Customers_dataGridView);
            Controls.Add(btnNewCustomer);
            Name = "Customers";
            Text = "Customers";
            ((System.ComponentModel.ISupportInitialize)Customers_dataGridView).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewCustomer;
        private DataGridView Customers_dataGridView;
        private Button btnUpdateCustomer;
        private Button btnDeleteCustomer;
        private Button btnCancel;
        private Panel panel1;
        private Button btnHome;
        private Button btnDashboards;
        private Button btnManageCustomers;
        private Button btnManageTaps;
    }
}