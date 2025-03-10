using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Client
{
    public partial class ClientAppUI : Form
    {
        DataTable table = new DataTable("table");
        private Client client;
        public ClientAppUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Surname", typeof(string));
            dataGridView.DataSource = table;

            while (true)
            {
                var value = Interaction.InputBox("Enter server Ip and port.", "Server details.", "127.0.0.1:8910");
                serverDetailsLabel.Text = "Server details: " + value;
                string ip = "127.0.0.1";
                int port = 8910;
                if (value == "")
                {
                    // user pressed cancel
                    Application.Exit();

                    //ip = "127.0.0.1";
                    //port = 8910;
                }
                else
                {
                    var parts = value.Split(':');
                    ip = parts[0];
                    port = int.Parse(parts[1]);
                }

                try
                {
                    client = new Client(ip, port);
                    UpdateDataGrid(client.Request("GETALL"));
                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "" ||
                nameTextBox.Text == "" ||
                surnameTextBox.Text == "")
            {
                MessageBox.Show("Please fill-out all boxes.");
                return;
            }
            var res = LabelRequest("ADD", idTextBox.Text, nameTextBox.Text, surnameTextBox.Text);

            var update = LabelRequest("GETALL");
            UpdateDataGrid(update);
        }

        private void UpdateDataGrid(string data)
        {
            if (data == "") return;

            table.Clear();
            var lines = data.Split('\n');
            foreach (var line in lines)
            {
                if (line == "") continue;
                var parts = line.Split(' ');
                table.Rows.Add(parts[0], parts[1], parts[2]);
            }
        }

        private void ClearTextBoxes()
        {
            idTextBox.Text = string.Empty;
            nameTextBox.Text = string.Empty;
            surnameTextBox.Text = string.Empty;
        }

        // refresh button
        private void getAllButton_Click(object sender, EventArgs e)
        {
            var update = LabelRequest("GETALL");
            UpdateDataGrid(update);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "" ||
                nameTextBox.Text == "" ||
                surnameTextBox.Text == "")
            {
                MessageBox.Show("Please fill-out all boxes.");
                return;
            }
            var res = LabelRequest("EDIT", idTextBox.Text, nameTextBox.Text, surnameTextBox.Text);
            
            UpdateDataGrid(LabelRequest("GETALL"));
            ClearTextBoxes();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("Please enter an ID.");
                return;
            }
            var res = LabelRequest("DELETE", idTextBox.Text);
            if (res == "")
            {
                return;
            }
            else if (res == "BAD KEY!\n")
            {
                MessageBox.Show("ID not found. Nothing is deleted.");
            }
            UpdateDataGrid(LabelRequest("GETALL"));
            ClearTextBoxes();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = e.RowIndex;
            if (index < 0) return;
            var row = dataGridView.Rows[index];
            idTextBox.Text = row.Cells[0].Value.ToString();
            nameTextBox.Text = row.Cells[1].Value.ToString();
            surnameTextBox.Text = row.Cells[2].Value.ToString();
        }

        // request wrapper to show status message
        private string LabelRequest(string requestKw, string id = "", string name = "", string surname = "")
        {
            try
            {
                return client.Request(requestKw, id, name, surname);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server is not running.");
                return "";
            }
        }
    }
}
