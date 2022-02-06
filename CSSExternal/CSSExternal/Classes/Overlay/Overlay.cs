using LFOverlay.Classes.Variables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFOverlay.Classes
{
    class Overlay
    {
        private static Form OverlayForm = new Form();
        public static List<Structs.DrawData> DrawList = new List<Structs.DrawData>();
        public static long RenderMilliseconds = 0;
        public static float RenderFPS = 60;
        private static int RenderedFrames = 0;

        public static int Width
        {
            get
            {
                return OverlayForm.Width;
            }
            set
            {
                OverlayForm.Width = value;
            }
        }

        public static int Height
        {
            get
            {
                return OverlayForm.Height;
            }
            set
            {
                OverlayForm.Height = value;
            }
        }

        public static int X
        {
            get
            {
                return OverlayForm.Left;
            }
            set
            {
                OverlayForm.Left = value;
            }
        }

        public static int Y
        {
            get
            {
                return OverlayForm.Top;
            }
            set
            {
                OverlayForm.Top = value;
            }
        }

        public static bool Visible
        {
            get
            {
                return OverlayForm.Visible;
            }
            set
            {
                OverlayForm.Visible = value;
            }
        }

        public static bool TopMost
        {
            get
            {
                return OverlayForm.TopMost;
            }
            set
            {
                OverlayForm.TopMost = value;
            }
        }

        public static void Initalize()
        {
            OverlayForm.Show();
            OverlayForm.BackColor = Color.Black;
            OverlayForm.TopMost = true;
            OverlayForm.FormBorderStyle = FormBorderStyle.None;
            OverlayForm.Size = new System.Drawing.Size(1920, 1080);
            OverlayForm.Left = 0;
            OverlayForm.Top = 0;
            Control.CheckForIllegalCrossThreadCalls = false;
            Utils.SetDoubleBuffering(OverlayForm, true);
            WinAPI.SetWindowLong(OverlayForm.Handle, (int)Enums.WindowLongFlags.GWL_EXSTYLE, (uint)(WinAPI.GetWindowLong(OverlayForm.Handle, (int)Enums.WindowLongFlags.GWL_EXSTYLE) ^ Constants.WS_EX_LAYERED));
            WinAPI.SetLayeredWindowAttributes(OverlayForm.Handle, 0, 255, (uint)Enums.LayeredWindowFlags.LWA_COLORKEY | (uint)Enums.LayeredWindowFlags.LWA_ALPHA);
            uint initialStyle = (uint)WinAPI.GetWindowLong(OverlayForm.Handle, -20);
            WinAPI.SetWindowLong(OverlayForm.Handle, -20, initialStyle | 0x80000 | 0x20);

            OverlayForm.Paint += new PaintEventHandler(OverlayForm_Paint);
            fpsFrameStopwatch.Start();
        }

        static Stopwatch fpsStopwatch = new Stopwatch();
        static Stopwatch fpsFrameStopwatch = new Stopwatch();
        public static void Render()
        {
            fpsStopwatch.Start();
            OverlayForm.Refresh();
            RenderMilliseconds = fpsStopwatch.ElapsedMilliseconds;
            fpsStopwatch.Stop();
            fpsStopwatch.Reset();
        }

        private static void OverlayForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            try
            {
                foreach (Structs.DrawData drawData in DrawList)
                {
                    switch (drawData.Type)
                    {
                        case Enums.DrawType.Line:
                            e.Graphics.DrawLine(new Pen(drawData.Color, drawData.Thickness), drawData.SourceX, drawData.SourceY, drawData.TargetX, drawData.TargetY);
                            break;

                        case Enums.DrawType.Rectangle:
                            e.Graphics.DrawRectangle(new Pen(drawData.Color, drawData.Thickness), drawData.SourceX, drawData.SourceY, drawData.Width, drawData.Height);
                            break;

                        case Enums.DrawType.FilledRectangle:
                            e.Graphics.FillRectangle(new SolidBrush(drawData.Color), drawData.SourceX, drawData.SourceY, drawData.Width, drawData.Height);
                            break;

                        case Enums.DrawType.Circle:
                            e.Graphics.DrawEllipse(new Pen(drawData.Color, drawData.Thickness), drawData.SourceX - (drawData.Radius / 2), drawData.SourceY - (drawData.Radius / 2), drawData.Radius, drawData.Radius);
                            break;

                        case Enums.DrawType.FilledCircle:
                            e.Graphics.FillEllipse(new SolidBrush(drawData.Color), drawData.SourceX - (drawData.Radius / 2), drawData.SourceY - (drawData.Radius / 2), drawData.Radius, drawData.Radius);
                            break;

                        case Enums.DrawType.Text:
                            e.Graphics.DrawString(drawData.Text, new Font(drawData.FontFamily, drawData.FontSize), new SolidBrush(drawData.Color), new PointF(drawData.SourceX, drawData.SourceY));
                            break;
                    }
                }

                if (fpsFrameStopwatch.ElapsedMilliseconds >= 1000)
                {
                    RenderFPS = RenderedFrames;
                    RenderedFrames = 0;
                    fpsFrameStopwatch.Restart();
                }
                RenderedFrames++;
                DrawList.Clear();
            }
            catch { }
        }

        #region Drawings

        public static void Line(int x1, int y1, int x2, int y2, Color clr, float thickness = 1f)
        {
            Structs.DrawData data = new Structs.DrawData();
            data.Type = Enums.DrawType.Line;
            data.Color = clr;
            data.Thickness = thickness;

            data.SourceX = x1;
            data.SourceY = y1;
            data.TargetX = x2;
            data.TargetY = y2;
            DrawList.Add(data);
        }

        public static void Rectangle(int x1, int y1, int width, int height, Color clr, float thickness = 1f)
        {
            Structs.DrawData data = new Structs.DrawData();
            data.Type = Enums.DrawType.Rectangle;
            data.Color = clr;
            data.Thickness = thickness;

            data.SourceX = x1;
            data.SourceY = y1;
            data.Width = width;
            data.Height = height;
            DrawList.Add(data);
        }

        public static void FilledRectangle(int x1, int y1, int width, int height, Color clr)
        {
            Structs.DrawData data = new Structs.DrawData();
            data.Type = Enums.DrawType.FilledRectangle;
            data.Color = clr;

            data.SourceX = x1;
            data.SourceY = y1;
            data.Width = width;
            data.Height = height;
            DrawList.Add(data);
        }

        public static void Circle(int x1, int y1, int radius, Color clr, float thickness = 1f)
        {
            Structs.DrawData data = new Structs.DrawData();
            data.Type = Enums.DrawType.Circle;
            data.Color = clr;

            data.SourceX = x1;
            data.SourceY = y1;
            data.Radius = radius;
            data.Thickness = thickness;
            DrawList.Add(data);
        }

        public static void FilledCircle(int x1, int y1, int radius, Color clr, float thickness = 1f)
        {
            Structs.DrawData data = new Structs.DrawData();
            data.Type = Enums.DrawType.FilledCircle;
            data.Color = clr;

            data.SourceX = x1;
            data.SourceY = y1;
            data.Radius = radius;
            DrawList.Add(data);
        }

        public static void Text(string text, int x1, int y1, Color clr, bool CenterX = false, bool CenterY = false, string fontFamily = "Arial", float fontSize = 11f)
        {
            Structs.DrawData data = new Structs.DrawData();
            data.Type = Enums.DrawType.Text;
            data.Color = clr;

            data.Text = text;
            data.FontFamily = fontFamily;
            data.FontSize = fontSize;

            var textSize = TextRenderer.MeasureText(text, new Font(data.FontFamily, data.FontSize));
            data.SourceX = CenterX ? x1 - (int)(textSize.Width / 2) : x1;
            data.SourceY = CenterY ? y1 - (int)(textSize.Height / 2) : y1;

            DrawList.Add(data);
        }

        public static void CornerBox(int x, int y, int w, int h, int thickness, Color color)
        {
            FilledRectangle(x + thickness, y, w / 3, thickness, color); //top 
            FilledRectangle(x + w - w / 3 + thickness, y, w / 3, thickness, color); //top 
            FilledRectangle(x, y, thickness, h / 3, color); //left 
            FilledRectangle(x, y + h - h / 3 + thickness * 2, thickness, h / 3, color); //left 
            FilledRectangle(x + thickness, y + h + thickness, w / 3, thickness, color); //bottom 
            FilledRectangle(x + w - w / 3 + thickness, y + h + thickness, w / 3, thickness, color); //bottom 
            FilledRectangle(x + w + thickness, y, thickness, h / 3, color);//right 
            FilledRectangle(x + w + thickness, y + h - h / 3 + thickness * 2, thickness, h / 3, color);//right 
        }

        public static void Bar(int x, int y, int width, int height, int thickness, Color color, int value, int maxValue, Color valueColor)
        {
            FilledRectangle(x, y, width, (value * height / maxValue), valueColor);
            Rectangle(x, y, width, height, color, thickness);
        }

        #endregion
    }
}
