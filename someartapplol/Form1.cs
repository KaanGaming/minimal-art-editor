using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace someartapplol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public byte brushsize = 1;

        public ushort Width = 256;
        public ushort Height = 256;

        public int a = 0;

        bool editing = false;

        public List<BitPixel> pixelmap = new List<BitPixel>();
        Brush black = Brushes.Black;
        Brush white = Brushes.White;

        private void Form1_Load(object sender, EventArgs e)
        {
            brushSizeToolStripMenuItem.Enabled = false;
            debugToolStripMenuItem.Visible = false;
#if DEBUG
            debugToolStripMenuItem.Visible = true;
#endif
            Debug.WriteLine("pogchamp!");
            pixelmap.Add(new BitPixel(true, 5, 5));
            pixelmap.Add(new BitPixel(true, 6, 5));
            pixelmap.Add(new BitPixel(true, 7, 5));
            pixelmap.Add(new BitPixel(true, 8, 5));
            pixelmap.Add(new BitPixel(true, 9, 5));
            pixelmap.Add(new BitPixel(true, 10, 6));
            pixelmap.Add(new BitPixel(true, 10, 7));
            pixelmap.Add(new BitPixel(true, 10, 8));
            pixelmap.Add(new BitPixel(true, 10, 9));
            pixelmap.Add(new BitPixel(true, 10, 10));
            pixelmap.Add(new BitPixel(true, 9, 10));
            pixelmap.Add(new BitPixel(true, 8, 10));
            pixelmap.Add(new BitPixel(true, 7, 10));
            pixelmap.Add(new BitPixel(true, 6, 10));
            pixelmap.Add(new BitPixel(true, 5, 10));
            pixelmap.Add(new BitPixel(true, 5, 9));
            pixelmap.Add(new BitPixel(true, 5, 8));
            pixelmap.Add(new BitPixel(true, 5, 7));
            pixelmap.Add(new BitPixel(true, 5, 6));
            pixelmap.Add(new BitPixel(true, 5, 5));
        }

        private void picpanel_Paint(object sender, PaintEventArgs e)
        {
            a += 1;
            Debug.WriteLine(pixelmap);
            Debug.WriteLine("thing");
            Graphics panelG = e.Graphics;
            panelG = picpanel.CreateGraphics();
            foreach (BitPixel bit in pixelmap)
            {
                Brush cPen;
                switch (bit.Black) {
                    case false:
                        cPen = white;
                        break;
                    case true:
                        cPen = black;
                        break;
                    default:
                        cPen = white;
                        break;
                }
                panelG.FillRectangle(cPen, new Rectangle(bit.X, bit.Y, 1, 1));
            }
        }

        private void toggleEditingOn(object sender, EventArgs e)
        {
            editing = !editing;

            if (editing)
            {
                startEditingToolStripMenuItem.Text = "Stop editing";
                brushSizeToolStripMenuItem.Enabled = true;
            }
            else
            {
                startEditingToolStripMenuItem.Text = "Start editing";
                brushSizeToolStripMenuItem.Enabled = false;
            }
        }

        private void picmousedown(object sender, MouseEventArgs e)
        {

        }

        private void picmousemove(object sender, MouseEventArgs e)
        {
            if (editing)
            {
                bool bleck = false;
                bool stop = false;
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        bleck = true;
                        break;

                    case MouseButtons.Right:
                        bleck = false;
                        break;

                    default:
                        stop = true;
                        break;
                }

                Debug.WriteLineIf(bleck && !stop, "left click!!!");
                Debug.WriteLineIf(!bleck && !stop, "right click!!!");

                if (stop) return;

                if (bleck)
                {
                    if (brushsize == 1)
                    {
                        Debug.WriteLine("small draw");
                        if (!pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y))
                            pixelmap.Add(new BitPixel(true, e.X, e.Y));
                    }
                    else if (brushsize == 2)
                    {
                        Debug.WriteLine("medium draw");
                        if (!pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y))
                            pixelmap.Add(new BitPixel(true, e.X, e.Y));
                        if (!pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y - 1))
                            pixelmap.Add(new BitPixel(true, e.X - 1, e.Y - 1));
                        if (!pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y))
                            pixelmap.Add(new BitPixel(true, e.X - 1, e.Y));
                        if (!pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y - 1))
                            pixelmap.Add(new BitPixel(true, e.X, e.Y - 1));
                        if (!pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y + 1))
                            pixelmap.Add(new BitPixel(true, e.X + 1, e.Y + 1));
                        if (!pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y))
                            pixelmap.Add(new BitPixel(true, e.X + 1, e.Y));
                        if (!pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y + 1))
                            pixelmap.Add(new BitPixel(true, e.X, e.Y + 1));
                        if (!pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y + 1))
                            pixelmap.Add(new BitPixel(true, e.X - 1, e.Y + 1));
                        if (!pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y - 1))
                            pixelmap.Add(new BitPixel(true, e.X + 1, e.Y - 1));
                    }
                    else if (brushsize == 3)
                    {
                        Debug.WriteLine("big draw"); //
                        if (!pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y))
                            pixelmap.Add(new BitPixel(true, e.X, e.Y));
                        if (!pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y - 1))
                            pixelmap.Add(new BitPixel(true, e.X - 1, e.Y - 1));
                        if (!pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y))
                            pixelmap.Add(new BitPixel(true, e.X - 1, e.Y));
                        if (!pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y - 1))
                            pixelmap.Add(new BitPixel(true, e.X, e.Y - 1));
                        if (!pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y + 1))
                            pixelmap.Add(new BitPixel(true, e.X + 1, e.Y + 1));
                        if (!pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y))
                            pixelmap.Add(new BitPixel(true, e.X + 1, e.Y));
                        if (!pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y + 1))
                            pixelmap.Add(new BitPixel(true, e.X, e.Y + 1));
                        if (!pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y + 1))
                            pixelmap.Add(new BitPixel(true, e.X - 1, e.Y + 1));
                        if (!pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y - 1))
                            pixelmap.Add(new BitPixel(true, e.X + 1, e.Y - 1));

                        if (!pixelmap.Exists(bp => bp.X == e.X + 2 && bp.Y == e.Y + 1))
                            pixelmap.Add(new BitPixel(true, e.X + 2, e.Y + 1));
                        if (!pixelmap.Exists(bp => bp.X == e.X + 2 && bp.Y == e.Y))
                            pixelmap.Add(new BitPixel(true, e.X + 2, e.Y));
                        if (!pixelmap.Exists(bp => bp.X == e.X + 2 && bp.Y == e.Y - 1))
                            pixelmap.Add(new BitPixel(true, e.X + 2, e.Y - 1));

                        if (!pixelmap.Exists(bp => bp.X == e.X - 2 && bp.Y == e.Y + 1))
                            pixelmap.Add(new BitPixel(true, e.X - 2, e.Y + 1));
                        if (!pixelmap.Exists(bp => bp.X == e.X - 2 && bp.Y == e.Y))
                            pixelmap.Add(new BitPixel(true, e.X - 2, e.Y));
                        if (!pixelmap.Exists(bp => bp.X == e.X - 2 && bp.Y == e.Y - 1))
                            pixelmap.Add(new BitPixel(true, e.X - 2, e.Y - 1));

                        if (!pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y + 2))
                            pixelmap.Add(new BitPixel(true, e.X + 1, e.Y + 2));
                        if (!pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y + 2))
                            pixelmap.Add(new BitPixel(true, e.X, e.Y + 2));
                        if (!pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y + 2))
                            pixelmap.Add(new BitPixel(true, e.X - 1, e.Y + 2));

                        if (!pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y - 2))
                            pixelmap.Add(new BitPixel(true, e.X + 1, e.Y - 2));
                        if (!pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y - 2))
                            pixelmap.Add(new BitPixel(true, e.X, e.Y - 2));
                        if (!pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y - 2))
                            pixelmap.Add(new BitPixel(true, e.X - 1, e.Y - 2));
                        // not necessary for function, but necessary for optimization
                    }
                }
                else
                {
                    if (brushsize == 1) {
                        Debug.WriteLine("small erase");
                        if (pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X && bp.Y == e.Y));
                    }
                    else if (brushsize == 2)
                    {
                        Debug.WriteLine("medium erase");
                        if (pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X && bp.Y == e.Y));
                        if (pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y - 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X - 1 && bp.Y == e.Y - 1));
                        if (pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X - 1 && bp.Y == e.Y));
                        if (pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y - 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X && bp.Y == e.Y - 1));
                        if (pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y + 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X + 1 && bp.Y == e.Y + 1));
                        if (pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X + 1 && bp.Y == e.Y));
                        if (pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y + 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X && bp.Y == e.Y + 1));
                        if (pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y + 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X - 1 && bp.Y == e.Y + 1));
                        if (pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y - 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X + 1 && bp.Y == e.Y - 1));
                    }
                    else if (brushsize == 3)
                    {
                        Debug.WriteLine("big erase");
                        if (pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X && bp.Y == e.Y));
                        if (pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y - 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X - 1 && bp.Y == e.Y - 1));
                        if (pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X - 1 && bp.Y == e.Y));
                        if (pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y - 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X && bp.Y == e.Y - 1));
                        if (pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y + 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X + 1 && bp.Y == e.Y + 1));
                        if (pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X + 1 && bp.Y == e.Y));
                        if (pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y + 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X && bp.Y == e.Y + 1));
                        if (pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y + 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X - 1 && bp.Y == e.Y + 1));
                        if (pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y - 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X + 1 && bp.Y == e.Y - 1));

                        if (pixelmap.Exists(bp => bp.X == e.X + 2 && bp.Y == e.Y + 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X + 2 && bp.Y == e.Y + 1));
                        if (pixelmap.Exists(bp => bp.X == e.X + 2 && bp.Y == e.Y))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X + 2 && bp.Y == e.Y));
                        if (pixelmap.Exists(bp => bp.X == e.X + 2 && bp.Y == e.Y - 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X + 2 && bp.Y == e.Y - 1));

                        if (pixelmap.Exists(bp => bp.X == e.X - 2 && bp.Y == e.Y + 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X - 2 && bp.Y == e.Y + 1));
                        if (pixelmap.Exists(bp => bp.X == e.X - 2 && bp.Y == e.Y))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X - 2 && bp.Y == e.Y));
                        if (pixelmap.Exists(bp => bp.X == e.X - 2 && bp.Y == e.Y - 1))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X - 2 && bp.Y == e.Y - 1));

                        if (pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y + 2))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X + 1 && bp.Y == e.Y + 2));
                        if (pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y + 2))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X && bp.Y == e.Y + 2));
                        if (pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y + 2))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X - 1 && bp.Y == e.Y + 2));

                        if (pixelmap.Exists(bp => bp.X == e.X + 1 && bp.Y == e.Y - 2))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X + 1 && bp.Y == e.Y - 2));
                        if (pixelmap.Exists(bp => bp.X == e.X && bp.Y == e.Y - 2))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X && bp.Y == e.Y - 2));
                        if (pixelmap.Exists(bp => bp.X == e.X - 1 && bp.Y == e.Y - 2))
                            pixelmap.RemoveAt(pixelmap.FindIndex(bp => bp.X == e.X - 1 && bp.Y == e.Y - 2));
                    }
                }
                picpanel.Invalidate(new Rectangle(e.X - 3, e.Y - 3, 9, 9));
                picpanel.Update();
                debugToolStripMenuItem.Text = pixelmap.Count.ToString();
            }
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debugger.Launch();
        }

        private void selectlarge(object sender, EventArgs e)
        {
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = true;
            brushsize = 3;
        }

        private void selectmedium(object sender, EventArgs e)
        {
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = true;
            largeToolStripMenuItem.Checked = false;
            brushsize = 2;
        }

        private void selectsmall(object sender, EventArgs e)
        {
            smallToolStripMenuItem.Checked = true;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
            brushsize = 1;
        }

        private void exitAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ofd = openFileDialog1.ShowDialog();
            if (ofd == DialogResult.Cancel || ofd == DialogResult.Abort) return;
            else if (ofd == DialogResult.OK)
            {
                Debug.WriteLine("about to open");
                using (FileStream fsfiler = File.Open(openFileDialog1.FileName, FileMode.Open))
                {
                    Debug.WriteLine("reading");
                    BinaryReader br = new BinaryReader(fsfiler);
                    ushort width = br.ReadUInt16();
                    FileInfo fi = new FileInfo(openFileDialog1.FileName);
                    ushort height = br.ReadUInt16();
                    Width = width;
                    Height = height;
                    pixelmap.Clear();
                    picpanel.Width = width;
                    picpanel.Height = height;
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    int bits = 32;
                    for (ushort ih = 0; ih < Height; ih++)
                    {
                        for (ushort iw = 0; iw < Width; iw++)
                        {
                            bits++;
                            Debug.WriteLine(iw + ", " + ih + " - " + bits + "/" + (fi.Length) + " - " + sw.Elapsed.ToString() + " time elapsed");
                            if (br.ReadBoolean() == true)
                            {
                                pixelmap.Add(new BitPixel(true, iw, ih));
                            }
                            else
                            {

                            }
                        }
                    }
                    MinimumSize = new Size(width + 36, height + 60);
                    Debug.WriteLine("done");
                    br.Close();
                    fsfiler.Close();
                    br.Dispose();
                    fsfiler.Dispose();
                    picpanel.Refresh();
                }
            }
            else
            {
                MessageBox.Show("this isn't supposed to show");
                return;
            }
        }

        private void saveCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ofd = saveFileDialog1.ShowDialog();
            if (ofd == DialogResult.Cancel || ofd == DialogResult.Abort) return;
            else if (ofd == DialogResult.OK)
            {
                Debug.WriteLine("about to write");
                if (File.Exists(saveFileDialog1.FileName))
                {
                    using (FileStream fsfile = File.Open(saveFileDialog1.FileName, FileMode.Truncate))
                    {
                        Debug.WriteLine("overwriting...");
                        BinaryWriter bw = new BinaryWriter(fsfile);
                        bw.Write(Width);
                        bw.Write(Height);
                        for (ushort ih = 0; ih < Height; ih++)
                        {
                            for (ushort iw = 0; iw < Width; iw++)
                            {
                                if (pixelmap.Exists(bp => bp.X == iw && bp.Y == ih))
                                    bw.Write(true);
                                else
                                    bw.Write(false);
                            }
                        }
                        bw.Close();
                        fsfile.Close();
                        Debug.WriteLine("done");
                        bw.Dispose();
                        fsfile.Dispose();
                        picpanel.Refresh();
                    }
                }
                else
                {
                    using (FileStream fsfile = File.Create(saveFileDialog1.FileName))
                    {
                        Debug.WriteLine("writing...");
                        BinaryWriter bw = new BinaryWriter(fsfile);
                        bw.Write(Width);
                        bw.Write(Height);
                        for (ushort ih = 0; ih < Height; ih++)
                        {
                            for (ushort iw = 0; iw < Width; iw++)
                            {
                                if (pixelmap.Exists(bp => bp.X == iw && bp.Y == ih))
                                    bw.Write(true);
                                else
                                    bw.Write(false);
                            }
                        }
                        bw.Close();
                        fsfile.Close();
                        Debug.WriteLine("done");
                        bw.Dispose();
                        fsfile.Dispose();
                        picpanel.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("this isn't supposed to show");
                return;
            }
        }

        private void newCtrlNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var thing = new NewFileDialog();
            thing.Show();

            thing.FormClosed += newfiledone;
        }
        
        private void newfiledone(object sender, FormClosedEventArgs e)
        {
            if (NewFileDialog.Status == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                pixelmap.Clear();
                Width = NewFileDialog.Width;
                Height = NewFileDialog.Height;
                picpanel.Width = NewFileDialog.Width;
                picpanel.Height = NewFileDialog.Height;
                MinimumSize = new Size(NewFileDialog.Width + 36, NewFileDialog.Height + 60);
                picpanel.Refresh();
            }
        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(".\\LICENSE.txt");
        }
    }

    public struct BitPixel
    {
        public BitPixel(bool black, int x, int y)
        {
            Black = black;
            X = x;
            Y = y;
        }

        public bool Black;
        public int X;
        public int Y;
    }
}
