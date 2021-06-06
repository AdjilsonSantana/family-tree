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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            loadCombobox();

        }

        public void loadCombobox ()
        {
            comboBox1.Items.Clear();

            //Connection 

            NpgsqlConnection conn = new NpgsqlConnection("Server= localhost; Port= 5432; Database= fTree; User id = postgres; Password= 1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select name from father";
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(comm);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["name"].ToString());
            }
        }

        private void create_Click(object sender, EventArgs e)
        {
            Form2 insertData = new Form2();
            this.Hide();
            insertData.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            familyDesign family = new familyDesign();
            this.Hide();
            family.ShowDialog();
        }
    }
}
