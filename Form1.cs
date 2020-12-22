using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 音楽再生
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void sansyou_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path.Text = openFileDialog1.FileName;
                axWindowsMediaPlayer1.URL = path.Text;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                axWindowsMediaPlayer1.mediaCollection.add(axWindowsMediaPlayer1.URL);
                double d_nagasa = axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                progressBar1.Maximum = (int)Math.Truncate(d_nagasa);
                long sec = long.Parse(Math.Truncate(d_nagasa).ToString());
                long min, hour;
                hour = sec / 3600;
                min = (sec % 3600) / 60;
                sec = sec % 60;
                subete_time.Text = $"{hour}:{min}:{sec}";
                start.Text = "一時停止";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double d_nagasa = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            long nagasa = (int)Math.Truncate(d_nagasa);
            long sec = nagasa;
            long min, hour;
            hour = sec / 3600;
            min = (sec % 3600) / 60;
            sec = sec % 60;
            time.Text = $"{hour}:{min}:{sec}";
            progressBar1.Value = int.Parse(nagasa.ToString());
        }

        private void trackBar1_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void trackBar1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void start_Click(object sender, EventArgs e)
        {
            if(start.Text == "再生")
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                start.Text = "一時停止";
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                start.Text = "再生";
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            start.Text = "再生";
        }
    }
}
