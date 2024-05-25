namespace PPKDotNetCore.WinFormsApp
{
    partial class FrmBlog
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
            lblTitle = new Label();
            lblAuthor = new Label();
            lblContent = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(180, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(53, 25);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Title :";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(180, 105);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(76, 25);
            lblAuthor.TabIndex = 2;
            lblAuthor.Text = "Author :";
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Location = new Point(180, 190);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(84, 25);
            lblContent.TabIndex = 3;
            lblContent.Text = "Content :";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(180, 59);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(438, 31);
            txtTitle.TabIndex = 4;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(180, 133);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(438, 31);
            txtAuthor.TabIndex = 5;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(180, 218);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(438, 100);
            txtContent.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(67, 160, 71);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(317, 324);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 7;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(84, 110, 122);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(180, 324);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(lblContent);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblContent;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Button btnSave;
        private Button btnCancel;
    }
}
