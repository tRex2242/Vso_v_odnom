using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Vso_v_odnom
{
    public partial class Form1 : Form
    {
        string imageName;
        Pen pen;
        PictureBox curColor;
        List<Point> points;
        //--------------
        string textFile;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Brushes.Black, 1);
            curColor = Black;
            points = new List<Point>();
            pb.Image = new Bitmap(pb.Width, pb.Height);
        }

        private void OpenText_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Text files (*.txt, *.json) | *.txt; *.json",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.Text = File.ReadAllText(dialog.FileName);
                    textFile = dialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка! Невозможно прочитать файл с диска! " +
                        "Сообщение об ошибке:" + ex.Message);
                }
            }
        }

        private void SaveText_Click(object sender, EventArgs e)
        {
            if (textFile == null)
            {
                SaveFileDialog saveText = new SaveFileDialog();
                saveText.FileName = "untitled";
                saveText.DefaultExt = ".txt";
                saveText.ValidateNames = true;
                saveText.Filter = "Text files (*.txt, *.json) | *.txt; *.json";
                if (saveText.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveText.FileName, richTextBox1.Text);
                    textFile = saveText.FileName;
                }
            }
            else
            {
                File.WriteAllText(textFile, richTextBox1.Text);
            }
        }

        private void SaveTextAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveText = new SaveFileDialog();
            saveText.FileName = "untitled";
            saveText.DefaultExt = ".txt";
            saveText.ValidateNames = true;
            saveText.Filter = "Text files (*.txt, *.json) | *.txt; *.json";
            if (saveText.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveText.FileName, richTextBox1.Text);
                textFile = saveText.FileName;
            }
        }

        private void OpenPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                InitialDirectory = "c:\\",
                Filter = "Image Files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) |" +
                " *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.gif; *.bmp ",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pb.Image = Image.FromFile(dialog.FileName);
                    imageName = dialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка! Невозможно прочитать файл с диска! " +
                        "Сообщение об ошибке:" + ex.Message);
                }
            }
        }

        private Point transform(Point original)
        {
            float wRatio = (float)pb.Image.Width / pb.Width;
            float hRatio = (float)pb.Image.Height / pb.Height;
            return new Point
            {
                X = (int)(original.X * wRatio),
                Y = (int)(original.Y * hRatio)
            };
        }
        private void pb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                points.Add(transform(e.Location));
            }
        }

        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"{e.X} {e.Y} {e.Button} {points.Count}");
            Console.WriteLine($"pb:{pb.Size}; Image: {pb.Image.Size}");
            Console.WriteLine($"original{e.Location}; \ttransformed: {transform(e.Location)}");
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics canvas = Graphics.FromImage(pb.Image))
                {
                    points.Add(transform(e.Location));
                    if (points.Count > 1)
                        canvas.DrawCurve(pen, points.ToArray(), 0.1f);
                }
                pb.Invalidate();
            }
        }

        private void pb_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                points.Clear();
            }
        }

        void setPen(PictureBox color)
        {
            pen.Color = color.BackColor;
            curColor.BorderStyle = BorderStyle.None;
            curColor = color;
            curColor.BorderStyle = BorderStyle.Fixed3D;
        }
        private void red_Click(object sender, EventArgs e)
        {
            setPen(red);
        }

        private void orange_Click(object sender, EventArgs e)
        {
            setPen(orange);
        }

        private void yellow_Click(object sender, EventArgs e)
        {
            setPen(yellow);
        }

        private void lime_Click(object sender, EventArgs e)
        {
            setPen(lime);
        }

        private void aqua_Click(object sender, EventArgs e)
        {
            setPen(aqua);
        }

        private void blue_Click(object sender, EventArgs e)
        {
            setPen(blue);
        }

        private void purpur_Click(object sender, EventArgs e)
        {
            setPen(purpur);
        }

        private void Black_Click(object sender, EventArgs e)
        {
            setPen(Black);
        }

        private void White_Click(object sender, EventArgs e)
        {
            setPen(White);
        }

        private void MedVoil_Click(object sender, EventArgs e)
        {
            setPen(MedVoil);
        }

        private void gray_Click(object sender, EventArgs e)
        {
            setPen(gray);
        }

        private void fusia_Click(object sender, EventArgs e)
        {
            setPen(fusia);
        }

        private void gold_Click(object sender, EventArgs e)
        {
            setPen(gold);
        }

        private void purple_Click(object sender, EventArgs e)
        {
            setPen(purple);
        }

        private void salmon_Click(object sender, EventArgs e)
        {
            setPen(salmon);
        }

        private void green_Click(object sender, EventArgs e)
        {
            setPen(green);
        }

        private void fiol_Click(object sender, EventArgs e)
        {
            setPen(fiol);
        }

        private void hghtlt_Click(object sender, EventArgs e)
        {
            setPen(hghtlt);
        }

        private void asd_Click(object sender, EventArgs e)
        {
            setPen(asd);
        }

        private void grua_Click(object sender, EventArgs e)
        {
            setPen(grua);
        }

        private void opet_Click(object sender, EventArgs e)
        {
            setPen(opet);
        }

        private void pink_Click(object sender, EventArgs e)
        {
            setPen(pink);
        }

        private void lightyl_Click(object sender, EventArgs e)
        {
            setPen(lightyl);
        }

        private void purp_s_Click(object sender, EventArgs e)
        {
            setPen(purp_s);
        }

        private void darkOrchid_Click(object sender, EventArgs e)
        {
            setPen(darkOrchid);
        }

        private void MediumSlateBlue_Click(object sender, EventArgs e)
        {
            setPen(MediumSlateBlue);
        }

        private void dodgerBlue_Click(object sender, EventArgs e)
        {
            setPen(dodgerBlue);
        }

        private void plategreen_Click(object sender, EventArgs e)
        {
            setPen(plategreen);
        }

        private void tan_Click(object sender, EventArgs e)
        {
            setPen(tan);
        }

        private void darkgreen_Click(object sender, EventArgs e)
        {
            setPen(darkgreen);
        }

        private void marron_Click(object sender, EventArgs e)
        {
            setPen(marron);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float width = (float)Convert.ToDouble(textBox1.Text);
                if (width < 1)
                {
                    width = 1;
                } 
                else if(width > 100)
                {
                    width = 100;
                }

                pen.Width = width;
                textBox1.Text = width.ToString();
            }
            catch (Exception)
            {
                textBox1.Text = pen.Width.ToString();
            }
        }

        private void SavePicture_Click(object sender, EventArgs e)
        {
            if (pb.Image == null) return;
            if (pb.Image == null)
            {
                imageName = "united.bmp";
            }

            SaveFileDialog saveImage = new SaveFileDialog
            {
                FileName = Path.GetFileNameWithoutExtension(imageName),
                DefaultExt = Path.GetExtension(imageName).Trim(new char[] {' ', '.'}),
                ValidateNames = true,
                Filter = "Bitmap Image (.bmp) | *.bmp | Gif Image (.gif) | *.gif | JPEG Image (.jpg) | *.jpg | " +
                "Png Image (.png) | *.png"
            };
            if(saveImage.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(pb.Image);
                bmp.Save(saveImage.FileName);
            }
            
        }
    }
}
