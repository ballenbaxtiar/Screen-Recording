using System;
using Accord.Video.FFMPEG;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using NAudio.Wave;
using System.Drawing.Imaging;

namespace Screen_Recording
{
    public partial class ScreenRecordForm : Form
    {
        private VideoFileWriter writer;
        private string videoFolderPath = @"C:\Users\CTC\Desktop\Screen Recording\ScreenRecords";
        private bool isRecording = false;
        private string screenshotFolderPath = @"C:\Users\CTC\Desktop\Screen Recording\ScreenShots";
        private ManualResetEvent pauseEvent = new ManualResetEvent(true);
        private WaveIn waveIn;
        private WaveFileWriter waveWriter;
        private string audioFolderPath = @"C:\Users\CTC\Desktop\Screen Recording\AudioRecordings";
        private bool isRecordingAudio = false;

        public ScreenRecordForm()
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
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizerBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void optBtn_Click(object sender, EventArgs e)
        {
            Form f = new optForm();
            f.Show();
        }

        private void scShotBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Bitmap screenshot = CaptureScreen();
            string fileName = $"Screenshot_{DateTime.Now:yyyyMMddHHmmss}.png";
            string fullPath = Path.Combine(screenshotFolderPath, fileName);
            screenshot.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            this.WindowState = FormWindowState.Normal;
            MessageBox.Show($"Screenshot saved in {screenshotFolderPath}.");
        }
        private Bitmap CaptureScreen()
        {
            Screen screen = Screen.PrimaryScreen;
            Bitmap screenshot = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(screenshot))
            {
                g.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);
            }

            return screenshot;
        }
        private void StartRecording()
        {
            string fileName = $"Recording_{DateTime.Now:yyyyMMddHHmmss}.avi";
            string fullPath = Path.Combine(videoFolderPath, fileName);

            writer = new VideoFileWriter();
            writer.Open(fullPath, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 20, VideoCodec.MSMPEG4v3, 1000000000); 
            isRecording = true;

            var recordingThread = new System.Threading.Thread(RecordScreen);
            recordingThread.Start();
        }
        private void StopRecording()
        {
            isRecording = false;
            Thread.Sleep(1000);
            writer.Close();
            writer.Dispose();
            MessageBox.Show($"Screen Record saved in {videoFolderPath}.");
        }

        private void RecordScreen()
        {
            while (isRecording)
            {
                pauseEvent.WaitOne();
                Bitmap screenshot = CaptureScreen();

                writer.WriteVideoFrame(screenshot);
            }
        }

        private void scRecoBtn_Click(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                StartRecording();
                stopRecBtn.Visible = true;
                pauseBtn.Visible = true;
            }
        }

        private void stopRecBtn_Click(object sender, EventArgs e)
        {
            if (isRecording)
            {
                StopRecording();
                stopRecBtn.Visible = false;
                pauseBtn.Visible = false;
                resumeBtn.Visible = false;
            }
        }
        private void PauseRecording()
        {
            pauseEvent.Reset(); 
        }

        private void ResumeRecording()
        {
            pauseEvent.Set(); 
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            if (isRecording)
            {
                PauseRecording();
                pauseBtn.Visible=false;
                resumeBtn.Visible=true;
                pauseBtn.Visible= false;
            }
        }

        private void resumeBtn_Click(object sender, EventArgs e)
        {
            if (isRecording)
            {
                ResumeRecording();
                pauseBtn.Visible = true;
            }
        }

        private void ScreenRecordForm_Load(object sender, EventArgs e)
        {
            Button pauseButton = new Button();
            pauseButton.Click += new EventHandler(pauseBtn_Click);
            this.Controls.Add(pauseButton);

            Button resumeButton = new Button();
            resumeButton.Click += new EventHandler(resumeBtn_Click);
            this.Controls.Add(resumeButton);
            Button startAudioButton = new Button();
            startAudioButton.Text = "Start Audio";
            startAudioButton.Click += new EventHandler(vocRecoBtn_Click);
            this.Controls.Add(startAudioButton);

            Button stopAudioButton = new Button();
            stopAudioButton.Text = "Stop Audio";
            stopAudioButton.Click += new EventHandler(stopVocBtn_Click);
            this.Controls.Add(stopAudioButton);
        }
        private void StartAudioRecording()
        {
            string fileName = $"AudioRecording_{DateTime.Now:yyyyMMddHHmmss}.wav";
            string fullPath = Path.Combine(audioFolderPath, fileName);

            waveIn = new WaveIn();
            waveIn.WaveFormat = new WaveFormat(44100, 1);
            waveIn.DataAvailable += WaveIn_DataAvailable;

            waveWriter = new WaveFileWriter(fullPath, waveIn.WaveFormat);
            waveIn.StartRecording();
            isRecordingAudio = true;
        }
        private void StopAudioRecording()
        {
            isRecordingAudio = false;
            waveIn.StopRecording();
            waveIn.Dispose();
            waveWriter.Close();
            waveWriter.Dispose();
            MessageBox.Show($"Audio Record saved in {audioFolderPath}.");
        }
        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private void vocRecoBtn_Click(object sender, EventArgs e)
        {
            if (!isRecordingAudio)
            {
                StartAudioRecording();
                stopVocBtn.Visible = true;
            }
        }

        private void stopVocBtn_Click(object sender, EventArgs e)
        {
            if (isRecordingAudio)
            {
                StopAudioRecording();
                stopVocBtn.Visible = false;
            }
        }

        private void snippingToolBtn_Click(object sender, EventArgs e)
        {
            CaptureSnip();
        }
        private void CaptureSnip()
        {
            this.WindowState = FormWindowState.Minimized;

            using (Bitmap screenshot = CaptureScreen())
            {
                this.WindowState = FormWindowState.Maximized;
                Rectangle selectedRegion = SelectRegion(screenshot);

                if (selectedRegion.Width > 0 && selectedRegion.Height > 0)
                {
                    Bitmap snip = CropImage(screenshot, selectedRegion);
                    this.WindowState = FormWindowState.Normal;
                    SaveSnip(snip);
                }
            }

            
        }

        private Rectangle SelectRegion(Bitmap screenshot)
        {
            using (var snipForm = new SnipForm())
            {
                snipForm.BackgroundImage = screenshot;
                snipForm.StartPosition = FormStartPosition.Manual;
                snipForm.Location = this.Location;
                snipForm.ShowDialog();

                return snipForm.SelectedRegion;
            }
        }

        private Bitmap CropImage(Bitmap originalImage, Rectangle cropRegion)
        {
            Bitmap croppedImage = new Bitmap(cropRegion.Width, cropRegion.Height);

            using (Graphics g = Graphics.FromImage(croppedImage))
            {
                g.DrawImage(originalImage, 0, 0, cropRegion, GraphicsUnit.Pixel);
            }

            return croppedImage;
        }

        private void SaveSnip(Bitmap snip)
        {
            string fileName = $"Snip_{DateTime.Now:yyyyMMddHHmmss}.png";
            string fullPath = Path.Combine(screenshotFolderPath, fileName);

            snip.Save(fullPath, ImageFormat.Png);

            MessageBox.Show($"Snip saved in {screenshotFolderPath}.");
        }
        public class SnipForm : Form
        {
            private Point startPoint;
            private Rectangle selectedRegion;

            public Rectangle SelectedRegion => selectedRegion;

            public SnipForm()
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.WindowState = FormWindowState.Maximized;
                this.Cursor = Cursors.Cross;

                this.MouseDown += SnipForm_MouseDown;
                this.MouseMove += SnipForm_MouseMove;
                this.MouseUp += SnipForm_MouseUp;
            }

            private void SnipForm_MouseDown(object sender, MouseEventArgs e)
            {
                startPoint = e.Location;
                selectedRegion = new Rectangle(startPoint, new Size(0, 0));
            }

            private void SnipForm_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int width = e.X - startPoint.X;
                    int height = e.Y - startPoint.Y;

                    selectedRegion = new Rectangle(startPoint, new Size(width, height));
                    this.Invalidate();
                }
            }

            private void SnipForm_MouseUp(object sender, MouseEventArgs e)
            {
                this.Close();
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, selectedRegion);
                }
            }
        }

    }
}
