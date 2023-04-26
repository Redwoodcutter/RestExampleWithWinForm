namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void GetData_Click(object sender, EventArgs e)
        {
            string endpoint = "https://jsonplaceholder.typicode.com/posts"; // Enpoint belirliyoruz.

            try
            {
                var response = await SendGetRequestAsync(endpoint); // SendGetRequestAsync adýnda bir metod oluþturuyoruz.
                textBox1.Text = response; // gelen response u textbox'a yazdýrýyoruz.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "API ERROR");
            }
        }
        public static async Task<string> SendGetRequestAsync(string endpoint)
        {
            using (var client = new HttpClient())
            {
                var respone = await client.GetAsync(endpoint); // buradaki getAsync, metod ismidir postta postAsync, putta putAsync kullanýlýr. ve endpoint urlimizi gönderiyoruz.
                var responseContent = await respone.Content.ReadAsStringAsync(); // gelen cevabýn içeriðini response content deðiþkenine atýyoruz.
                return responseContent; // ve contenti geriye göndürüyoruz 
            }
        }
    }
}