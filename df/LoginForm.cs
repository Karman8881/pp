using dairy_farm.Models; //ссылка на папку с формами
using Microsoft.Identity.Client;
using MySql.Data.MySqlClient; // использование адаптера MySql
using System;
using System.Drawing.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Macs;


namespace dairy_farm
{
    public partial class LoginForm : Form
    {
        string role;
        public LoginForm() => InitializeComponent();


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Поле недолжно быть пустым!", "Oшибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=karman;database=dairy_farm"))
            {
                connection.Open();

                MySqlCommand verificationCommand = new MySqlCommand($"SELECT Password, Cuptcha_count, Role From dairy_farm.users WHERE Login = @P1;", connection);
                verificationCommand.Parameters.AddWithValue("@P1", login);
                MySqlDataReader reader = verificationCommand.ExecuteReader();

                if (reader.Read())
                {
                    int attempts = reader.GetInt32("Cuptcha_count");
                    role = reader.GetString("Role");

                    if (attempts <= 0)
                    {
                        MessageBox.Show("Вы заблокированны ! Обратитесь к администратору.", "Превышенно количество попыток!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (reader.GetString("Password") == password)
                        Authorize(attempts, login, role);
                    else
                    {
                        reader.Close();
                        FailAuthorize(attempts, login, connection);
                    }
                }
                else
                    MessageBox.Show("Пользователя не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string SendRole() => role;
        private void FailAuthorize(int attempts, string login, MySqlConnection connection)
        {
            using (var updateCommand = new MySqlCommand($"UPDATE mydb.users SET Cuptcha_count = Cuptcha_count - 1 WHERE Login = '{login}';", connection)) updateCommand.ExecuteNonQuery();

            MessageBox.Show($"Вы ввели неверный логин или прароль. Пожалуйста проверьте ещё раз введенные данные!\nОсталось попыток :'{attempts - 1}'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Authorize(int attempts, string login, string role)
        {
            MessageBox.Show($"Вы успешно авторизовались!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (role != "admin")
            {
                using (var captcha = new Captcha(login, attempts))
                {
                    if (captcha.ShowDialog() == DialogResult.OK)
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            else 
            {
                 DialogResult = DialogResult.OK;
            }
        }
    }
}