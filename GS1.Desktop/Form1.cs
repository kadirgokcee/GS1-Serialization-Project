using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS1.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
        }

     
        private async void btnCreate_Click(object sender, EventArgs e)
        {
           
            string urunId = txtProductId.Text;
            string adet = txtQuantity.Text;
            string lotNo = txtLotNo.Text;           
            DateTime skt = dtpExpireDate.Value;     

            
            if (string.IsNullOrEmpty(urunId) || string.IsNullOrEmpty(adet) || string.IsNullOrEmpty(lotNo))
            {
                MessageBox.Show("Lütfen tüm alanlarý doldur !");
                return;
            }

            
            var gonderilecekPaket = new
            {
                productId = int.Parse(urunId),
                quantity = int.Parse(adet),
                lotNo = lotNo,      
                expireDate = skt    
            };

            
            using (HttpClient client = new HttpClient())
            {
                
                string adres = "https://localhost:7082/api/WorkOrder";

                try
                {
                    lblStatus.Text = "API'ye baðlanýlýyor...";
                    lblStatus.ForeColor = Color.Blue;

                    
                    var json = JsonSerializer.Serialize(gonderilecekPaket);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                  
                    HttpResponseMessage cevap = await client.PostAsync(adres, content);

                    if (cevap.IsSuccessStatusCode)
                    {
                        lblStatus.Text = "BAÞARILI! Üretim Emri Verildi.";
                        lblStatus.ForeColor = Color.Green;
                        MessageBox.Show($"Süper! '{lotNo}' parti numarasýyla üretim baþladý.", "Ýþlem Tamam");
                    }
                    else
                    {
                        lblStatus.Text = "HATA: " + cevap.ReasonPhrase;
                        lblStatus.ForeColor = Color.Red;
                    }
                }
                catch (Exception hata)
                {
                    lblStatus.Text = "Baðlantý Yok!";
                    MessageBox.Show("Hata: " + hata.Message);
                }
            }
        }
    }
}