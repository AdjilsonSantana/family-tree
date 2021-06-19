using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyTree
{
    public partial class familyDesign : Form
    {
        private Father nameSelectd;
        public List<Father> Fathers { get; set; }
        public List<Son> Sons { get; set; }


        private FamilyMembers<PicNode> SelectedNode;
        private FamilyMembers<PicNode> Unknown ;


        public familyDesign(List<Son> son, Father father, List<Father> fatherCombo)
        {
            InitializeComponent();
            Sons = son;
            nameSelectd = father;
            Fathers = fatherCombo;

            Unknown = new FamilyMembers<PicNode>(new PicNode(nameSelectd.FatherName, Properties.Resources.Unknown));


        }

        private void ShowTree()
        {
            using (Graphics gr = pictureBox1.CreateGraphics())
            {

                float xmin = 0, ymin = 0;

                Unknown.Organize(gr, ref xmin, ref ymin);

                xmin = (this.ClientSize.Width - xmin) / 2;

                ymin = 15;

                Unknown.Organize(gr, ref xmin, ref ymin);

            }

            pictureBox1.Refresh();
        }

        private void SelNode(PointF pt)
        {

            if (SelectedNode != null)
            {

                SelectedNode.Obj.Sel = false;
                lblNodeText.Text = "";

            }

            using (Graphics gr = pictureBox1.CreateGraphics())
            {

                SelectedNode = Unknown.NodePoint(gr, pt);

                //SelectedNode = SNEFERU.NodePoint(gr, pt);
            }

            if (SelectedNode != null)
            {

                SelectedNode.Obj.Sel = true;
                lblNodeText.Text = SelectedNode.Obj.Desc;

            }


            pictureBox1.Refresh();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

            foreach (Son son in nameSelectd.Sons)
            {
                FamilyMembers<PicNode> sonn = new FamilyMembers<PicNode>(new PicNode(son.SonName, Properties.Resources.Adj));
                var pai = Fathers.FirstOrDefault(p => p.Id==son.IdFather && p.Id!=nameSelectd.Id );
                if (pai!=null)
                {
                    var filhos = Sons.FindAll(s => s.IdFather == pai.Id);
                    if (filhos!=null)
                    {
                        foreach (var item in filhos)
                        {
                            sonn.Add(new FamilyMembers<PicNode>(new PicNode(item.SonName, Properties.Resources.Adj)));
                        }
                    }
                }
                Unknown.Add(sonn);

            }

            ShowTree();
        }

        //FamilyMembers<PicNode> Adj = new FamilyMembers<PicNode>(new PicNode("Adjilson", Properties.Resources.Adj));
        //FamilyMembers<PicNode> Mauro = new FamilyMembers<PicNode>(new PicNode("Mauro", Properties.Resources.Mauro));
        //FamilyMembers<PicNode> MerititesI2 = new FamilyMembers<PicNode>(new PicNode("Mauro1", Properties.Resources.Mauro1));
        //FamilyMembers<PicNode> MerititesI3 = new FamilyMembers<PicNode>(new PicNode("Mauro2", Properties.Resources.Mauro2));
        //FamilyMembers<PicNode> MerititesI1_1 = new FamilyMembers<PicNode>(new PicNode("Helder", Properties.Resources.Adjilson1));


        //Adj.Add(MerititesI1_1);
        //Mauro.Add(MerititesI2);
        //Mauro.Add(MerititesI3);


        //Unknown.Add(Adj);
        //Unknown.Add(Mauro);

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint =
               TextRenderingHint.AntiAliasGridFit;

            Unknown.DrawFamily(e.Graphics);

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            SelNode(e.Location);
        }

        private void lblNodeText_Click(object sender, EventArgs e)
        {

        }

        private void create_Click(object sender, EventArgs e)
        {
            Form4 insertData = new Form4( Fathers,  Sons);
            this.Hide();
            insertData.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    }
