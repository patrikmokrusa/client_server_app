namespace Client
{
    partial class ClientAppUI
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
            dataGridView = new DataGridView();
            idLabel = new Label();
            idTextBox = new TextBox();
            nameTextBox = new TextBox();
            surnameTextBox = new TextBox();
            nameLabel = new Label();
            surnameLabel = new Label();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            getAllButton = new Button();
            serverDetailsLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(350, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(438, 284);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += dataGridView1_CellClick;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(12, 12);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(24, 20);
            idLabel.TabIndex = 1;
            idLabel.Text = "ID";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(96, 12);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(214, 27);
            idTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(96, 45);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(214, 27);
            nameTextBox.TabIndex = 3;
            // 
            // surnameTextBox
            // 
            surnameTextBox.Location = new Point(96, 78);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new Size(214, 27);
            surnameTextBox.TabIndex = 4;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 45);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(51, 20);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "NAME";
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize = true;
            surnameLabel.Location = new Point(12, 78);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new Size(78, 20);
            surnameLabel.TabIndex = 6;
            surnameLabel.Text = "SURNAME";
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 162);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 29);
            addButton.TabIndex = 7;
            addButton.Text = "ADD";
            addButton.TextAlign = ContentAlignment.BottomCenter;
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(12, 197);
            editButton.Name = "editButton";
            editButton.Size = new Size(94, 29);
            editButton.TabIndex = 8;
            editButton.Text = "EDIT";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(12, 232);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(94, 29);
            deleteButton.TabIndex = 9;
            deleteButton.Text = "DELETE";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // getAllButton
            // 
            getAllButton.Location = new Point(12, 267);
            getAllButton.Name = "getAllButton";
            getAllButton.Size = new Size(94, 29);
            getAllButton.TabIndex = 10;
            getAllButton.Text = "REFRESH";
            getAllButton.UseVisualStyleBackColor = true;
            getAllButton.Click += getAllButton_Click;
            // 
            // serverDetailsLabel
            // 
            serverDetailsLabel.AutoSize = true;
            serverDetailsLabel.Location = new Point(13, 310);
            serverDetailsLabel.Name = "serverDetailsLabel";
            serverDetailsLabel.Size = new Size(107, 20);
            serverDetailsLabel.TabIndex = 11;
            serverDetailsLabel.Text = "Server Details: ";
            // 
            // ClientAppUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 339);
            Controls.Add(serverDetailsLabel);
            Controls.Add(getAllButton);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(surnameLabel);
            Controls.Add(nameLabel);
            Controls.Add(surnameTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(idTextBox);
            Controls.Add(idLabel);
            Controls.Add(dataGridView);
            Name = "ClientAppUI";
            Text = "Client app";
            Load += ClientAppUI_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Label idLabel;
        private TextBox idTextBox;
        private TextBox nameTextBox;
        private TextBox surnameTextBox;
        private Label nameLabel;
        private Label surnameLabel;
        private Button addButton;
        private Button editButton;
        private Button deleteButton;
        private Button getAllButton;
        private Label serverDetailsLabel;
    }
}
