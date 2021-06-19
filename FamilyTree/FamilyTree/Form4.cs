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
        public List<Father> FathersCombo { get; set; }
        public List<Son> Sons { get; set; }

        private Father nameSelectd;

        public Form4( List<Father> fathers, List<Son> sons)
        {
            InitializeComponent();
            FathersCombo = new List<Father>();
            FathersCombo = fathers;
            nameSelectd.Sons = new List<Son>();
            Sons = sons;
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
            comboBox1.DataSource = FathersCombo.ToList();
            comboBox1.DisplayMember = "FatherName";
        }

        private void create_Click(object sender, EventArgs e)
        {
            Form2 insertData = new Form2();
            this.Hide();
            insertData.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nameSelectd =  comboBox1.SelectedItem as Father;

            //List<Son> sonFather ;

            nameSelectd.Sons = Sons.FindAll(s => s.IdFather == nameSelectd.Id);

            familyDesign family = new familyDesign(Sons, nameSelectd, FathersCombo);
            this.Hide();
            family.ShowDialog();
        }
    }
}
