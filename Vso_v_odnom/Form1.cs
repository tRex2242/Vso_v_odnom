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
        string textFile;
        Pen pen;
        PictureBox curColor;
        public Form1()
        {
            InitializeComponent();

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

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.Text = File.ReadAllText(dialog.FileName);
                    textFile = dialog.FileName;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка! Невозможно прочитать файл с диска! " +
                        "Сообщение об ошибке:" + ex.Message);
                }
            }
        }

        private void SaveText_Click(object sender, EventArgs e)
        {
            if(textFile == null)
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
    }
}
