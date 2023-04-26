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
                var response = await SendGetRequestAsync(endpoint); // SendGetRequestAsync ad�nda bir metod olu�turuyoruz.
                textBox1.Text = response; // gelen response u textbox'a yazd�r�yoruz.
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
                var respone = await client.GetAsync(endpoint); // buradaki getAsync, metod ismidir postta postAsync, putta putAsync kullan�l�r. ve endpoint urlimizi g�nderiyoruz.
                var responseContent = await respone.Content.ReadAsStringAsync(); // gelen cevab�n i�eri�ini response content de�i�kenine at�yoruz.
                return responseContent; // ve contenti geriye g�nd�r�yoruz 
            }
        }
    }
}