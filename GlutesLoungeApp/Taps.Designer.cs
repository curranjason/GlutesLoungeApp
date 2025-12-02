namespace GlutesLoungeApp
{
    partial class Taps
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
            Taps_dataGridView = new DataGridView();
            buttonNewTap = new Button();
            btnUpdateTap = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)Taps_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // Taps_dataGridView
            // 
            Taps_dataGridView.AllowUserToAddRows = false;
            Taps_dataGridView.AllowUserToDeleteRows = false;
            Taps_dataGridView.AllowUserToResizeColumns = false;
            Taps_dataGridView.AllowUserToResizeRows = false;
            Taps_dataGridView.BackgroundColor = SystemColors.ControlLightLight;
            Taps_dataGridView.BorderStyle = BorderStyle.None;
            Taps_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Taps_dataGridView.Location = new Point(21, 23);
            Taps_dataGridView.MultiSelect = false;
            Taps_dataGridView.Name = "Taps_dataGridView";
            Taps_dataGridView.RowHeadersVisible = false;
            Taps_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Taps_dataGridView.Size = new Size(479, 251);
            Taps_dataGridView.TabIndex = 6;
            // 
            // buttonNewTap
            // 
            buttonNewTap.Location = new Point(21, 301);
            buttonNewTap.Name = "buttonNewTap";
            buttonNewTap.Size = new Size(114, 30);
            buttonNewTap.TabIndex = 12;
            buttonNewTap.Text = "New Tap";
            buttonNewTap.UseVisualStyleBackColor = true;
            buttonNewTap.Click += buttonNewTap_Click;
            // 
            // btnUpdateTap
            // 
            btnUpdateTap.Location = new Point(141, 301);
            btnUpdateTap.Name = "btnUpdateTap";
            btnUpdateTap.Size = new Size(114, 30);
            btnUpdateTap.TabIndex = 13;
            btnUpdateTap.Text = "Update";
            btnUpdateTap.UseVisualStyleBackColor = true;
            btnUpdateTap.Click += btnUpdateTap_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(261, 301);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 32);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(386, 301);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 32);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // Taps
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdateTap);
            Controls.Add(buttonNewTap);
            Controls.Add(Taps_dataGridView);
            Name = "Taps";
            Text = "Beer Taps";
            ((System.ComponentModel.ISupportInitialize)Taps_dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView Taps_dataGridView;
        private Button buttonNewTap;
        private Button btnUpdateTap;
        private Button btnDelete;
        private Button btnCancel;
    }
}