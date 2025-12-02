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
            ((System.ComponentModel.ISupportInitialize)Customers_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnNewCustomer
            // 
            btnNewCustomer.Location = new Point(122, 328);
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
            Customers_dataGridView.Location = new Point(122, 47);
            Customers_dataGridView.MultiSelect = false;
            Customers_dataGridView.Name = "Customers_dataGridView";
            Customers_dataGridView.RowHeadersVisible = false;
            Customers_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Customers_dataGridView.Size = new Size(479, 251);
            Customers_dataGridView.TabIndex = 1;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Location = new Point(255, 328);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(119, 31);
            btnUpdateCustomer.TabIndex = 2;
            btnUpdateCustomer.Text = "Update";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(380, 328);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(134, 31);
            btnDeleteCustomer.TabIndex = 3;
            btnDeleteCustomer.Text = "Delete";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(525, 328);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(76, 30);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnDeleteCustomer);
            Controls.Add(btnUpdateCustomer);
            Controls.Add(Customers_dataGridView);
            Controls.Add(btnNewCustomer);
            Name = "Customers";
            Text = "Customers";
            ((System.ComponentModel.ISupportInitialize)Customers_dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewCustomer;
        private DataGridView Customers_dataGridView;
        private Button btnUpdateCustomer;
        private Button btnDeleteCustomer;
        private Button btnCancel;
    }
}