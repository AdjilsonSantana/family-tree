using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace FamilyTree
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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
            List<Father> fathers = new List<Father>();
            List<Son> sons = new List<Son>();

            Father nfather = new Father();
           


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
                    fathers.Add(new Father
                    {
                        Id = (int) dr["id"],
                        FatherName = (string) dr["name"],
         
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
                    sons.Add(new Son
                    {
                        Id = (int) dr["id"],
                        SonName = (string) dr["name"],
                        IdFather = (int) dr["identifier"],

                    });
                }
                dr.Close();
            }


            Form3 open = new Form3();
            this.Hide();
            open.ShowDialog();

            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void saveFather_Click(object sender, EventArgs e)
        {
            //Connection 

            NpgsqlConnection conn = new NpgsqlConnection("Server= localhost; Port= 5432; Database= fTree; User id = postgres; Password= 1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "insert into father(name) values (@name) ";
            comm.Parameters.AddWithValue("@name", textBoxFather.Text);
            comm.ExecuteNonQuery();

        }

        private void textBoxFather_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
