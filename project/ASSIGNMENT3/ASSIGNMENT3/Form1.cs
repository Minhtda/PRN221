using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASSIGNMENT3
{
    public partial class Form1 : Form
    {
        CancellationTokenSource _tokenSource;
        public Form1()
        {
            InitializeComponent();
            TimeSpan timeSpan = TimeSpan.FromSeconds(0);
            lbCount.Text = timeSpan.ToString(@"hh\:mm\:ss");
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }
        private void CountDown(int time, CancellationToken token)
        {
            for (int i = time; 0 <= i; i--)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(i);
                lbCount.Invoke((MethodInvoker)(() => lbCount.Text = timeSpan.ToString(@"hh\:mm\:ss")));
                Thread.Sleep(1000);
                if (token.IsCancellationRequested)
                {
                    i = -1;
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Thread.CurrentThread.Name = "Form1";
            //Task task01 = new Task(() => CountDown((int)numericUpDown1.Value));
            //task01.Start();
            if (_tokenSource == null)
            {
                _tokenSource = new CancellationTokenSource();
                var token = _tokenSource.Token;
                try
                {
                    button1.Text = "Cancle";
                    await Task.Run(() => CountDown((int)numericUpDown1.Value, token));
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _tokenSource.Dispose();
                    _tokenSource = null;
                    button1.Text = "Go";
                    button1.IsAccessible = true;
                }

            }
            else
            {
                button1.IsAccessible = false;
                cancle();
                numericUpDown1.Value = 0;
                TimeSpan timeSpan = TimeSpan.FromSeconds(0);
                lbCount.Text = timeSpan.ToString(@"hh\:mm\:ss");
            }
        }
        private void cancle()
        {
            _tokenSource.Cancel();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
