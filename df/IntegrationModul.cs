using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using MySqlX.XDevAPI.Common;

namespace dairy_farm
{
    public partial class IntegrationModul : Form
    {
        private HttpClient _httpClient;
        public IntegrationModul()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void IntegrationModul_Load(object sender, EventArgs e)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:4444/TransferSimulator/")
            };
        }

        private async void getbutton_Click(object sender, EventArgs e)
        {
            var responce = await _httpClient.GetAsync("fullName");
            var result = await responce.Content.ReadFromJsonAsync<Message>();

            getlabel.Text = result.value;
        }

        private void resultbutton_Click(object sender, EventArgs e)
        {
            string value = getlabel.Text;

            if(Regex.IsMatch(value, @"[^а-яА-я \-]"))
            {
                resultlabel.Text = "ФИО содержит запрещенные символы";
            }
            else
                resultlabel.Text = "ФИО не содержит запрещенные символы";
        }
    }
    class Message { public string value {  get; set; }  }
}
