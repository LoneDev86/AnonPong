using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YackYack
{
    public partial class YakYak : Form
    {
        bool goup;
        bool godown;
        int speed = 15;
        int ballx = 5;
        int bally = 5;
        int score = 0;
        int cpuPoint = 0;

        public YakYak()
        {
            InitializeComponent();
            Update();
        }

        private void YakYak_Load(object sender, EventArgs e)
        {
            Update();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            

            playerScore.Text = "" + score;

            cpuLabel.Text = "" + cpuPoint;

            ball.Top -= bally;

            ball.Left -= ballx;

            cpu.Top += speed;
            
            if (score < 2)
                
            {
                if (cpu.Top < 0 || cpu.Top > 455)

                { 
                    speed = -speed; 
                }
            }

            else
            {
                cpu.Top = ball.Top + 15;
            }

            if (ball.Left < 0)
            {
                ball.Left = 434;

                ballx = -ballx;
                ballx += 5;
                cpuPoint++;
            }

            if (ball.Left + ball.Width > ClientSize.Width)
            {
                ball.Left = 434;
                ballx = -ballx;
                ballx += 5;
                score++;
            }

            if (ball.Top < 0 || ball.Top + ball.Height > ClientSize.Height)
            {
                bally = -bally;
            }

            if (ball.Bounds.IntersectsWith(player.Bounds) || ball.Bounds.IntersectsWith(cpu.Bounds))
            {
                ballx = -ballx;
            }

            if (goup == true && player.Top > 5)
            {
                player.Top -= 15;
            }

            if (godown == true && player.Top < 455)
            {
                player.Top += 15;
            }

            if(score > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("You win this game");
            }

            if(cpuPoint > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("CPU wins, you lose");
            }

        }
    }
}
