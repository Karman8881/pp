using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace dairy_farm
{
    public partial class Captcha : Form
    {
        string login;
        int attemps;

        List<string> tags = new List<string>() { "1", "2", "3", "4" };
        public Captcha(string Login, int Attempts)
        {
            InitializeComponent();
            pictureBox1.AllowDrop = true;
            pictureBox2.AllowDrop = true;
            pictureBox3.AllowDrop = true;
            pictureBox4.AllowDrop = true;
            login = Login;
            attemps = Attempts;
        }

        private void Captcha_Load(object sender, EventArgs e)
        {

        }

        private void image_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox point = (PictureBox)sender;
                point.DoDragDrop((PictureBox)sender, DragDropEffects.Move);

        }

        private void image_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
                e.Effect = DragDropEffects.Move;
        }

        private void image_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox sourcePictureBox = e.Data.GetData(typeof(PictureBox)) as PictureBox;
            PictureBox targetPictureBox = (PictureBox)sender;
            targetPictureBox.Image = sourcePictureBox.Image;
            targetPictureBox.Tag = sourcePictureBox.Tag;
        }

        private void image_Click(object sender, EventArgs e)
        {
            if(attemps <= 0)
            {
                MessageBox.Show("Вы заблокированны! Обратитесь к администратору!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
                return;
            }

            using (MySqlConnection connector = new MySqlConnection("server=localhost;uid=root;pwd=karman;database=dairy_farm; AllowPublicKeyRetrieval=True;"))
            {
                connector.Open();
                List<PictureBox> elements = tableLayoutPanel1.Controls.Cast <PictureBox>().
                OrderBy(c => tableLayoutPanel1.GetRow(c)).
                ThenBy(connector => tableLayoutPanel2.GetColumn(connector)).ToList();
                MySqlCommand adapter = new MySqlCommand($"UPDATE dairy_farm.users SET Cuptcha_count = Cuptcha_count - 1 WHERE Login = @P1;", connector);
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        if (elements[i].Tag.ToString() != tags[i])
                        {
                            adapter.ExecuteNonQuery();
                            --attemps;
                            MessageBox.Show($"Капча собрана не верно! осталось попыток: {attemps}");
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show($"Заполните капчу корректно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            MessageBox.Show("Капча пройдена!");
            DialogResult = DialogResult.OK;
        }
    }
}