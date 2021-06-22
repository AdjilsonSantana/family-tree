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

        string path = "";


        public familyDesign(List<Son> son, Father father, List<Father> fatherCombo)
        {
            InitializeComponent();
            Sons = son;
            nameSelectd = father;
            Fathers = fatherCombo;

            path = Application.StartupPath;

            Unknown = new FamilyMembers<PicNode>(new PicNode(nameSelectd.FatherName, new Bitmap( path + @"\Image\Father\" + nameSelectd.Id)));

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
                FamilyMembers<PicNode> sonn = new FamilyMembers<PicNode>(new PicNode(son.SonName, new Bitmap(path + @"\Image\Son\" + son.Id)));

                var father = Fathers.FirstOrDefault(p => p.FatherName==son.SonName && p.Id!=nameSelectd.Id );

                if (father!=null)
                {
                    var sons = Sons.FindAll(s => s.IdFather == father.Id);
                    if (sons!=null)
                    {
                        foreach (var s in sons)
                        {
                            sonn.Add(new FamilyMembers<PicNode>(new PicNode(s.SonName, new Bitmap(path + @"\Image\Son\" + s.Id))));
                        }
                    }
                }

                Unknown.Add(sonn);

            }

            ShowTree();

            
        }
 

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
