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
                var response = await SendGetRequestAsync(endpoint); // SendGetRequestAsync adında bir metod oluşturuyoruz.
                textBox1.Text = response; // gelen response u textbox'a yazdırıyoruz.
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
                var respone = await client.GetAsync(endpoint); // buradaki getAsync, metod ismidir postta postAsync, putta putAsync kullanılır. ve endpoint urlimizi gönderiyoruz.
                var responseContent = await respone.Content.ReadAsStringAsync(); // gelen cevabın içeriğini response content değişkenine atıyoruz.
                return responseContent; // ve contenti geriye göndürüyoruz 
            }
        }
    }
}