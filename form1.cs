using System;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace kenanimanovtravel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Şəhərlərin siyahıya əlavə edilməsi
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            string[] seherler = new string[] { "Bakı", "Sumqayıt", "Gəncə", "Şəki", "Qəbələ" };
            comboBox1.Items.AddRange(seherler);
            comboBox2.Items.AddRange(seherler);

            // Mask formatının təyini
            saat.Mask = "00:00";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Xahiş olunur, marşrutu tam seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.SelectedItem.ToString() == comboBox2.SelectedItem.ToString())
            {
                MessageBox.Show("Haradan və Haraya eyni şəhər ola bilməz!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(namesurname.Text) || string.IsNullOrWhiteSpace(fin.Text))
            {
                MessageBox.Show("Ad, Soyad və FIN kod hissələrini doldurun!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string biletMumat = $"Ad Soyad: {namesurname.Text} | FIN: {fin.Text} | Tel: {telefon.Text} | Email: {email.Text} | " +
                               $"Marşrut: {comboBox1.SelectedItem} -> {comboBox2.SelectedItem} | Tarix: {tarix.Text} | Saat: {saat.Text} | Yer: {yer.Value}\n";

            richTextBox1.AppendText(biletMumat);

            FormTemizle();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormTemizle()
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            tarix.Clear();
            saat.Clear();
            yer.Value = 0;
            namesurname.Clear();
            fin.Clear();
            telefon.Clear();
            email.Clear();
        }
    }
}
