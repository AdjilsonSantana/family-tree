using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    class FamilyMembers<T> where T : Draw
    {
        public T Obj;

        public List<FamilyMembers<T>> lstChildren = new
           List<FamilyMembers<T>>();

        private const float fX = 5;
        private const float fY = 30;

        private PointF ptCenter;

        public Font fFont = null;

        public Pen pPen = Pens.Black;
        public Brush bBrush = Brushes.Red;
        public Brush bBackBrush = Brushes.White;

        public FamilyMembers(T obj) : this(obj, new Font("Arial", 8))
        {

            Obj = obj;

        }
        public FamilyMembers(T obj, Font fFont)
        {

            Obj = obj;
            this.fFont = fFont;

        }

        public void Add(FamilyMembers<T> obj)
        {

            lstChildren.Add(obj);

        }

        public void Organize(Graphics gr, ref float X, ref float Y)
        {

            SizeF szObj = Obj.GetSize(gr, fFont);

            float x = X;
            float MaxY = Y + szObj.Height;
            float SubY = Y + szObj.Height + fY;

            foreach (FamilyMembers<T> tChild in lstChildren)
            {

                float MinY = SubY;

                tChild.Organize(gr, ref x, ref MinY);

                if (MaxY < MinY) MaxY = MinY;
                x += fX;

            }

            if (lstChildren.Count > 0) x -= fX;

            float SubWidth = x - X;

            if (szObj.Width > SubWidth)
            {

                x = X + (szObj.Width - SubWidth) / 2;

                foreach (FamilyMembers<T> tChild in lstChildren)
                {

                    tChild.Organize(gr, ref x, ref SubY);

                    x += fX;

                }

                SubWidth = szObj.Width;
            }

            ptCenter = new PointF(X + SubWidth / 2, Y +
               szObj.Height / 2);

            X += SubWidth;

            Y = MaxY;

        }

        public void DrawFamily(Graphics gr, ref float x, float y)
        {

            Organize(gr, ref x, ref y);

            DrawFamily(gr);

        }

        public void DrawFamily(Graphics gr)
        {

            DrawLinks(gr);

            DrawNodes(gr);

        }

        private void DrawLinks(Graphics gr)
        {

            if (lstChildren.Count == 1)
            {

                gr.DrawLine(pPen, ptCenter, lstChildren[0].ptCenter);

            }

            else if (lstChildren.Count > 1)
            {

                float xmin = lstChildren[0].ptCenter.X;
                float xmax = lstChildren[lstChildren.Count - 1]
                   .ptCenter.X;

                SizeF my_size = Obj.GetSize(gr, fFont);

                float y = ptCenter.Y + my_size.Height / 2 + fY / 2f;

                gr.DrawLine(pPen, xmin, y, xmax, y);

                gr.DrawLine(pPen, ptCenter.X, ptCenter.Y,
                   ptCenter.X, y);

                foreach (FamilyMembers<T> tChild in lstChildren)
                {

                    gr.DrawLine(pPen, tChild.ptCenter.X, y,
                       tChild.ptCenter.X, tChild.ptCenter.Y);

                }
            }

            foreach (FamilyMembers<T> tChild in lstChildren)
            {

                tChild.DrawLinks(gr);

            }

        }

        private void DrawNodes(Graphics gr)
        {
            Obj.Draw(ptCenter.X, ptCenter.Y, gr, pPen, bBackBrush,
               bBrush, fFont);

            foreach (FamilyMembers<T> tChild in lstChildren)
            {

                tChild.DrawNodes(gr);

            }
        }

        public FamilyMembers<T> NodePoint(Graphics gr,
           PointF ptTarget)
        {
            if (Obj.Point(gr, fFont, ptCenter, ptTarget)) return this;

            foreach (FamilyMembers<T> tChild in lstChildren)
            {

                FamilyMembers<T> hit_node =
                   tChild.NodePoint(gr, ptTarget);
                if (hit_node != null) return hit_node;

            }

            return null;

        }

    }
}
