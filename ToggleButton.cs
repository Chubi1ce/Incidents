using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Incidents
{
    public class ToggleButton : CheckBox
    {
        //Fields
        private Color onBackColor = Color.LightGreen;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Red;
        private Color offToggleColor = Color.Gainsboro;

        //Properties
        public Color OnBackColor
        {
            get { return onBackColor; }
            set { onBackColor = value; this.Invalidate(); }
        }
        public Color OnToggleColor
        {
            get { return onToggleColor; }
            set { onToggleColor = value; this.Invalidate(); }
        }
        public Color OffBackColor
        {
            get { return offBackColor; }
            set { offBackColor = value; this.Invalidate(); }
        }
        public Color OffToggleColor
        {
            get { return offToggleColor; }
            set { offToggleColor = value; this.Invalidate(); }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set 
            { 
                base.Text = value;
            }
        }

        //Constructor
        public ToggleButton()
        {
            this.MinimumSize = new Size(20, 10);
        }

        //Methods
        private GraphicsPath GetFigurePath()
        {
            int arcSize = Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(Parent.BackColor);

            if (Checked)
            {
                //Draw the control surface
                pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                //Draw the toogle
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor), new Rectangle(Width - Height + 1, 2, toggleSize, toggleSize));
            }
            else
            {
                //Draw the control surface
                pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                //Draw the toogle
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}
