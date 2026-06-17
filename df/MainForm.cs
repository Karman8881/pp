using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace dairy_farm
{
    public partial class MainForm : Form
    {
        string connectionString = "server=LocalHost;uid=root;pwd=karman;database=dairy_farm";

        string Role { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Role == "User")
                tabControl1.TabPages.Remove(tabPage1);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    LoadData("SELECT * FROM dairy_farm.users", dataGridView1);
                    LoadData("SELECT * FROM dairy_farm.product", dataGridView2);
                    LoadData("SELECT * FROM dairy_farm.specification", dataGridView3);
                    LoadData("SELECT * FROM dairy_farm.order", dataGridView4);
                    LoadData("SELECT * FROM dairy_farm.contactor", dataGridView5);
                    LoadData("SELECT * FROM dairy_farm.material", dataGridView6);
                    LoadData("SELECT * FROM dairy_farm.production", dataGridView7);

                    MessageBox.Show("Подключение к БД прошло успешно!");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void UpdateData(string command, DataGridView grid)
        {
            //подключение к базе данных
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                    DataTable dt = grid.DataSource as DataTable;

                    adapter.Update(dt);
                    dt.AcceptChanges();

                    MessageBox.Show("Данные были успешно сохранены!");

                    connection.Close();
                }
                catch (MySqlException ex)
                {
                    //обработка исключения при существующем пользователе
                    if (ex.Number == 1062)
                        MessageBox.Show("Ошибка! Пользователь уже существует в системе!");
                    else
                        MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView grid = tabControl1.SelectedTab.Controls.OfType<DataGridView>().FirstOrDefault();
                foreach (DataGridViewRow row in grid.SelectedRows)
                {
                    grid.Rows.Remove(row);
                }
                MessageBox.Show("Данные удалены!");
            }
            catch
            {
                MessageBox.Show("Ошибка выполнения операции!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateData("SELECT * FROM dairy_farm.users", dataGridView1);
        }
        private void LoadData(string command, DataGridView grid)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);

                DataTable dt = new DataTable();

                adapter.Fill(dt);
                grid.DataSource = dt;
            }
        }

        private void integrationmodul_Click(object sender, EventArgs e)
        {
            IntegrationModul MainForm = new IntegrationModul();
            MainForm.Show();
        }
    }
}
