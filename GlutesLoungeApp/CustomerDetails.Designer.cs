namespace GlutesLoungeApp
{
    partial class CustomerDetails
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
            btnSave = new Button();
            btnCancel = new Button();
            lblName = new Label();
            textCustomerName = new TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(253, 122);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(93, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(399, 122);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(97, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(178, 70);
            lblName.Name = "lblName";
            lblName.Size = new Size(61, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Full Name";
            // 
            // textCustomerName
            // 
            textCustomerName.Location = new Point(253, 66);
            textCustomerName.Name = "textCustomerName";
            textCustomerName.Size = new Size(243, 23);
            textCustomerName.TabIndex = 3;
            // 
            // CustomerDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textCustomerName);
            Controls.Add(lblName);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Name = "CustomerDetails";
            Text = "CustomerDetails";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnCancel;
        private Label lblName;
        private TextBox textCustomerName;
    }
}