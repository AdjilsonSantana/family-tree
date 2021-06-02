using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace FamilyTree
{
    public partial class Form2 : Form
    {
        public OpenFileDialog Open { get; set; }

        public int LastFatherId { get; set; }
        public int LastSonId { get; set; }
        public Form2()
        {
            InitializeComponent();
            Open = new OpenFileDialog();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void create_Click(object sender, EventArgs e)
        {
            InitialPage home = new InitialPage();
            this.Hide();
            home.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Connection 

            NpgsqlConnection conn = new NpgsqlConnection("Server= localhost; Port= 5432; Database= fTree; User id = postgres; Password= 1234");

            Form3 open = new Form3();
            this.Hide();
            open.ShowDialog();

            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            image.Image = Image.FromFile(Application.StartupPath + @"\Image\" + "sem-foto.jpg");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            string folder = string.Empty;
            int filename = 0;
            if (!IsSon.Checked)
            {
                folder = "Father";
                filename = LastFatherId + 1;
            }
            else
            {
                folder = "Son";
                filename = LastSonId + 1;
            }
            image.Image.Dispose();
            Open.Dispose();

            try
            {

                Open.Filter = "Images Files(*.jpg;*.jpeg;*.bmp)|*.jpg;*.jpeg;*.bmp";

                if (Open.ShowDialog() == DialogResult.OK && Open.CheckPathExists)
                {
                    image.Image = Image.FromFile(Open.FileName);
                }

                if (!Directory.Exists(Application.StartupPath + @$"\Image\{folder}\"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @$"\Image\{folder}\");
                }

                if (!string.IsNullOrEmpty(Open.FileName) && Open.CheckFileExists)
                {
                    File.Copy(Open.FileName, Path.Combine(Application.StartupPath + @$"\Image\{folder}\" + Path.GetFileName(filename.ToString())));

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao Carregar a Imagem!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Open.Dispose();
            }

        }
    }
}
