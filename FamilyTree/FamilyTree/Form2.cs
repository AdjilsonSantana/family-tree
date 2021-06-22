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
using Tulpep.NotificationWindow;

namespace FamilyTree
{
    public partial class Form2 : Form
    {
        public OpenFileDialog Open { get; set; }
        public int LastFatherId { get; set; }
        public int LastSonId { get; set; }
        public string Folder { get; set; }
        public int Filename { get; set; }

        public List<Father> Fathers { get; set; }
        public List<Son> Sons { get; set; }


        public Form2()
        {
            InitializeComponent();
            Open = new OpenFileDialog();
            Fathers = new List<Father>();
            Sons = new List<Son>();
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
       
            Form4 open = new Form4(Fathers,Sons);
            this.Hide(); 
            open.ShowDialog();
            
        }

        private void LoadData ()
        {
      
            //Connection 

            NpgsqlConnection conn = new NpgsqlConnection("Server= localhost; Port= 5432; Database= fTree; User id = postgres; Password= 1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from father";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                //DataTable dt = new DataTable();
                //dt.Load(dr);

                while (dr.Read())
                {
                    Fathers.Add(new Father
                    {
                        Id = (int)dr["id"],
                        FatherName = (string)dr["name"],

                    });
                }
                dr.Close();

                //dataGridView1.DataSource = dt;
            }


            comm.CommandText = "select * from son";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Sons.Add(new Son
                    {
                        Id = (int)dr["id"],
                        SonName = (string)dr["name"],
                        IdFather = (int)dr["identifier"],

                    });
                }
                LastSonId = Sons.LastOrDefault().Id;
                dr.Close();
            }

            LastFatherId = Fathers.LastOrDefault().Id;
            

            conn.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            image.Image = Image.FromFile(Application.StartupPath + @"\Image\" + "sem-foto.jpg");
            LoadData();
            textBoxSon.Enabled = false;
            saveSon.Enabled = false;
      
    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            Folder = string.Empty;
            Filename = 0;
            if (!IsSon.Checked)
            {
                Folder = "Father";
                Filename = LastFatherId + 1;
            }
            else
            {
                Folder = "Son";
                Filename = LastSonId + 1;
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

                if (!Directory.Exists(Application.StartupPath + @$"\Image\{Folder}\"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @$"\Image\{Folder}\");
                }

               

            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao Carregar a Imagem!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Open.Dispose();
            }

        }


        private void saveFather_Click(object sender, EventArgs e)
        {
            //Connection to database

            NpgsqlConnection conn = new NpgsqlConnection("Server= localhost; Port= 5432; Database= fTree; User id = postgres; Password= 1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "insert into father(name) values (@name) ";
            comm.Parameters.AddWithValue("@name", textBoxFather.Text);
          
            int result = comm.ExecuteNonQuery();

            if (result == 1)
            {
                if (!string.IsNullOrEmpty(Open.FileName) && Open.CheckFileExists)
                {
                    File.Copy(Open.FileName, Path.Combine(Application.StartupPath + @$"\Image\{Folder}\" + Path.GetFileName(Filename.ToString())));

                }
                else
                {
                    MessageBox.Show("Error uploading image!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Open.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Error inserting father!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Open.Dispose();
            }

            LoadData();

            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Sucess!";
            popup.Popup();

        }

        private void textBoxFather_TextChanged(object sender, EventArgs e)
        {

        }

        private void IsSon_CheckedChanged(object sender, EventArgs e)
        {
            if (IsSon.Checked)
            {
                textBoxFather.Enabled = false;
                saveFather.Enabled = false;
                textBoxSon.Enabled = true;
                saveSon.Enabled = true;

            }
            else
            {
                textBoxFather.Enabled = true;
                saveFather.Enabled = true;
                textBoxSon.Enabled = false;
                saveSon.Enabled = false;
            }
        }

        private void textBoxFather_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void saveSon_Click(object sender, EventArgs e)
        {
            //Connection to database

            NpgsqlConnection conn = new NpgsqlConnection("Server= localhost; Port= 5432; Database= fTree; User id = postgres; Password= 1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "insert into son(name, identifier) values (@name, @identifier) ";
            comm.Parameters.AddWithValue("@name", textBoxSon.Text);
            comm.Parameters.AddWithValue("@identifier", this.LastFatherId);

            int result = comm.ExecuteNonQuery();

            if (result == 1)
            {
                if (!string.IsNullOrEmpty(Open.FileName) && Open.CheckFileExists)
                {
                    File.Copy(Open.FileName, Path.Combine(Application.StartupPath + @$"\Image\{Folder}\" + Path.GetFileName(Filename.ToString())));

                }
                else
                {
                    MessageBox.Show("Error uploading image!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Open.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Error inserting son!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Open.Dispose();
            }

            LoadData();


            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Success!";
            popup.Popup();

        }

        private void image_Click(object sender, EventArgs e)
        {

        }
    }
}
