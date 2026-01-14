using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Video.FFMPEG;
using NAudio.Wave;


namespace Screen_Recording
{
    public partial class optForm : Form
    {
        private string screenshotFolderPath = @"C:\Users\CTC\Desktop\Screen Recording\ScreenShots";
        private string videoFolderPath = @"C:\Users\CTC\Desktop\Screen Recording\ScreenRecords";
        private string audioFolderPath = @"C:\Users\CTC\Desktop\Screen Recording\AudioRecordings";
        public optForm()
        {
            InitializeComponent();
            if (!Directory.Exists(screenshotFolderPath))
            {
                Directory.CreateDirectory(screenshotFolderPath);
            }
            if (!Directory.Exists(videoFolderPath))
            {
                Directory.CreateDirectory(videoFolderPath);
            }
            if (!Directory.Exists(audioFolderPath))
            {
                Directory.CreateDirectory(audioFolderPath);
            }
        }
        private void applyBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void picFolderBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", screenshotFolderPath);
        }

        private void vidFolderBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", videoFolderPath);
        }

        private void vocFolderBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", audioFolderPath);
        }
    }
}
