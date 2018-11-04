using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int Index = comboBox1.SelectedIndex;
            switch (Index)
            {
                case 0:
                    QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                    var Text = QG.CreateQrCode(textBox1.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
                    var Code = new QRCoder.QRCode(Text);
                    pictureBox1.Image = Code.GetGraphic(50);
                    break;
                case 1:
                    try
                    {
                        Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Image = brCode.Draw(textBox1.Text, 40);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Error ?");
                    }
                    break;
            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            textBox1.Enabled = true;
            if (textBox1.Text != null)
            {
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }
    }
}
