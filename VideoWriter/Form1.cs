using AForge.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreateVideo_Click(object sender, EventArgs e)
        {
            int width = 858;
            int height = 480;

            VideoFileWriter writer = new VideoFileWriter();
            writer.Open("sample-video.avi", width, height, 1, VideoCodec.MPEG4, 2500000);

            Bitmap image = new Bitmap(width, height);

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image = new Bitmap(dlg.FileName);
                }
            }

            for (int i = 0; i < 36000; i++)
            {
                writer.WriteVideoFrame(image);
            }

            writer.Close();
            Application.Exit();
        }
    }
}
