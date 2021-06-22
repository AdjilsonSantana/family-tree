using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyTree
{
    interface Draw
    {
        SizeF GetSize(Graphics gr, Font fFont);

        bool Point(Graphics gr, Font fFont, PointF ptCentre,
           PointF ptTarget);

        void Draw(float x, float y, Graphics gr, Pen pen,
           Brush BackBrush, Brush Brush, Font fFont);
    }

    class PicNode : Draw
    {
        public Image Pic = null;

        public string Desc;

        public bool Sel = false;

        public PicNode(string desc, Image pic)
        {

            Desc = desc;
            Pic = pic;

        }


        public SizeF NodeSize = new SizeF(100, 100);
        private string fatherName;
        private string v;

        public SizeF GetSize(Graphics gr, Font fFont)
        {

            return NodeSize;

        }

        private RectangleF Loc(PointF ptCentre)
        {

            return new RectangleF(ptCentre.X - NodeSize.Width / 2,
               ptCentre.Y - NodeSize.Height / 2, NodeSize.Width,
               NodeSize.Height);

        }

        public bool Point(Graphics gr, Font font, PointF ptCentre,
           PointF ptTarget)
        {

            RectangleF rect = Loc(ptCentre);

            return rect.Contains(ptTarget);
        }


        public void Draw(float x, float y, Graphics gr, Pen pen,
           Brush backbrush, Brush brush, Font font)
        {
            RectangleF locrec = Loc(new PointF(x, y));

            Rectangle rect = Rectangle.Round(locrec);

            if (Sel)
            {

                gr.FillRectangle(Brushes.White, rect);

                ControlPaint.DrawBorder3D(gr, rect,
                   Border3DStyle.Sunken);

            }
            else
            {

                gr.FillRectangle(Brushes.Orange, rect);

                ControlPaint.DrawBorder3D(gr, rect,
                   Border3DStyle.Raised);

            }

            locrec.Inflate(-5, -5);

            locrec = Position(Pic, locrec);

            gr.DrawImage(Pic, locrec);
        }


        private RectangleF Position(Image pic, RectangleF rect)
        {
            float fWidth = pic.Width;
            float fHeight = pic.Height;

            float fCentre = fWidth / fHeight;
            float fRecCentre = rect.Width / rect.Height;
            float scale = 1;

            if (fCentre > fRecCentre)
            {

                scale = rect.Width / fWidth;

            }
            else
            {

                scale = rect.Height / fHeight;

            }

            fWidth *= scale;
            fHeight *= scale;

            RectangleF drawing_rect = new RectangleF(rect.X +
               (rect.Width - fWidth) / 2, rect.Y +
               (rect.Height - fHeight) / 2, fWidth, fHeight);

            return drawing_rect;
        }
    }
}
